namespace DATALAYER.context
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TANGCA")]
    public partial class TANGCA
    {
        [Key]
        public int IDTC { get; set; }

        public int? NAM { get; set; }

        public int? THANG { get; set; }

        [Column(TypeName = "date")]
        public DateTime? NGAY { get; set; }

        public double? SOGIO { get; set; }

        [StringLength(10)]
        public string MANV { get; set; }

        public int? IDLOAICA { get; set; }

        public virtual LOAICA LOAICA { get; set; }

        public virtual NHANVIEN NHANVIEN { get; set; }
    }
}
