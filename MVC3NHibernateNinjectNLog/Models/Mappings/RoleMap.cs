using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FluentNHibernate.Mapping;

namespace MVC3NHibernateNinjectNLog.Models.Mappings
{
    public class RoleMap : ClassMap<Role>
    {
        public RoleMap()
        {
            Id(x => x.RoleId);
            Map(x => x.RoleName);
            Map(x => x.Description);
            HasManyToMany<User>(m => m.Users).Cascade.SaveUpdate().AsBag();
        }
    }
}