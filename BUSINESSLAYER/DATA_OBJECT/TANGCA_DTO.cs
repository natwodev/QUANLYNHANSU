using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUSINESSLAYER.DATA_OBJECT
{
    public class TANGCA_DTO
    {
        [Key]
        public int IDTC { get; set; }

        public int? NAM { get; set; }

        public int? THANG { get; set; }

        public int? NGAY { get; set; }

        public double? SOGIO { get; set; }

        [StringLength(500)]
        public string GHICHU { get; set; }


        [StringLength(10)]
        public string MANV { get; set; }

        public int? IDLOAICA { get; set; }

        public string HOTEN { get; set; }

        public string TENLOAICA { get; set; }

        public double? HESO { get; set; }

        [StringLength(50)]
        public string DELETED { get; set; }

        public DateTime? DELETED_DATE { get; set; }

        [StringLength(50)]
        public string CREATED { get; set; }

        public DateTime? CREATED_DATE { get; set; }

        [StringLength(50)]
        public string UPDATED { get; set; }

        public DateTime? UPDATED_DATE { get; set; }
    }
}
