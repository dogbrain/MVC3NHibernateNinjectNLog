using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC3NHibernateNinjectNLog.Infastructure.MyMembership.Settings
{
    public class PasswordResetRetrievalSettings : IPasswordResetRetrievalSettings
    {
        public PasswordResetRetrievalSettings(bool canReset, bool canRetrieve, bool requiresQuestionAndAnswer)
        {
            CanReset = canReset;
            CanRetrieve = canRetrieve;
            RequiresQuestionAndAnswer = requiresQuestionAndAnswer;
        }

        #region IPasswordResetRetrievalSettings Members

        public bool CanReset { get; private set; }
        public bool CanRetrieve { get; private set; }
        public bool RequiresQuestionAndAnswer { get; private set; }

        #endregion
    }
}