namespace DATALAYER.context
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("LOAICONG")]
    public partial class LOAICONG
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public LOAICONG()
        {
            BANGCONGs = new HashSet<BANGCONG>();
        }

        [Key]
        public int IDLC { get; set; }

        [StringLength(100)]
        public string TENLC { get; set; }

        public double? HESO { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BANGCONG> BANGCONGs { get; set; }
    }
}
