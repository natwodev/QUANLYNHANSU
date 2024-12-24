namespace DATALAYER
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TAIKHOAN")]
    public partial class TAIKHOAN
    {
        [Key]
        public int IDTK { get; set; }

        [StringLength(50)]
        public string TENDANGNHAP { get; set; }

        [StringLength(255)]
        public string MATKHAU { get; set; }

        [StringLength(50)]
        public string QUYENHAN { get; set; }

        [StringLength(10)]
        public string MANV { get; set; }

        public virtual NHANVIEN NHANVIEN { get; set; }
    }
}
