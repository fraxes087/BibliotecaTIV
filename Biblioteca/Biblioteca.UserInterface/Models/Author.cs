using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;

namespace Biblioteca.UserInterface.Models
{
    public class Author
    {
        [Key]
        public int id_author { get; set; }
        [Required]
        public string last_name { get; set; }
        [Required]
        public string first_name { get; set; }

        public Author() {
            this.id_author = 0;
            this.last_name = string.Empty;
            this.first_name = string.Empty;
        }
        public Author(int id, string name, string last_name)
        {
            this.id_author = id;
            this.last_name = last_name;
            this.first_name = name;
        }

    }
}