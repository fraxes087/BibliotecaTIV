﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class BiblioOnlineDbEntities : DbContext
    {
        public BiblioOnlineDbEntities()
            : base("name=BiblioOnlineDbEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public DbSet<Authors> Authors { get; set; }
        public DbSet<Genders> Genders { get; set; }
        public DbSet<Genres> Genres { get; set; }
        public DbSet<Publishers> Publishers { get; set; }
        public DbSet<Rent_States> Rent_States { get; set; }
        public DbSet<Rents> Rents { get; set; }
        public DbSet<UserRoles> UserRoles { get; set; }
        public DbSet<Users> Users { get; set; }
        public DbSet<Books> Books { get; set; }
    }
}
