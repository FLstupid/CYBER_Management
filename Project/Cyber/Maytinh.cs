//------------------------------------------------------------------------------
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
    using System.Collections.Generic;
    
    public partial class Maytinh
    {
        public Maytinh()
        {
            this.Khachhangs = new HashSet<Khachhang>();
        }
    
        public int Id { get; set; }
        public string Status { get; set; }
        public int Time_use { get; set; }
        public int Id_Phongmay { get; set; }
    
        public virtual ICollection<Khachhang> Khachhangs { get; set; }
        public virtual Phongmay Phongmay { get; set; }
    }
}
