namespace DATALAYER.context
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("KYCONGCHITIET")]
    public partial class KYCONGCHITIET
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MAKYCONG { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(10)]
        public string MANV { get; set; }

        [StringLength(100)]
        public string HOTEN { get; set; }

        public int? MACTY { get; set; }

        [StringLength(10)]
        public string D1 { get; set; }

        [StringLength(10)]
        public string D2 { get; set; }

        [StringLength(10)]
        public string D3 { get; set; }

        [StringLength(10)]
        public string D4 { get; set; }

        [StringLength(10)]
        public string D5 { get; set; }

        [StringLength(10)]
        public string D6 { get; set; }

        [StringLength(10)]
        public string D7 { get; set; }

        [StringLength(10)]
        public string D8 { get; set; }

        [StringLength(10)]
        public string D9 { get; set; }

        [StringLength(10)]
        public string D10 { get; set; }

        [StringLength(10)]
        public string D11 { get; set; }

        [StringLength(10)]
        public string D12 { get; set; }

        [StringLength(10)]
        public string D13 { get; set; }

        [StringLength(10)]
        public string D14 { get; set; }

        [StringLength(10)]
        public string D15 { get; set; }

        [StringLength(10)]
        public string D16 { get; set; }

        [StringLength(10)]
        public string D17 { get; set; }

        [StringLength(10)]
        public string D18 { get; set; }

        [StringLength(10)]
        public string D19 { get; set; }

        [StringLength(10)]
        public string D20 { get; set; }

        [StringLength(10)]
        public string D21 { get; set; }

        [StringLength(10)]
        public string D22 { get; set; }

        [StringLength(10)]
        public string D23 { get; set; }

        [StringLength(10)]
        public string D24 { get; set; }

        [StringLength(10)]
        public string D25 { get; set; }

        [StringLength(10)]
        public string D26 { get; set; }

        [StringLength(10)]
        public string D27 { get; set; }

        [StringLength(10)]
        public string D28 { get; set; }

        [StringLength(10)]
        public string D29 { get; set; }

        [StringLength(10)]
        public string D30 { get; set; }

        [StringLength(10)]
        public string D31 { get; set; }

        public double? NGAYCONG { get; set; }

        public double? NGAYPHEP { get; set; }

        public double? NGHIKHONGPHEP { get; set; }

        public double? CONGNGAYLE { get; set; }

        public double? CONGCHUNHAT { get; set; }

        public double? TONGNGAYCONG { get; set; }

        public virtual NHANVIEN NHANVIEN { get; set; }
    }
}
