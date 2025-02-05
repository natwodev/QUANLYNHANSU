namespace DATALAYER.context
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class NHANVIEN_THOIVIEC
    {
        [Key]
        [StringLength(50)]
        public string SOQD { get; set; }

        public DateTime? NGAYNOPDON { get; set; }

        public DateTime? NGAYNGHI { get; set; }

        [StringLength(200)]
        public string LYDO { get; set; }

        [StringLength(500)]
        public string GHICHU { get; set; }

        [StringLength(10)]
        public string MANV { get; set; }

        [StringLength(50)]
        public string UPDATED { get; set; }

        public DateTime? UPDATED_DATE { get; set; }

        [StringLength(50)]
        public string CREATED { get; set; }

        public DateTime? CREATED_DATE { get; set; }

        [StringLength(50)]
        public string DELETED { get; set; }

        public DateTime? DELETED_DATE { get; set; }

        public virtual NHANVIEN NHANVIEN { get; set; }
    }
}
