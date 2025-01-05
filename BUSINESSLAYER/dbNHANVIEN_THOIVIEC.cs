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
    public class dbNHANVIEN_THOIVIEC
    {


        QLNHANSU db = new QLNHANSU();
        public NHANVIEN_THOIVIEC getItem(string id)
        {
            return db.NHANVIEN_THOIVIEC.FirstOrDefault(x => x.SOQD == id);
        }


        public List<NHANVIEN_THOIVIEC> getList()
        {
            return db.NHANVIEN_THOIVIEC.ToList();
        }

        public List<NHANVIEN_THOIVIEC_DTO> getListFull()
        {
            List<NHANVIEN_THOIVIEC> listNVTV = db.NHANVIEN_THOIVIEC.ToList();
            List<NHANVIEN_THOIVIEC_DTO> listDTO = new List<NHANVIEN_THOIVIEC_DTO>();
            NHANVIEN_THOIVIEC_DTO nvtv;
            foreach (var item in listNVTV)
            {
                nvtv = new NHANVIEN_THOIVIEC_DTO();
                nvtv.SOQD = item.SOQD;
                nvtv.NGAYNOPDON = item.NGAYNOPDON;
                nvtv.NGAYNGHI = item.NGAYNGHI;
                nvtv.LYDO = item.LYDO;
                nvtv.GHICHU = item.GHICHU;
                nvtv.MANV = item.MANV;
                nvtv.UPDATED = item.UPDATED;
                nvtv.UPDATED_DATE = item.UPDATED_DATE;
                nvtv.CREATED = item.CREATED;
                nvtv.CREATED_DATE = item.CREATED_DATE;
                nvtv.DELETED = item.DELETED;
                nvtv.DELETED_DATE = item.DELETED_DATE;

                nvtv.HOTEN = db.NHANVIENs.FirstOrDefault(x => x.MANV == item.MANV).HOTEN;
                listDTO.Add(nvtv);
            }
            return listDTO;
        }


        public NHANVIEN_THOIVIEC Add(NHANVIEN_THOIVIEC nvtv)
        {
            try
            {
                db.NHANVIEN_THOIVIEC.Add(nvtv);
                db.SaveChanges();
                return nvtv;
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi :" + ex.Message);
            }
        }


        public NHANVIEN_THOIVIEC Update(NHANVIEN_THOIVIEC nvtv)
        {
            try
            {
                var _nvtv = db.NHANVIEN_THOIVIEC.FirstOrDefault(x => x.SOQD == nvtv.SOQD);
                _nvtv.NGAYNOPDON = nvtv.NGAYNOPDON;
                _nvtv.NGAYNGHI = nvtv.NGAYNGHI;
                _nvtv.LYDO = nvtv.LYDO;
                _nvtv.GHICHU = nvtv.GHICHU;
                _nvtv.MANV = nvtv.MANV;
                _nvtv.UPDATED = nvtv.UPDATED;
                _nvtv.UPDATED_DATE = nvtv.UPDATED_DATE;
                db.SaveChanges();
                return nvtv;
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi :" + ex.Message);
            }
        }

        public void Delete(string id, string _user)
        {
            try
            {
                var _nvtv = db.NHANVIEN_THOIVIEC.FirstOrDefault(x => x.SOQD == id);
                _nvtv.DELETED = _user;
                _nvtv.DELETED_DATE = DateTime.Now;
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi: " + ex.Message);
            }
        }

    }
}
