using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUSINESSLAYER.DATA_OBJECT
{
    public class HOPDONG_DTO
    {
        public string SOHD { get; set; }
        public Nullable<System.DateTime> NGAYBATDAU { get; set; }
        public Nullable<System.DateTime> NGAYKETTHUC { get; set; }
        public Nullable<System.DateTime> NGAYKY { get; set; }
        public string NOIDUNG { get; set; }
        public string THOIHAN { get; set; }
        public Nullable<double> HESOLUONG { get; set; }
        public Nullable<int> LANKY { get; set; }
        public string MANV { get; set; }
        public Nullable<int> IDCT { get; set; }
        public Nullable<int> DELETED { get; set; }
        public Nullable<System.DateTime> DELETE_DATE { get; set; }
        public Nullable<int> UPDATED { get; set; }
        public Nullable<System.DateTime> UPDATE_DATE { get; set; }
        public Nullable<int> CREATED { get; set; }
        public Nullable<System.DateTime> CREATED_DATE { get; set; }

        public string HOTEN { set; get; }
        public string CCCD { set; get; }
        public string DIENTHOAI { set; get; }
        public string DIACHI { set; get; }
    }
}
