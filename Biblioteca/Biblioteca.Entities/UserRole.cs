using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Entities
{
    public class UserRole
    {
        public int Id_userRole { get; set; }
        public string description { get; set; }

        public UserRole() {
            this.Id_userRole = 0;
            this.description = string.Empty;
        }

        public UserRole(int id, string desc) {
            this.Id_userRole = id;
            this.description = desc;
        }
    }
}
