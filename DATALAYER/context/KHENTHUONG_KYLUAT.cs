namespace DATALAYER.context
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class KHENTHUONG_KYLUAT
    {
        [Key]
        [StringLength(50)]
        public string SOQD { get; set; }

        [StringLength(255)]
        public string NOIDUNG { get; set; }

        public DateTime? NGAY { get; set; }

        [StringLength(10)]
        public string MANV { get; set; }

        public int? LOAI { get; set; }

        [StringLength(500)]
        public string LYDO { get; set; }

        public DateTime? TUNGAY { get; set; }

        public DateTime? DENNGAY { get; set; }

        [StringLength(50)]
        public string DELETED { get; set; }

        public DateTime? DELETED_DATE { get; set; }

        [StringLength(50)]
        public string UPDATED { get; set; }

        public DateTime? UPDATED_DATE { get; set; }

        [StringLength(50)]
        public string CREATED { get; set; }

        public DateTime? CREATED_DATE { get; set; }

        public virtual NHANVIEN NHANVIEN { get; set; }
    }
}
