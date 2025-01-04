using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BUSINESSLAYER.DATA_OBJECT;
using DATALAYER;
using DATALAYER.context;
namespace BUSINESSLAYER
{
    public class dbNHANVIEN
    {
        QLNHANSU db = new QLNHANSU();
        public NHANVIEN getItem(string id)
        {
            return db.NHANVIENs.FirstOrDefault(x => x.MANV == id);
        }


        public List<NHANVIEN> getList()
        {
            return db.NHANVIENs.ToList();
        }

        public List<NHANVIEN_DTO> getListFull()
        {
            var lstNV = db.NHANVIENs.ToList();
            List<NHANVIEN_DTO> lstDTO = new List<NHANVIEN_DTO>();
            NHANVIEN_DTO nvDTO;
            foreach (var item in lstNV)
            {
                nvDTO = new NHANVIEN_DTO();
                nvDTO.MANV = item.MANV;
                nvDTO.HOTEN = item.HOTEN;
                nvDTO.GIOITINH = item.GIOITINH;
                nvDTO.NGAYSINH = item.NGAYSINH;
                nvDTO.CCCD = item.CCCD;
                nvDTO.DIENTHOAI = item.DIENTHOAI;
                nvDTO.DIACHI = item.DIACHI;
                nvDTO.HINHANH = item.HINHANH;
                nvDTO.THOIVIEC = item.THOIVIEC;
                nvDTO.IDBP = item.IDBP;
                var bp = db.BOPHANs.FirstOrDefault(b => b.IDBP == item.IDBP);
                nvDTO.TENBP = bp?.TENBP;

                nvDTO.IDCV = item.IDCV;
                var cv = db.CHUCVUs.FirstOrDefault(b => b.IDCV == item.IDCV);
                nvDTO.TENCV = cv?.TENCV;

                nvDTO.IDPB = item.IDPB;
                var pb = db.PHONGBANs.FirstOrDefault(b => b.IDPB == item.IDPB);
                nvDTO.TENPB = pb?.TENPB;

                nvDTO.IDTD = item.IDTD;
                var td = db.TRINHDOes.FirstOrDefault(b => b.IDTD == item.IDTD);
                nvDTO.TENTD = td?.TENTD;

                nvDTO.IDDT = item.IDDT;
                var dt = db.DANTOCs.FirstOrDefault(b => b.IDDT == item.IDDT);
                nvDTO.TENDT = dt?.TENDT;

                nvDTO.IDTG = item.IDTG;
                var tg = db.TONGIAOs.FirstOrDefault(b => b.IDTG == item.IDTG);
                nvDTO.TENTG = tg?.TENTG;


                lstDTO.Add(nvDTO);
            }
            return lstDTO;
        }

        public NHANVIEN Add(NHANVIEN nv)
        {
            try
            {
                db.NHANVIENs.Add(nv);
                db.SaveChanges();
                return nv;
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi :" + ex.Message);
            }
        }


        public NHANVIEN Update(NHANVIEN nv)
        {
            try
            {
                var _nv = db.NHANVIENs.FirstOrDefault(x => x.MANV == nv.MANV);
                if (_nv == null)
                {
                    throw new Exception("Không tìm thấy nhân viên với mã " + nv.MANV);
                }
                _nv.HOTEN = nv.HOTEN;
                _nv.GIOITINH = nv.GIOITINH;
                _nv.NGAYSINH = nv.NGAYSINH;
                _nv.DIENTHOAI = nv.DIENTHOAI;
                _nv.CCCD = nv.CCCD;
                _nv.DIACHI = nv.DIACHI;
                _nv.HINHANH = nv.HINHANH;
                _nv.THOIVIEC = nv.THOIVIEC;
                _nv.IDPB = nv.IDPB;//phòng ban
                _nv.IDTD = nv.IDTD; //trình độ
                _nv.IDBP = nv.IDBP; //bộ phận
                _nv.IDCV = nv.IDCV; //chức vụ 
                _nv.IDDT = nv.IDDT; //dân tộc
                _nv.IDTG = nv.IDTG; //tôn giáo
                _nv.IDCT = nv.IDCT; //công ty

                db.SaveChanges();
                return nv;
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi :" + ex.Message);
            }
        }


      
        public void Delete(string id)
        {
            try
            {
                var _nv = db.NHANVIENs.FirstOrDefault(x => x.MANV == id);
                db.NHANVIENs.Remove(_nv);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi :" + ex.Message);
            }

        }
    }
}
