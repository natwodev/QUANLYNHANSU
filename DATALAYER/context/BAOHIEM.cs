namespace DATALAYER.context
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("BAOHIEM")]
    public partial class BAOHIEM
    {
        [Key]
        public int IDBH { get; set; }

        [Column(TypeName = "date")]
        public DateTime? NGAYCAP { get; set; }

        [StringLength(100)]
        public string NOICAP { get; set; }

        [StringLength(255)]
        public string NOIDUNG { get; set; }

        [StringLength(10)]
        public string MANV { get; set; }

        public virtual NHANVIEN NHANVIEN { get; set; }
    }
}
