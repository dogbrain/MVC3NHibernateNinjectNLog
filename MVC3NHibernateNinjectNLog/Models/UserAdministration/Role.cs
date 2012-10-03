using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace MVC3NHibernateNinjectNLog.Models
{
    public class Role
    {
        [Key]
        public virtual Guid RoleId { get; set; }

        [Required]
        public virtual string RoleName { get; set; }

        public virtual string Description { get; set; }

         public virtual IList<User> UsersInRole { get; set; }

        public Role()
        {
            UsersInRole = new List<User>();
        }
    }
}