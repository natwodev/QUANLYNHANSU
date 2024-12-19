using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DATALAYER;

namespace BUSINESSLAYER
{
    public class dbHOPDONG
    {
        QLNHANSUEntities db = new QLNHANSUEntities();
        public HOPDONG getItem(string id)
        {
            return db.HOPDONGs.FirstOrDefault(x => x.SOHD == id);
        }
        public List<HOPDONG>getList()
        {
            return db.HOPDONGs.ToList();
        }
        public HOPDONG Add(HOPDONG hd)
        {
            try
            {
                db.HOPDONGs.Add(hd);
                db.SaveChanges();
                return hd;
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi :" + ex.Message);
            }
        }

        public HOPDONG Update(HOPDONG hd)
        {
            try
            {
                var _hd = db.HOPDONGs.FirstOrDefault(x => x.SOHD == hd.SOHD);
                _hd.NGAYBATDAU = hd.NGAYBATDAU;
                _hd.NGAYKETTHUC = hd.NGAYKETTHUC;
                _hd.MANV = hd.MANV;
                _hd.NGAYKY = hd.NGAYKY;
                _hd.HESOLUONG = hd.HESOLUONG;
                _hd.LANKY = hd.LANKY;
                _hd.NOIDUNG = hd.NOIDUNG;
                _hd.THOIHAN = hd.THOIHAN;
               // _hd.SOHD = hd.SOHD;
                _hd.IDCT = hd.IDCT;
                _hd.UPDATED = hd.UPDATED;
                _hd.UPDATE_DATE = hd.UPDATE_DATE;
                db.SaveChanges();
                return hd;
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi :" + ex.Message);
            }
        }

        public void Delete(string id,int manv)
        {
            try
            {
                var _hd = db.HOPDONGs.FirstOrDefault(x => x.SOHD == id);

                _hd.DELETED = manv;
                _hd.UPDATE_DATE = DateTime.Now;
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi :" + ex.Message);
            }
        }
    }
}
