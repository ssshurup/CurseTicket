﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CurseTicket
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class AirTicketsEntities : DbContext
    {
        public AirTicketsEntities()
            : base("name=AirTicketsEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<airport> airport { get; set; }
        public virtual DbSet<country> country { get; set; }
        public virtual DbSet<discount> discount { get; set; }
        public virtual DbSet<employee> employee { get; set; }
        public virtual DbSet<flight> flight { get; set; }
        public virtual DbSet<party> party { get; set; }
        public virtual DbSet<post> post { get; set; }
        public virtual DbSet<role> role { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<ticket> ticket { get; set; }
        public virtual DbSet<users> users { get; set; }
        public virtual DbSet<airplane> airplane { get; set; }
    }
}