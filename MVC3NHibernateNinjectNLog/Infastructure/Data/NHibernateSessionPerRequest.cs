using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Context;
using NHibernate.Tool.hbm2ddl;
using FluentNHibernate.Cfg;
using MVC3NHibernateNinjectNLog.Models;
using System.Web.Mvc;
using System.Web.Security;
using System.IO;
using System.Reflection;

namespace MVC3NHibernateNinjectNLog.Infastructure.Data
{
    public class NHibernateSessionPerRequest : IHttpModule
    {
        private static readonly ISessionFactory _sessionFactory;

        // Constructs our HTTP module
        static NHibernateSessionPerRequest()
        {
            _sessionFactory = CreateSessionFactory();
       
        }

        // Initializes the HTTP module
        public void Init(HttpApplication context)
        {
            context.BeginRequest += BeginRequest;
            context.EndRequest += EndRequest;
           
        }

        // Disposes the HTTP module
        public void Dispose() { }

        // Returns the current session
        public static ISession GetCurrentSession()
        {
            return _sessionFactory.GetCurrentSession();
        }

        // Opens the session, begins the transaction, and binds the session
        private static void BeginRequest(object sender, EventArgs e)
        {
            ISession session = _sessionFactory.OpenSession();

            session.BeginTransaction();

            CurrentSessionContext.Bind(session);

    
        }

        // Unbinds the session, commits the transaction, and closes the session

        private static void EndRequest(object sender, EventArgs e)
        {
            ISession session = CurrentSessionContext.Unbind(_sessionFactory);

            if (session == null) return;

            try
            {
                session.Transaction.Commit();
            }
            catch (Exception ex)
            {
                session.Transaction.Rollback();
                throw ex;
            }
            finally
            {
                session.Close();
                session.Dispose();
            }
        }





        // Returns our NHibernate session factory
        internal   static ISessionFactory CreateSessionFactory()
        {
            //var mappings = CreateMappings();
            string fn = AppDomain.CurrentDomain.BaseDirectory;
            string configFile = HttpContext.Current.Server.MapPath("hibernate.cfg.xml");
            Configuration normalConfig = new Configuration().Configure(configFile);

            return Fluently
               .Configure(normalConfig)
               .Mappings(m => m.FluentMappings.AddFromAssemblyOf<User>())
               .ExposeConfiguration(c =>
               {
                   BuildSchema(c);
                   c.Properties[NHibernate.Cfg.Environment.CurrentSessionContextClass] = "web";
               })
               .BuildSessionFactory();
        }

        /// <summary>
        /// Builds the scema.
        /// 
        /// If the application setting Enviroment i web.config is set to Development then it drops the 
        /// database and recreates the schema. (A good place to insert some data in the db??)
        /// 
        /// Otherwise it updates the schem (drops no data)
        /// </summary>
        /// <param name="cfg"></param>
        private static void BuildSchema(Configuration cfg)
        {

            switch (System.Configuration.ConfigurationManager.AppSettings["Environment"].ToString())
            {

                case "Development":
                    new SchemaExport(cfg).Create(false, true); // Drops and creates the database schema

                    break;
                case "Production":
                    new SchemaUpdate(cfg); //will modify your existing table with new mapping, without dropping any columns.
                    break;
                case "ProductionValidateOnly":
                    new SchemaValidator(cfg); //will modify your existing table with new mapping, without dropping any columns.
                    break;
                default:
                    throw new ApplicationException("Unknown enviroment. Please update you Enviroment setting in web.config");
            }

            //

        }


        internal static void InsertDataFixtures()
        {
            switch (System.Configuration.ConfigurationManager.AppSettings["Environment"].ToString())
            {

                case "Development":
                    try
                    {
                        //If there are no users.. go ahead
                        BeginRequest(null, new EventArgs());
                        if (Membership.GetAllUsers().Count == 0)
                        {


                            MembershipCreateStatus createStatus;

                            System.Web.Security.Membership.CreateUser("user", "123456", "user@userland.com", null, null, true, null, out createStatus);
                            System.Web.Security.Membership.CreateUser("admin", "123456", "admin@userland.com", null, null, true, null, out createStatus);
                            Roles.CreateRole("Admin");
                            Roles.AddUserToRole("admin", "Admin");

                        }
                    }
                    finally
                    {
                        EndRequest(null, new EventArgs());
                    }
                    break;
            }
        }
    }
}