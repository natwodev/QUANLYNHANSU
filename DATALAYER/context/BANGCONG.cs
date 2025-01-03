namespace DATALAYER.context
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("BANGCONG")]
    public partial class BANGCONG
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(10)]
        public string MANV { get; set; }

        public int? NAM { get; set; }

        public int? THANG { get; set; }

        [Key]
        [Column(Order = 1, TypeName = "date")]
        public DateTime NGAY { get; set; }

        public DateTime? THOIGIANVAO { get; set; }

        public DateTime? THOIGIANRA { get; set; }

        public int? IDLC { get; set; }

        public virtual LOAICONG LOAICONG { get; set; }

        public virtual NHANVIEN NHANVIEN { get; set; }
    }
}
