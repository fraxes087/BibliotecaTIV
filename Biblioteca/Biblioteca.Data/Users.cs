//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Biblioteca.Data
{
    using System;
    using System.Collections.Generic;
    
    public partial class Users
    {
        public Users()
        {
            this.Rents = new HashSet<Rents>();
        }
    
        public int id_user { get; set; }
        public string first_name { get; set; }
        public int id_role { get; set; }
        public int id_gender { get; set; }
        public string mail { get; set; }
        public Nullable<System.DateTime> birthDate { get; set; }
        public System.DateTime date_sign { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string last_name { get; set; }
    
        public virtual Genders Genders { get; set; }
        public virtual ICollection<Rents> Rents { get; set; }
        public virtual UserRoles UserRoles { get; set; }
    }
}
