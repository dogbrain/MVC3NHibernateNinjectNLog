using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MVC3NHibernateNinjectNLog.Infastructure.MyMembership.Settings
{
    public interface ILoginSettings
    {
        int MaximumInvalidPasswordAttempts { get; }
        int PasswordAttemptWindowInMinutes { get; }
    }
}
