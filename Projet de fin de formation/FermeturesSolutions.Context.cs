﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Projet_de_fin_de_formation
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class fermeturesSolutionsEntities : DbContext
    {
        public fermeturesSolutionsEntities()
            : base("name=fermeturesSolutionsEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Chantier> Chantiers { get; set; }
        public virtual DbSet<Congee> Congees { get; set; }
        public virtual DbSet<DemangdeAug> DemangdeAugS { get; set; }
        public virtual DbSet<Depatement> Depatements { get; set; }
        public virtual DbSet<EmployeeTable> EmployeeTables { get; set; }
        public virtual DbSet<UserTable> UserTables { get; set; }
        public virtual DbSet<Client> Clients { get; set; }
        public virtual DbSet<reclamation> reclamations { get; set; }
    }
}