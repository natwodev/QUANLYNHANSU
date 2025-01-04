namespace DATALAYER.context
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("KYCONG")]
    public partial class KYCONG
    {
        public int ID { get; set; }

        public int? MAKYCONG { get; set; }

        public int? THANG { get; set; }

        public int? NAM { get; set; }

        public bool? KHOA { get; set; }

        public DateTime? NGAYTINHCONG { get; set; }

        public double? NGAYCONGTRONGTHANG { get; set; }

        public int? MACTY { get; set; }

        public bool? TRANGTHAI { get; set; }
    }
}
