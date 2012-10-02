using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MVC3NHibernateNinjectNLog.Infastructure.Logging;
using MVC3NHibernateNinjectNLog.Infastructure.Data;
using MVC3NHibernateNinjectNLog.Models;
using System.Web.Mvc;
using System.Web.Security;

namespace MVC3NHibernateNinjectNLog.Infastructure.Providers
{
    public class FNHRoleProvider : RoleProvider
    {
        public ILogger Log { get; private set; }
        public IRepository<Role> RoleRepository { get; private set; }
        public IRepository<User> UserRepository { get; private set; }

        public FNHRoleProvider()
        {
            Log = DependencyResolver.Current.GetService<ILogger>();
            RoleRepository = DependencyResolver.Current.GetService<IRepository<Role>>();
            UserRepository = DependencyResolver.Current.GetService<IRepository<User>>();
        }

        public override string ApplicationName
        {
            get
            {
                return this.GetType().Assembly.GetName().Name.ToString();
            }
            set
            {
                this.ApplicationName = this.GetType().Assembly.GetName().Name.ToString();
            }
        }

        public override bool RoleExists(string roleName)
        {
            if (string.IsNullOrEmpty(roleName))
            {
                return false;
            }

            Role Role = null;
            Role = RoleRepository.GetAll().FirstOrDefault(Rl => Rl.RoleName == roleName);
            if (Role != null)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        public override bool IsUserInRole(string username, string roleName)
        {
            if (string.IsNullOrEmpty(username))
            {
                return false;
            }
            if (string.IsNullOrEmpty(roleName))
            {
                return false;
            }
            User User = null;
            User = UserRepository.GetAll().FirstOrDefault(Usr => Usr.Username == username);
            if (User == null)
            {
                return false;
            }
            Role Role = RoleRepository.GetAll().FirstOrDefault(Rl => Rl.RoleName == roleName);
            if (Role == null)
            {
                return false;
            }
            return User.Roles.Contains(Role);

        }

        public override string[] GetAllRoles()
        {
            return RoleRepository.GetAll().Select(Rl => Rl.RoleName).ToArray();

        }

        public override string[] GetUsersInRole(string roleName)
        {
            if (string.IsNullOrEmpty(roleName))
            {
                return null;
            }
            Role Role = null;
            Role = RoleRepository.GetAll().FirstOrDefault(Rl => Rl.RoleName == roleName);
            if (Role != null)
            {
                return Role.Users.Select(Usr => Usr.Username).ToArray();
            }
            else
            {
                return null;
            }

        }

        public override string[] GetRolesForUser(string username)
        {
            if (string.IsNullOrEmpty(username))
            {
                return null;
            }
            User User = null;
            User = UserRepository.GetAll().FirstOrDefault(Usr => Usr.Username == username);
            if (User != null)
            {
                return User.Roles.Select(Rl => Rl.RoleName).ToArray();
            }
            else
            {
                return null;
            }

        }

        public override string[] FindUsersInRole(string roleName, string usernameToMatch)
        {
            if (string.IsNullOrEmpty(roleName))
            {
                return null;
            }

            if (string.IsNullOrEmpty(usernameToMatch))
            {
                return null;
            }


            return (from Rl in RoleRepository.GetAll() from Usr in Rl.Users where Rl.RoleName == roleName && Usr.Username.Contains(usernameToMatch) select Usr.Username).ToArray();

        }

        public override void CreateRole(string roleName)
        {
            if (!string.IsNullOrEmpty(roleName))
            {
                Role Role = null;
                Role = RoleRepository.GetAll().FirstOrDefault(Rl => Rl.RoleName == roleName);
                if (Role == null)
                {
                    Role NewRole = new Role
                    {
                        RoleId = Guid.NewGuid(),
                        RoleName = roleName
                    };
                    RoleRepository.Add(NewRole);

                }

            }
        }

        public override bool DeleteRole(string roleName, bool throwOnPopulatedRole)
        {
            if (string.IsNullOrEmpty(roleName))
            {
                return false;
            }
            Role Role = null;
            Role = RoleRepository.GetAll().FirstOrDefault(Rl => Rl.RoleName == roleName);
            if (Role == null)
            {
                return false;
            }
            if (throwOnPopulatedRole)
            {
                if (Role.Users.Any())
                {
                    return false;
                }
            }
            else
            {
                Role.Users.Clear();
            }
            RoleRepository.Delete(Role);
            return true;

        }

        public override void AddUsersToRoles(string[] usernames, string[] roleNames)
        {
            List<User> Users = UserRepository.GetAll().Where(Usr => usernames.Contains(Usr.Username)).ToList();
            List<Role> Roles = RoleRepository.GetAll().Where(Rl => roleNames.Contains(Rl.RoleName)).ToList();
            foreach (User user in Users)
            {
                foreach (Role role in Roles)
                {
                    if (!user.Roles.Contains(role))
                    {
                        user.Roles.Add(role);
                        UserRepository.SaveOrUpdate(user);
                    }
                }
            }

        }

        public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
        {
            foreach (String username in usernames)
            {
                String us = username;
                User user = UserRepository.GetAll().FirstOrDefault(U => U.Username == us);
                if (user != null)
                {
                    foreach (String roleName in roleNames)
                    {
                        String rl = roleName;
                        Role role = RoleRepository.GetAll().FirstOrDefault(R => R.RoleName == rl);
                        if (role != null)
                        {
                            user.Roles.Remove(role);
                            UserRepository.SaveOrUpdate(user);
                        }
                    }
                }
            }

        }
    }
}