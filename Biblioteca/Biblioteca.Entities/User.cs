using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Entities
{
    public class User
    {
        public int id_user { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public UserRole role { get; set; }
        public Gender gender { get; set; }
        public string mail { get; set; }
        public DateTime? birthDate { get; set; }
        public DateTime date_sign { get; set; }

        public User()
        {
            this.id_user = 0;
            this.username = string.Empty;
            this.password = string.Empty;
            this.first_name = string.Empty;
            this.last_name = string.Empty;
            this.role = new UserRole();
            this.gender = new Gender();
            this.birthDate = DateTime.MinValue;
            this.date_sign = DateTime.Now;
        }

        public User(int id_user, string username, string password, string first_name, string last_name, UserRole role, Gender gender, DateTime? birthDate, string mail)
        {
            this.id_user = id_user;
            this.username = username;
            this.password = password;
            this.first_name = first_name;
            this.last_name = last_name;
            this.role = role; ;
            this.gender = gender;
            this.birthDate = birthDate;
            this.mail = mail;
            this.date_sign = DateTime.Now;
        }
    }
}
