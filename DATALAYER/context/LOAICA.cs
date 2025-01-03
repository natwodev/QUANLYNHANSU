namespace DATALAYER.context
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("LOAICA")]
    public partial class LOAICA
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public LOAICA()
        {
            TANGCAs = new HashSet<TANGCA>();
        }

        [Key]
        public int IDLOAICA { get; set; }

        [StringLength(100)]
        public string TENLOAICA { get; set; }

        public double? HESO { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TANGCA> TANGCAs { get; set; }
    }
}
