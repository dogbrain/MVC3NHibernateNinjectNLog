using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Security;

namespace MVC3NHibernateNinjectNLog.Infastructure.MyMembership
{
    public interface IPasswordService
    {
        void Unlock(MembershipUser user);
        string ResetPassword(MembershipUser user);
        string ResetPassword(MembershipUser user, string passwordAnswer);
        void ChangePassword(MembershipUser user, string newPassword);
        void ChangePassword(MembershipUser user, string oldPassword, string newPassword);
    }
}
