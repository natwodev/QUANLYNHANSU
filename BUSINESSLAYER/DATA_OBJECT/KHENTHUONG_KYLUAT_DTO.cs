using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUSINESSLAYER.DATA_OBJECT
{
    public class KHENTHUONG_KYLUAT_DTO
    {
        public string SOQD { get; set; }

        [StringLength(255)]
        public string NOIDUNG { get; set; }

        [Column(TypeName = "date")]
        public DateTime? NGAY { get; set; }

        [StringLength(10)]
        public string MANV { get; set; }

        public int? LOAI { get; set; }

        [StringLength(500)]
        public string LYDO { get; set; }

        [Column(TypeName = "date")]
        public DateTime? TUNGAY { get; set; }

        [Column(TypeName = "date")]
        public DateTime? DENNGAY { get; set; }
        public int? UPDATED { get; set; }
        public DateTime? UPDATED_DATE { get; set; }
        public int? CREATED { get; set; }
        public DateTime? CREATED_DATE { get; set; }
        public int? DELETED { get; set; }
        public DateTime? DELETED_DATE { get; set; }
        public string HOTEN { get; set; }
    }
}
