﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SA45_TEAM01A_LibrarySystem
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class SA45TEAM01ALibraryEntities : DbContext
    {
        public SA45TEAM01ALibraryEntities()
            : base("name=SA45TEAM01ALibraryEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<booklist> booklists { get; set; }
        public virtual DbSet<Issue_Details> Issue_Details { get; set; }
        public virtual DbSet<Librarian> Librarians { get; set; }
        public virtual DbSet<User> Users { get; set; }
    }
}
