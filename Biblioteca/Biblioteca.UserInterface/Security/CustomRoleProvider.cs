using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using Biblioteca.UserInterface.Models;
using Biblioteca.UserInterface.Helpers;

namespace Biblioteca.UserInterface.Security
{
    public class CustomRoleProvider : RoleProvider
    {
        private BusinessLogic.UserManager userManager;
        public CustomRoleProvider()
            : base()
        {
            userManager = new BusinessLogic.UserManager();
        }

        public override void AddUsersToRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }
        public override string ApplicationName
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }
        public override void CreateRole(string roleName)
        {
            throw new NotImplementedException();
        }
        public override bool DeleteRole(string roleName, bool throwOnPopulatedRole)
        {
            throw new NotImplementedException();
        }
        public override string[] FindUsersInRole(string roleName, string usernameToMatch)
        {
            throw new NotImplementedException();
        }

        public override string[] GetAllRoles()
        {
            throw new NotImplementedException();
        }

        public override string[] GetRolesForUser(string username)
        {
            Entities.User user = this.userManager.FindUserByUserName(username);//encuentro UserName
            string[] userRoles = new string[1];//creo un array tantas posiciones como roles hay
            for (int i = 0; i < 1 ;i++ )
            {
            //recorro  asignando en cada posicion los roles que tiene ese usuario
                userRoles[i] = user.role.description;
            }
            return userRoles;
        }

        public override string[] GetUsersInRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool IsUserInRole(string username, string roleName)
        {
            return (this.userManager.FindUserByUserName(username).role.description == roleName);
        }

        public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override bool RoleExists(string roleName)
        {
            throw new NotImplementedException();
        }
    }
}