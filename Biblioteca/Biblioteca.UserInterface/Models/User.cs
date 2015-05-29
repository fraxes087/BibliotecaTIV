using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.Entity;
using System.Web.Security;
using System.ComponentModel.DataAnnotations;

namespace Biblioteca.UserInterface.Models
{
    public class User
    {
        [Key]
        public int id_user { get; set; }
        [Required]
        [MaxLength(50)]
        [MinLength(4)]
        public string username { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 4)]
        [DataType(DataType.Password)]
        public string password { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 4)]
        [DataType(DataType.Password)]
        [Compare("password", ErrorMessage = "Pass Missmatch")]
        public string valPass { get; set; }
        [Required]
        public string first_name { get; set; }
        [Required]
        public string last_name { get; set; }
        public UserRole role { get; set; }
        [Required]
        public Gender gender { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        [RegularExpression(
            "^([a-zA-Z0-9_\\-\\.]+)@[a-z0-9-]+(\\.[a-z0-9-]+)*(\\.[a-z]{2,3})$",
            ErrorMessage = "Email is not a valid email address.")
        ]
        public string mail { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? birthDate { get; set; }
        public DateTime date_sign { get; set; }

        public User() {
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
            this.date_sign = DateTime.Now;
            this.mail = mail;
        }

    }
}