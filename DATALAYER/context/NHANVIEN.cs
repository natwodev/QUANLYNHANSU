namespace DATALAYER.context
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("NHANVIEN")]
    public partial class NHANVIEN
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public NHANVIEN()
        {
            BANGCONG_NHANVIEN_CHITIET = new HashSet<BANGCONG_NHANVIEN_CHITIET>();
            BAOHIEMs = new HashSet<BAOHIEM>();
            HOPDONGs = new HashSet<HOPDONG>();
            KHENTHUONG_KYLUAT = new HashSet<KHENTHUONG_KYLUAT>();
            KYCONGCHITIETs = new HashSet<KYCONGCHITIET>();
            NHANVIEN_PHU = new HashSet<NHANVIEN_PHU>();
            NHANVIEN_THOIVIEC = new HashSet<NHANVIEN_THOIVIEC>();
            TAIKHOANs = new HashSet<TAIKHOAN>();
            TANGCAs = new HashSet<TANGCA>();
            UNGLUONGs = new HashSet<UNGLUONG>();
        }

        [Key]
        [StringLength(10)]
        public string MANV { get; set; }

        [StringLength(100)]
        public string HOTEN { get; set; }

        public bool? GIOITINH { get; set; }

        [Column(TypeName = "date")]
        public DateTime? NGAYSINH { get; set; }

        [StringLength(15)]
        public string DIENTHOAI { get; set; }

        [StringLength(12)]
        public string CCCD { get; set; }

        [StringLength(255)]
        public string DIACHI { get; set; }

        public byte[] HINHANH { get; set; }

        public int? IDPB { get; set; }

        public int? IDBP { get; set; }

        public int? IDCV { get; set; }

        public int? IDTD { get; set; }

        public int? IDDT { get; set; }

        public int? IDTG { get; set; }

        public int? IDCT { get; set; }

        public bool? THOIVIEC { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BANGCONG_NHANVIEN_CHITIET> BANGCONG_NHANVIEN_CHITIET { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BAOHIEM> BAOHIEMs { get; set; }

        public virtual BOPHAN BOPHAN { get; set; }

        public virtual CHUCVU CHUCVU { get; set; }

        public virtual CONGTY CONGTY { get; set; }

        public virtual DANTOC DANTOC { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HOPDONG> HOPDONGs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<KHENTHUONG_KYLUAT> KHENTHUONG_KYLUAT { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<KYCONGCHITIET> KYCONGCHITIETs { get; set; }

        public virtual PHONGBAN PHONGBAN { get; set; }

        public virtual TRINHDO TRINHDO { get; set; }

        public virtual TONGIAO TONGIAO { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<NHANVIEN_PHU> NHANVIEN_PHU { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<NHANVIEN_THOIVIEC> NHANVIEN_THOIVIEC { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TAIKHOAN> TAIKHOANs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TANGCA> TANGCAs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<UNGLUONG> UNGLUONGs { get; set; }
    }
}
