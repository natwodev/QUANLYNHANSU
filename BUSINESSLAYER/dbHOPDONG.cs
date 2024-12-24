using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BUSINESSLAYER.DATA_OBJECT;
using DATALAYER;

namespace BUSINESSLAYER
{
    public class dbHOPDONG
    {
        QLNHANSU db = new QLNHANSU();
        public HOPDONG getItem(string id)
        {
            return db.HOPDONGs.FirstOrDefault(x => x.SOHD == id);
        }
        public List<HOPDONG> getList()
        {
            return db.HOPDONGs.ToList();
        }
        public List<HOPDONG_DTO> getListFull()
        {
            List<HOPDONG> listHD = db.HOPDONGs.ToList();
            List<HOPDONG_DTO> listDTO = new List<HOPDONG_DTO>();
            HOPDONG_DTO hd;
            foreach(var item in listHD)
            {
                hd = new HOPDONG_DTO();
                hd.SOHD = item.SOHD;
                hd.NGAYBATDAU = item.NGAYBATDAU;
                hd.NGAYKETTHUC = item.NGAYKETTHUC;
                hd.NGAYKY = item.NGAYKY;
                hd.HESOLUONG = item.HESOLUONG;
                hd.NOIDUNG = item.NOIDUNG;
                hd.THOIHAN = hd.THOIHAN;
                hd.MANV = item.MANV;
                var nv = db.NHANVIENs.FirstOrDefault(n=>n.MANV==item.MANV);
                hd.HOTEN = nv.HOTEN;
                hd.CREATED = hd.CREATED;
                hd.CREATED_DATE = hd.CREATED_DATE;
                hd.UPDATED = hd.UPDATED;
                hd.UPDATE_DATE = hd.UPDATE_DATE;
                hd.DELETED = hd.DELETED;
                hd.DELETE_DATE = hd.DELETE_DATE;
                hd.IDCT = hd.IDCT;
                listDTO.Add(hd);
            }
            return listDTO;
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

        public void Delete(string id, int manv)
        {
            try
            {
                var _hd = db.HOPDONGs.FirstOrDefault(x => x.SOHD == id);

                _hd.DELETED = manv;
                _hd.DELETE_DATE = DateTime.Now;
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi :" + ex.Message);
            }
        }
    }
}