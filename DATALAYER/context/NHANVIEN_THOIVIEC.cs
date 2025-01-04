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

        public string LYDO { get; set; }

        public string GHICHU { get; set; }

        [StringLength(10)]
        public string MANV { get; set; }

        public int? UPDATED { get; set; }
        public DateTime? UPDATED_DATE { get; set; }
        public int? CREATED { get; set; }
        public DateTime? CREATED_DATE { get; set; }
        public int? DETETED { get; set; }
        public DateTime? DETETED_DATE { get; set; }
    }
}
