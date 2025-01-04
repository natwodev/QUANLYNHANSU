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
        [Key]
        public int IDLC { get; set; }

        [StringLength(100)]
        public string TENLC { get; set; }

        public double? HESO { get; set; }
    }
}
