namespace DATALAYER.context
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("UNGLUONG")]
    public partial class UNGLUONG
    {
        [Key]
        public int IDUL { get; set; }

        public int? NAM { get; set; }

        public int? THANG { get; set; }

        [Column(TypeName = "date")]
        public DateTime? NGAY { get; set; }

        public double? SOTIEN { get; set; }

        [StringLength(50)]
        public string TRANGTHAI { get; set; }

        [StringLength(10)]
        public string MANV { get; set; }

        public virtual NHANVIEN NHANVIEN { get; set; }
    }
}
