using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Data
{
    public class UserManager : BiblioDbManager
    {
        public UserManager() : base() {}

        public bool registerNewUser(Entities.User entUser) {
            try
            {
                var userExists = this.db.Set<Users>().Where(x => x.username == entUser.username).FirstOrDefault();
                if (userExists == null)
                {
                    Users dbUser = new Users();
                    var role = this.db.Set<UserRoles>().Where(x => x.description == "client").FirstOrDefault();
                    dbUser.username = entUser.username;
                    dbUser.password = entUser.password;
                    dbUser.first_name = entUser.first_name;
                    dbUser.last_name = entUser.last_name;
                    dbUser.id_gender = entUser.gender.id_gender;
                    dbUser.mail = entUser.mail;
                    dbUser.birthDate = entUser.birthDate;
                    dbUser.id_role = role.id_role;
                    dbUser.date_sign = System.DateTime.Now;
                    this.db.Users.Add(dbUser);
                    this.db.SaveChanges();
                    return true;
                }
                else {
                    return false;
                }
            }
            catch (Exception ex) {
                throw new Exception(ex.Message);
            }
            
        }

        public bool userNameAlreadyExists(string name) {
            var exists = this.db.Set<Users>().Where(x => x.username == name).FirstOrDefault();
            if (exists != null)
                return true;
            else
                return false;
        }

        public bool mailAlreadyExists(string mail)
        {
            var exists = this.db.Set<Users>().Where(x => x.mail == mail).FirstOrDefault();
            if (exists != null)
                return true;
            else
                return false;
        }

        public List<Entities.User> getAllUsers() {
            var userList = this.db.Set<Users>().ToList();
            List<Entities.User> entUserList = new List<Entities.User>();
            foreach (var curUser in userList) {
                entUserList.Add(dbToUser(curUser));
            }
            return entUserList;
        }

        public Entities.User FindUserByUserName(string entUser) {
            Users user = this.db.Set<Users>().Where(x => x.username == entUser).FirstOrDefault();
            if (user != null) {
                return dbToUser(user);
            }
            return null;
        }

        private Entities.User dbToUser(Users dbUser) {
            Entities.UserRole userRole = new Entities.UserRole();
            userRole.Id_userRole = dbUser.id_role;
            userRole.description = dbUser.UserRoles.description;
            //TODO: hacer que funcione esto
            Entities.User entUser = new Entities.User();
            entUser.id_user = dbUser.id_user; 
            entUser.username = dbUser.username;
            entUser.password = dbUser.password;
            entUser.first_name = dbUser.first_name;
            entUser.last_name = dbUser.last_name;
            entUser.role = userRole;
            var dbGender = this.db.Set<Genders>().Where(x => x.id_gender == dbUser.id_gender).FirstOrDefault();
            entUser.gender.id_gender = dbGender.id_gender;
            entUser.gender.description = dbGender.description;
            entUser.birthDate = dbUser.birthDate != null ? dbUser.birthDate : null;
            entUser.mail = dbUser.mail;
            return entUser;
        }
    }
}
