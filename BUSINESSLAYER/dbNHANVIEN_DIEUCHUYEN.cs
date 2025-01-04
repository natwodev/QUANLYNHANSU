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
    public class dbNHANVIEN_DIEUCHUYEN
    {


        QLNHANSU db = new QLNHANSU();
        public NHANVIEN_DIEUCHUYEN getItem(string id)
        {
            return db.NHANVIEN_DIEUCHUYEN.FirstOrDefault(x => x.SOQD == id);
        }


        public List<NHANVIEN_DIEUCHUYEN> getList()
        {
            return db.NHANVIEN_DIEUCHUYEN.ToList();
        }

        public List<NHANVIEN_DIEUCHUYEN_DTO> getListFull()
        {
            List<NHANVIEN_DIEUCHUYEN> listNVDC = db.NHANVIEN_DIEUCHUYEN.ToList();
            List<NHANVIEN_DIEUCHUYEN_DTO> listDTO = new List<NHANVIEN_DIEUCHUYEN_DTO>();
            NHANVIEN_DIEUCHUYEN_DTO nvdc;
            foreach (var item in listNVDC)
            {
                nvdc = new NHANVIEN_DIEUCHUYEN_DTO();
                nvdc.SOQD = item.SOQD;
                nvdc.NGAY = item.NGAY;
                nvdc.MANV = item.MANV;
                nvdc.MAPB = item.MAPB;
                nvdc.MAPB2 = item.MAPB2;
                nvdc.LYDO = item.LYDO;
                nvdc.GHICHU = item.GHICHU;
                nvdc.DELETED = item.DELETED;
                nvdc.DELETE_DATE = item.DELETED_DATE;
                nvdc.CREATED = item.CREATED;
                nvdc.CREATED_DATE = item.CREATED_DATE;
                nvdc.UPDATED = item.UPDATED;
                nvdc.UPDATED_DATE = item.UPDATED_DATE;
                nvdc.TENPB = db.PHONGBANs.FirstOrDefault(x => x.IDPB == item.MAPB).TENPB;
                nvdc.TENPB2 = db.PHONGBANs.FirstOrDefault(x => x.IDPB == item.MAPB2).TENPB;
                nvdc.HOTEN = db.NHANVIENs.FirstOrDefault(x => x.MANV == item.MANV).HOTEN;
                listDTO.Add(nvdc);
            }
            return listDTO;
        }


        public NHANVIEN_DIEUCHUYEN Add(NHANVIEN_DIEUCHUYEN nvdc)
        {
            try
            {
                db.NHANVIEN_DIEUCHUYEN.Add(nvdc);
                db.SaveChanges();
                return nvdc;
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi :" + ex.Message);
            }
        }


        public NHANVIEN_DIEUCHUYEN Update(NHANVIEN_DIEUCHUYEN nvdc)
        {
            try
            {
                var _nvdc = db.NHANVIEN_DIEUCHUYEN.FirstOrDefault(x => x.SOQD == nvdc.SOQD);
                nvdc.MAPB2 = _nvdc.MAPB2;
                nvdc.LYDO = _nvdc.LYDO;
                nvdc.GHICHU = _nvdc.GHICHU;
                _nvdc.NGAY = nvdc.NGAY;
                _nvdc.UPDATED = nvdc.UPDATED;
                _nvdc.UPDATED_DATE = nvdc.UPDATED_DATE;
                db.SaveChanges();
                return nvdc;
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
                var _nvdc = db.NHANVIEN_DIEUCHUYEN.FirstOrDefault(x => x.SOQD == id);
                _nvdc.DELETED = _user;
                _nvdc.DELETED_DATE = DateTime.Now;
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi: " + ex.Message);
            }
        }

    }
}
