using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DATALAYER;

namespace BUSINESSLAYER.DATA_OBJECT
{
    public class TAIKHOAN_DTO
    {
        public int IDTK { get; set; }

        [StringLength(50)]
        public string TENDANGNHAP { get; set; }

        [StringLength(255)]
        public string MATKHAU { get; set; }

        public int? IDQUYEN { get; set; }

        [StringLength(10)]
        public string MANV { get; set; }

        public bool? TRANGTHAI { get; set; }

        public DateTime? LAST_LOGIN { get; set; }

        public virtual NHANVIEN NHANVIEN { get; set; }

        public virtual QUYENHAN QUYENHAN { get; set; }

        public string HOTEN { get; set; }

        public string TENQUYEN { get; set; }
    }
}
