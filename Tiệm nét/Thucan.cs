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
    
    public partial class Thucan
    {
        public Thucan()
        {
            this.Chitiet_hoadon = new HashSet<Chitiet_hoadon>();
        }
    
        public int Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
    
        public virtual ICollection<Chitiet_hoadon> Chitiet_hoadon { get; set; }
    }
}
