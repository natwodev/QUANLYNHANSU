namespace DATALAYER.context
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("HOPDONG")]
    public partial class HOPDONG
    {
        [Key]
        [StringLength(50)]
        public string SOHD { get; set; }

        public DateTime? NGAYBATDAU { get; set; }

        public DateTime? NGAYKETTHUC { get; set; }

        public DateTime? NGAYKY { get; set; }

        public string NOIDUNG { get; set; }

        [StringLength(50)]
        public string THOIHAN { get; set; }

        public double? HESOLUONG { get; set; }

        public int? LANKY { get; set; }

        [StringLength(10)]
        public string MANV { get; set; }

        public int? IDCT { get; set; }

        [StringLength(50)]
        public string DELETED { get; set; }

        public DateTime? DELETE_DATE { get; set; }

        [StringLength(50)]
        public string UPDATED { get; set; }

        public DateTime? UPDATE_DATE { get; set; }
        [StringLength(50)]
        public string CREATED { get; set; }

        public DateTime? CREATED_DATE { get; set; }

        public virtual CONGTY CONGTY { get; set; }

        public virtual NHANVIEN NHANVIEN { get; set; }
    }
}
