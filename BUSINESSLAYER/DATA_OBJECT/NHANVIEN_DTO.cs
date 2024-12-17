using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DATALAYER;

namespace BUSINESSLAYER.DATA_OBJECT
{
    public class NHANVIEN_DTO
    {
        public string MANV { get; set; }
        public string HOTEN { get; set; }
        public Nullable<bool> GIOITINH { get; set; }
        public Nullable<System.DateTime> NGAYSINH { get; set; }
        public string DIENTHOAI { get; set; }
        public string CCCD { get; set; }
        public string DIACHI { get; set; }
        public byte[] HINHANH { get; set; }
        public Nullable<int> IDPB { get; set; }
        public string TENPB { set; get; }
        public Nullable<int> IDBP { get; set; }
        public string TENBP { set; get; }
        public Nullable<int> IDCV { get; set; }
        public string TENCV { set; get; }
        public Nullable<int> IDTD { get; set; }
        public string TENTD { set; get; }
        public Nullable<int> IDDT { get; set; }
        public string TENDT { set; get; }
        public Nullable<int> IDTG { get; set; }
        public string TENTG { set; get; }
        public Nullable<int> IDCT { get; set; }
        public string TENCT { set; get; }

    }
}
