namespace DATALAYER.context
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class BANGCONG_NHANVIEN_CHITIET
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID { get; set; }

        public int? MAKYCONG { get; set; }

        public int? MACTY { get; set; }

        [StringLength(10)]
        public string MANV { get; set; }

        [StringLength(100)]
        public string HOTEN { get; set; }

        public DateTime? NGAY { get; set; }

        [StringLength(50)]
        public string THU { get; set; }

        [StringLength(50)]
        public string GIOVAO { get; set; }

        [StringLength(50)]
        public string GIORA { get; set; }

        public double? NGAYPHEP { get; set; }

        public double? CONGNGAYLE { get; set; }

        public double? CONGCHUNHAT { get; set; }

        [StringLength(50)]
        public string KYHIEU { get; set; }

        [StringLength(500)]
        public string GHICHU { get; set; }

        public int? CREATED_BY { get; set; }

        public DateTime? CREATED_DATE { get; set; }

        public int? UPDATED_BY { get; set; }

        public DateTime? UPDATED_DATE { get; set; }

        public virtual NHANVIEN NHANVIEN { get; set; }
    }
}
