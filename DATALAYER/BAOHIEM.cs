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
    
    public partial class BAOHIEM
    {
        public int IDBH { get; set; }
        public Nullable<System.DateTime> NGAYCAP { get; set; }
        public string NOICAP { get; set; }
        public string NOIDUNG { get; set; }
        public Nullable<int> MANV { get; set; }
    
        public virtual NHANVIEN NHANVIEN { get; set; }
    }
}
