namespace DATALAYER.context
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class NHANVIEN_PHU
    {
        [Key]
        public int IDNVP { get; set; }

        [StringLength(10)]
        public string MANV { get; set; }

        public int? IDPC { get; set; }

        [Column(TypeName = "date")]
        public DateTime? NGAY { get; set; }

        [StringLength(255)]
        public string NOIDUNG { get; set; }

        public double? SOTIEN { get; set; }

        public virtual NHANVIEN NHANVIEN { get; set; }

        public virtual PHUCAP PHUCAP { get; set; }
    }
}
