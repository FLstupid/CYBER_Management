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
    
    public partial class Hoadon_thucan
    {
        public Hoadon_thucan()
        {
            this.Chitiet_hoadon = new HashSet<Chitiet_hoadon>();
        }
    
        public int Id { get; set; }
        public System.DateTime Date { get; set; }
        public int Id_khachhang { get; set; }
        public int Id_nhanvien { get; set; }
        public int Total { get; set; }
    
        public virtual ICollection<Chitiet_hoadon> Chitiet_hoadon { get; set; }
        public virtual Khachhang Khachhang { get; set; }
        public virtual Nhanvien Nhanvien { get; set; }
    }
}
