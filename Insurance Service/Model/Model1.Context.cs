﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Insurance_Service.Model
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class CTPBDEntities7 : DbContext
    {
        public CTPBDEntities7()
            : base("name=CTPBDEntities7")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Admin> Admin { get; set; }
        public virtual DbSet<brand> brand { get; set; }
        public virtual DbSet<Car> Car { get; set; }
        public virtual DbSet<Client> Client { get; set; }
        public virtual DbSet<contract> contract { get; set; }
        public virtual DbSet<Law> Law { get; set; }
        public virtual DbSet<Model> Model { get; set; }
        public virtual DbSet<STS> STS { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
    }
}
