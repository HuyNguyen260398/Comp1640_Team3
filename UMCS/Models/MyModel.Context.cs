﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace UMCS.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class UMCSEntities : DbContext
    {
        public UMCSEntities()
            : base("name=UMCSEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Administrator> Administrators { get; set; }
        public virtual DbSet<ClosureDate> ClosureDates { get; set; }
        public virtual DbSet<Contribution> Contributions { get; set; }
        public virtual DbSet<Faculty> Faculties { get; set; }
        public virtual DbSet<Faculty1> Faculties1 { get; set; }
        public virtual DbSet<MarketingManager> MarketingManagers { get; set; }
        public virtual DbSet<Student> Students { get; set; }
    }
}
