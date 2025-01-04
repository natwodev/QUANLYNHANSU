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
    public class dbHOPDONG
    {
        QLNHANSU db = new QLNHANSU();
        private dbTAIKHOAN _taikhoan;
        public static TAIKHOAN _user;
        public HOPDONG getItem(string id)
        {
            return db.HOPDONGs.FirstOrDefault(x => x.SOHD == id);
        }
        public List<HOPDONG_DTO> getItemFull(string id)
        {
            List<HOPDONG> listHD = db.HOPDONGs.Where(x =>x.SOHD == id).ToList();
            List<HOPDONG_DTO> listDTO = new List<HOPDONG_DTO>();
            HOPDONG_DTO hd;
            _taikhoan = new dbTAIKHOAN();
            foreach (var item in listHD)
            {
                hd = new HOPDONG_DTO();
                hd.SOHD = item.SOHD;
                hd.NGAYBATDAU = item.NGAYBATDAU?.Date;
                hd.NGAYKETTHUC = item.NGAYKETTHUC?.Date;
                hd.THOIHAN = item.THOIHAN;
                hd.HESOLUONG = item.HESOLUONG;
                hd.LANKY = item.LANKY;
                hd.NGAYKY = item.NGAYKY;
                hd.NOIDUNG = item.NOIDUNG;
                hd.MANV = item.MANV;
                var nv = db.NHANVIENs.FirstOrDefault(n => n.MANV == item.MANV);
                hd.HOTEN = nv.HOTEN;
                hd.CCCD = nv.CCCD;
                hd.DIENTHOAI = nv.DIENTHOAI;
                hd.DIACHINV = nv.DIACHI;
                hd.CREATED = item.CREATED;
                hd.CREATED_DATE = item.CREATED_DATE;
                hd.UPDATED = item.UPDATED;
                hd.UPDATE_DATE = item.UPDATE_DATE;
                hd.DELETED = item.DELETED;
                hd.DELETE_DATE = item.DELETE_DATE;
                hd.IDCT = item.IDCT;
                var ct = db.CONGTies.FirstOrDefault(n => n.IDCT == item.IDCT);
                hd.TENCT = ct.TENCT;
                hd.IDTD = nv.IDTD;
                var td = db.TRINHDOes.FirstOrDefault(n => n.IDTD == nv.IDTD);
                hd.TENTD = td.TENTD;
                hd.DIACHICT = ct.DIACHI;
                hd.DIENTHOAICT = ct.DIENTHOAI;
                var pb = db.PHONGBANs.FirstOrDefault(n => n.IDPB == nv.IDPB);
                hd.TENPB = pb.TENPB;
                var bp = db.BOPHANs.FirstOrDefault(n => n.IDBP == nv.IDBP);
                hd.TENBP = bp.TENBP;
                var cv = db.CHUCVUs.FirstOrDefault(n => n.IDCV == nv.IDCV);
                hd.TENCV = cv.TENCV;
                // Tìm nhân viên dựa trên mã nhân viên
                var nvv = db.NHANVIENs.FirstOrDefault(n => n.MANV == _user.MANV);
                // Kiểm tra nếu nvv khác null
                if (nvv != null)
                {
                    // Gán tên nhân viên lập nếu tìm thấy nhân viên
                    hd.TENNVLAP = nvv.HOTEN;
                }
                else
                {
                    // Gán giá trị null hoặc giá trị mặc định nếu không tìm thấy nhân viên
                    hd.TENNVLAP = null;
                }

                listDTO.Add(hd);
            }
            return listDTO;
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
                hd.THOIHAN = item.THOIHAN;
                hd.HESOLUONG = item.HESOLUONG;
                hd.LANKY = item.LANKY;
                hd.NGAYKY = item.NGAYKY;
                hd.NOIDUNG = item.NOIDUNG;
                hd.MANV = item.MANV;
                var nv = db.NHANVIENs.FirstOrDefault(n=>n.MANV==item.MANV);
                hd.HOTEN = nv.HOTEN;
                hd.CCCD = nv.CCCD;
                hd.DIENTHOAI = nv.DIENTHOAI;
                hd.DIACHINV = nv.DIACHI;
                hd.CREATED = item.CREATED;
                hd.CREATED_DATE = item.CREATED_DATE;
                hd.UPDATED = item.UPDATED;
                hd.UPDATE_DATE = item.UPDATE_DATE;
                hd.DELETED = item.DELETED;
                hd.DELETE_DATE = item.DELETE_DATE;
                hd.IDCT = item.IDCT;
                
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