//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DATALAYER
{
    using System;
    using System.Collections.Generic;
    
    public partial class BANGCONG
    {
        public string MANV { get; set; }
        public Nullable<int> NAM { get; set; }
        public Nullable<int> THANG { get; set; }
        public System.DateTime NGAY { get; set; }
        public Nullable<System.DateTime> THOIGIANVAO { get; set; }
        public Nullable<System.DateTime> THOIGIANRA { get; set; }
        public Nullable<int> IDLC { get; set; }
    
        public virtual LOAICONG LOAICONG { get; set; }
        public virtual NHANVIEN NHANVIEN { get; set; }
    }
}
