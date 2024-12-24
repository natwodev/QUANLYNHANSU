namespace DATALAYER
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class KHENTHUONG_KYLUAT
    {
        [Key]
        public int IDKTKL { get; set; }

        public int? SOTK { get; set; }

        [StringLength(255)]
        public string NOIDUNG { get; set; }

        [Column(TypeName = "date")]
        public DateTime? NGAY { get; set; }

        [StringLength(10)]
        public string MANV { get; set; }

        [StringLength(50)]
        public string LOAI { get; set; }

        public virtual NHANVIEN NHANVIEN { get; set; }
    }
}
