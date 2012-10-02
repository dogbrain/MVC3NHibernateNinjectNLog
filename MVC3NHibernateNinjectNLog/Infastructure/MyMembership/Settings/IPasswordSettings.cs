using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Security;

namespace MVC3NHibernateNinjectNLog.Infastructure.MyMembership.Settings
{
    public interface IPasswordSettings
    {
        IPasswordResetRetrievalSettings ResetOrRetrieval { get; }
        int MinimumLength { get; }
        int MinimumNonAlphanumericCharacters { get; }
        string RegularExpressionToMatch { get; }
        MembershipPasswordFormat StorageFormat { get; }
    }
}
