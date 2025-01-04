using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUSINESSLAYER.DATA_OBJECT
{
    public class HOPDONG_DTO
    {
       

        

        public string SOHD { get; set; }

        public DateTime? NGAYBATDAU { get; set; }

        public DateTime? NGAYKETTHUC { get; set; }

        public DateTime? NGAYKY { get; set; }

        public string NOIDUNG { get; set; }

        [StringLength(50)]
        public string THOIHAN { get; set; }

        public double? HESOLUONG { get; set; }

        public int? LANKY { get; set; }

        [StringLength(10)]
        public string MANV { get; set; }

        public int? IDCT { get; set; }

        [StringLength(50)]
        public string DELETED { get; set; }

        public DateTime? DELETE_DATE { get; set; }

        [StringLength(50)]
        public string UPDATED { get; set; }

        public DateTime? UPDATE_DATE { get; set; }
        [StringLength(50)]
        public string CREATED { get; set; }

        public DateTime? CREATED_DATE { get; set; }

        public int? IDTD { get; set; }

        public string TENTD { set; get; }
        public string TENCT { set; get; }
        public string HOTEN { set; get; }
        public string CCCD { set; get; }
        public string DIENTHOAI { set; get; }
        public string DIACHINV { set; get; }
        public string DIACHICT { set; get; }
        public string TENNVLAP { set; get; }
        public string TENPB { set; get; }
        public string TENCV { set; get; }
        public string TENBP { set; get; }


        public string DIENTHOAICT { set; get; }


    }
}
