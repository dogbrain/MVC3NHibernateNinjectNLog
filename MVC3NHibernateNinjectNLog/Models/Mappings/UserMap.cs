using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FluentNHibernate.Mapping;

namespace MVC3NHibernateNinjectNLog.Models.Mappings
{
    public class UserMap : ClassMap<User>
    {
        public UserMap()
        {
            Id(x => x.UserId);
            Map(x => x.Username);
            Map(x => x.Email);
            Map(x => x.Password);
            Map(x => x.FirstName);
            Map(x => x.LastName);
            Map(x => x.Comment);
            Map(x => x.IsApproved);
            Map(x => x.PasswordFailuresSinceLastSuccess);
            Map(x => x.LastPasswordFailureDate);
            Map(x => x.LastActivityDate);
            Map(x => x.LastLockoutDate);
            Map(x => x.LastLoginDate);
            Map(x => x.ConfirmationToken);


            Map(x => x.CreateDate);
            Map(x => x.IsLockedOut);
            Map(x => x.LastPasswordChangedDate);
            Map(x => x.PasswordVerificationToken);
            Map(x => x.PasswordVerificationTokenExpirationDate);

            HasManyToMany<Role>(m => m.Roles).Cascade.SaveUpdate().Inverse().AsBag();
        }
    }
}