using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC3NHibernateNinjectNLog.Helpers
{
    public static class Utils
    {
          public static DateTime MinDate()
        {
            return System.Convert.ToDateTime("01/01/1753");

        }

        public static string BuildExceptionMessage(Exception ex)
        {
            Exception logException = ex;
            if (ex.InnerException != null)
                logException = ex.InnerException;

            string strErrorMsg = Environment.NewLine + "Error in Path :" + System.Web.HttpContext.Current.Request.Path;

            // Get the QueryString along with the Virtual Path
            strErrorMsg += Environment.NewLine + "Raw Url :" + System.Web.HttpContext.Current.Request.RawUrl;


            // Get the error message
            strErrorMsg += Environment.NewLine + "Message :" + logException.Message;

            // Source of the message
            strErrorMsg += Environment.NewLine + "Source :" + logException.Source;

            // Stack Trace of the error

            strErrorMsg += Environment.NewLine + "Stack Trace :" + logException.StackTrace;

            // Method where the error occurred
            strErrorMsg += Environment.NewLine + "TargetSite :" + logException.TargetSite;
            return strErrorMsg;

        }
    }
}