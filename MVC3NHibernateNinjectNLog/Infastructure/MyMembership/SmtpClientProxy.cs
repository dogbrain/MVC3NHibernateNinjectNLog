using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Mail;

namespace MVC3NHibernateNinjectNLog.Infastructure.MyMembership
{
    public class SmtpClientProxy : ISmtpClient
    {
        private readonly SmtpClient _smtpClient;

        public SmtpClientProxy()
        {
            _smtpClient = new SmtpClient();
        }

        public SmtpClientProxy(SmtpClient smtpClient)
        {
            _smtpClient = smtpClient;
        }

        #region ISmtpClient Members

        public void Send(MailMessage mailMessage)
        {
            _smtpClient.Send(mailMessage);
        }

        #endregion
    }
}