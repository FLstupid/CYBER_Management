﻿//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Tiệm_nét
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class Cyber_netEntities : DbContext
    {
        public Cyber_netEntities()
            : base("name=Cyber_netEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        private DbSet<Chinhanh> Chinhanhs { get; set; }
        private DbSet<Chitiet_hoadon> Chitiet_hoadon { get; set; }
        private DbSet<District> Districts { get; set; }
        private DbSet<Hoadon> Hoadons { get; set; }
        private DbSet<Hoadon_thucan> Hoadon_thucan { get; set; }
        private DbSet<Khachhang> Khachhangs { get; set; }
        private DbSet<Maytinh> Maytinhs { get; set; }
        private DbSet<Nhanvien> Nhanviens { get; set; }
        private DbSet<Phongmay> Phongmays { get; set; }
        private DbSet<sysdiagram> sysdiagrams { get; set; }
        private DbSet<Thucan> Thucans { get; set; }
    }
}
