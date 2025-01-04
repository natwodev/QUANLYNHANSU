using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DATALAYER;
using DATALAYER.context;
namespace BUSINESSLAYER
{
    public class dbTHOIVIEC
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
      
        public void Delete(string id,int iduser)
        {
            try
            {
                var _nvtv = db.NHANVIEN_THOIVIEC.FirstOrDefault(x => x.SOQD == id); 
                _nvtv.DETETED = iduser;
                _nvtv.DETETED_DATE  = DateTime.Now;
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi: " + ex.Message);
            }
        }

    }
}
