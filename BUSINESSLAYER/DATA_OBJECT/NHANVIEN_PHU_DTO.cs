using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUSINESSLAYER.DATA_OBJECT
{
    public class NHANVIEN_PHU_DTO
    {

        [Key]
        public int IDNVP { get; set; }

        [StringLength(10)]
        public string MANV { get; set; }

        public int? IDPC { get; set; }

        [Column(TypeName = "date")]
        public DateTime? NGAY { get; set; }

        [StringLength(255)]
        public string GHICHU { get; set; }

        [StringLength(100)]
        public string TENPC { get; set; }

        public double? SOTIEN { get; set; }

        [StringLength(50)]
        public string DELETED { get; set; }

        public DateTime? DELETED_DATE { get; set; }

        [StringLength(50)]
        public string CREATED { get; set; }

        public DateTime? CREATED_DATE { get; set; }

        [StringLength(50)]
        public string UPDATED { get; set; }

        public DateTime? UPDATED_DATE { get; set; }

        public string HOTEN { get; set; }
    }
}
