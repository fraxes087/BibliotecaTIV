using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Biblioteca.UserInterface.Models
{
    public class UserRole
    {
        public int id_role { get; set; }
        public string description { get; set; }


        public UserRole() {
            this.id_role = 0;
            this.description = string.Empty;
        }
        public UserRole(int id, string desc) {
            this.id_role = id;
            this.description = desc;
        }
    }
}