using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC3NHibernateNinjectNLog.Infastructure.MyMembership.Settings
{
    public class RegistrationSettings : IRegistrationSettings
    {
        public RegistrationSettings(bool requiresUniqueEmailAddress)
        {
            RequiresUniqueEmailAddress = requiresUniqueEmailAddress;
        }

        #region IRegistrationSettings Members

        public bool RequiresUniqueEmailAddress { get; private set; }

        #endregion
    }
}