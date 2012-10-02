using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace MVC3NHibernateNinjectNLog.Models
{
    public class RoleViewModel
    {
        public string Role { get; set; }
        public IDictionary<string, MembershipUser> Users { get; set; }
    }
}