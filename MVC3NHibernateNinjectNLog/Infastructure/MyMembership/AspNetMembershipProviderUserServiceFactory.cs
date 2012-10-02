using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC3NHibernateNinjectNLog.Infastructure.MyMembership
{
    public class AspNetMembershipProviderUserServiceFactory : IUserServiceFactory
    {
        #region IUserServiceFactory Members

        public IUserService Make()
        {
            return new AspNetMembershipProviderWrapper();
        }

        #endregion
    }
}