﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DataModel.PetHotelORM
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class PTContext : DbContext
    {
        public PTContext()
            : base("name=PTContext")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<customer> customer { get; set; }
        public virtual DbSet<employee> employee { get; set; }
        public virtual DbSet<reservation> reservation { get; set; }
        public virtual DbSet<species> species { get; set; }
        public virtual DbSet<vContactList> vContactList { get; set; }
        public virtual DbSet<vEmployeeList> vEmployeeList { get; set; }
        public virtual DbSet<vInvoiceList> vInvoiceList { get; set; }
        public virtual DbSet<vPetList> vPetList { get; set; }
        public virtual DbSet<vPriceList> vPriceList { get; set; }
    }
}