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
    
    public partial class Rent_States
    {
        public Rent_States()
        {
            this.Rents = new HashSet<Rents>();
        }
    
        public int id_state { get; set; }
        public string description { get; set; }
    
        public virtual ICollection<Rents> Rents { get; set; }
    }
}
