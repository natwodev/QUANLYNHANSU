using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DATALAYER;
namespace BUSINESSLAYER
{
    public class dbNHANVIEN
    {
        QLNHANSUEntities db = new QLNHANSUEntities();
        public NHANVIEN getItem(string id)
        {
            return db.NHANVIENs.FirstOrDefault(x => x.MANV == id);
        }


        public List<NHANVIEN> getList()
        {
            return db.NHANVIENs.ToList();
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
                _nv.HOTEN = nv.HOTEN;
                _nv.GIOITINH = nv.GIOITINH;
              //  _nv.NGAYSINH = nv.NGAYSINH;
                _nv.DIENTHOAI = nv.DIENTHOAI;
                _nv.CCCD = nv.CCCD;
                _nv.DIACHI = nv.DIACHI;
                _nv.HINHANH = nv.HINHANH;

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
