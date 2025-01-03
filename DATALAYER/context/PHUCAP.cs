namespace DATALAYER.context
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PHUCAP")]
    public partial class PHUCAP
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PHUCAP()
        {
            NHANVIEN_PHU = new HashSet<NHANVIEN_PHU>();
        }

        [Key]
        public int IDPC { get; set; }

        [StringLength(100)]
        public string TENPC { get; set; }

        public double? SOTIEN { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<NHANVIEN_PHU> NHANVIEN_PHU { get; set; }
    }
}
