using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.BusinessLogic
{
    public class UserManager
    {
        private Data.UserManager userManager;
        public UserManager() {
            this.userManager = new Data.UserManager();
        }

        public bool registerNewUser(Entities.User entUser) {
            return this.userManager.registerNewUser(entUser);
        }

        public bool userNameAlreadyExists(string name) {
            return this.userManager.userNameAlreadyExists(name);
        }

        public bool mailAlreadyExists(string mail) {
            return this.userManager.mailAlreadyExists(mail);
        }

        public List<Entities.User> getAllUsers() {
            return this.userManager.getAllUsers();
        }

        public Entities.User FindUserByUserName(string entUser){
            return this.userManager.FindUserByUserName(entUser);
        }

        public bool editUser(Entities.User entUser)
        {
            return this.userManager.editUser(entUser);
        }
    }
}
