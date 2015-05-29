using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Biblioteca.UserInterface.Models
{
    public class Gender
    {
        public int id_gender { get; set; }
        public string description { get; set; }

        public Gender() {
            this.id_gender = 0;
            this.description = string.Empty;
        }
        public Gender(int id, string desc) {
            this.id_gender = id;
            this.description = desc;
        }
    }
}