using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Biblioteca.UserInterface.Models
{
    public class Publisher
    {
        public int id_publisher { get; set; }
        public string full_name { get; set; }

        public Publisher()
        {
            this.id_publisher = 0;
            this.full_name = string.Empty;
        }
        public Publisher(int id, string name)
        {
            this.id_publisher = id;
            this.full_name = name;
        }
    }
}