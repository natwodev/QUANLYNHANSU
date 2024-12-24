namespace DATALAYER
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CONGTY")]
    public partial class CONGTY
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CONGTY()
        {
            HOPDONGs = new HashSet<HOPDONG>();
            NHANVIENs = new HashSet<NHANVIEN>();
        }

        [Key]
        public int IDCT { get; set; }

        [StringLength(100)]
        public string TENCT { get; set; }

        [StringLength(15)]
        public string DIENTHOAI { get; set; }

        [StringLength(100)]
        public string EMAIL { get; set; }

        [StringLength(500)]
        public string DIACHI { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HOPDONG> HOPDONGs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<NHANVIEN> NHANVIENs { get; set; }
    }
}
