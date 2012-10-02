using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PagedList;
using System.Web.Security;

namespace MVC3NHibernateNinjectNLog.Models
{
    public class IndexViewModel
    {
        public string Search { get; set; }
        public IPagedList<MembershipUser> Users { get; set; }
        public IEnumerable<string> Roles { get; set; }
        public bool IsRolesEnabled { get; set; }
    }
}