using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace MVC3NHibernateNinjectNLog.Infastructure.MyMembership.Settings
{
    public class PasswordSettings : IPasswordSettings
    {
        public PasswordSettings(IPasswordResetRetrievalSettings resetOrRetrieval, int minimumLength, int minimumNonAlphanumericCharacters, string regularExpressionToMatch, MembershipPasswordFormat storageFormat)
        {
            ResetOrRetrieval = resetOrRetrieval;
            MinimumLength = minimumLength;
            MinimumNonAlphanumericCharacters = minimumNonAlphanumericCharacters;
            RegularExpressionToMatch = regularExpressionToMatch;
            StorageFormat = storageFormat;
        }

        #region IPasswordSettings Members

        public IPasswordResetRetrievalSettings ResetOrRetrieval { get; private set; }
        public int MinimumLength { get; private set; }
        public int MinimumNonAlphanumericCharacters { get; private set; }
        public string RegularExpressionToMatch { get; private set; }
        public MembershipPasswordFormat StorageFormat { get; private set; }

        #endregion
    }
}