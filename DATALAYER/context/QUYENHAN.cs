namespace DATALAYER.context
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("QUYENHAN")]
    public partial class QUYENHAN
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public QUYENHAN()
        {
            TAIKHOANs = new HashSet<TAIKHOAN>();
        }

        [Key]
        public int IDQUYEN { get; set; }

        [StringLength(50)]
        public string TENQUYEN { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TAIKHOAN> TAIKHOANs { get; set; }
    }
}
