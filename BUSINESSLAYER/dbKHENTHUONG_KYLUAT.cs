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
    public class dbKHENTHUONG_KYLUAT
    {
        QLNHANSU db = new QLNHANSU();
        public KHENTHUONG_KYLUAT getItem(string id)
        {
            return db.KHENTHUONG_KYLUAT.FirstOrDefault(x => x.SOQD == id);
        }
        public List<KHENTHUONG_KYLUAT> getList(int loai)
        {
            var result = db.KHENTHUONG_KYLUAT.Where(x => x.LOAI == loai).ToList();
            return result.Any() ? result : null;
        }




        public List<KHENTHUONG_KYLUAT_DTO> getItemFull(int loai)
        {
            List<KHENTHUONG_KYLUAT> listKTKL = db.KHENTHUONG_KYLUAT.Where(x => x.LOAI == loai).ToList();
            List<KHENTHUONG_KYLUAT_DTO> listDTO = new List<KHENTHUONG_KYLUAT_DTO>();
            KHENTHUONG_KYLUAT_DTO ktkl;
            foreach (var item in listKTKL)
            {
                ktkl = new KHENTHUONG_KYLUAT_DTO();
                ktkl.SOQD = item.SOQD;
                ktkl.MANV = item.MANV;
                ktkl.NGAY = item.NGAY;
                ktkl.LOAI = item.LOAI;
                ktkl.LYDO = item.LYDO;
                ktkl.NOIDUNG = item.NOIDUNG;
                ktkl.TUNGAY = item.TUNGAY;
                ktkl.DENNGAY = item.DENNGAY;
                ktkl.UPDATED = item.UPDATED;
                ktkl.UPDATED_DATE = item.UPDATED_DATE;
                ktkl.CREATED = item.CREATED;
                ktkl.CREATED_DATE = item.CREATED_DATE;
                ktkl.DELETED = item.DELETED;
                ktkl.DELETED_DATE = item.DELETED_DATE;
                ktkl.HOTEN = db.NHANVIENs.FirstOrDefault(x => x.MANV == item.MANV).HOTEN;
                listDTO.Add(ktkl);
            }
            return listDTO;
        }

        public KHENTHUONG_KYLUAT Add(KHENTHUONG_KYLUAT ktkl)
        {
            try
            {
                db.KHENTHUONG_KYLUAT.Add(ktkl);
                db.SaveChanges();
                return ktkl;
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi thêm mới khen thưởng kỷ luật" + ex.Message);
            }

        }
        public KHENTHUONG_KYLUAT Update(KHENTHUONG_KYLUAT ktkl)
        {
            try
            {
                KHENTHUONG_KYLUAT _ktkl = db.KHENTHUONG_KYLUAT.FirstOrDefault(x => x.SOQD == ktkl.SOQD);
                _ktkl.NGAY = ktkl.NGAY;
                _ktkl.TUNGAY = ktkl.TUNGAY;
                _ktkl.DENNGAY = ktkl.DENNGAY;
                _ktkl.LYDO = ktkl.LYDO;
                _ktkl.NOIDUNG = ktkl.NOIDUNG;
                _ktkl.LOAI = ktkl.LOAI;
                _ktkl.MANV = ktkl.MANV;
                _ktkl.UPDATED = ktkl.UPDATED;
                _ktkl.UPDATED_DATE = ktkl.UPDATED_DATE;
                db.SaveChanges();
                return ktkl;
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi thêm mới khen thưởng kỷ luật" + ex.Message);
            }

        }
        public void Delete(string id)
        {
            try
            {
                KHENTHUONG_KYLUAT _ktkl = db.KHENTHUONG_KYLUAT.FirstOrDefault(x => x.SOQD == id);
                _ktkl.DELETED = 1;
                _ktkl.DELETED_DATE = DateTime.Now;
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi thêm mới khen thưởng kỷ luật" + ex.Message);
            }

        }



    }
}
