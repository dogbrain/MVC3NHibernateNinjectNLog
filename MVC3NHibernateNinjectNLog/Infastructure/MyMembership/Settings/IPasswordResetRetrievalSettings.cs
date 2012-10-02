using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MVC3NHibernateNinjectNLog.Infastructure.MyMembership.Settings
{
    public interface IPasswordResetRetrievalSettings
    {
        bool CanReset { get; }
        bool CanRetrieve { get; }
        bool RequiresQuestionAndAnswer { get; }
    }
}
