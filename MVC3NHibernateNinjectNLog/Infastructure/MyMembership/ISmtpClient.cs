using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Mail;

namespace MVC3NHibernateNinjectNLog.Infastructure.MyMembership
{
    public interface ISmtpClient
    {
        void Send(MailMessage mailMessage);
    }
}
