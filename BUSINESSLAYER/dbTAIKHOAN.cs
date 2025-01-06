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
    public class dbTAIKHOAN
    {
        QLNHANSU db = new QLNHANSU();
        public List<TAIKHOAN> getList()
        {
            return db.TAIKHOANs.ToList();
        }

        public TAIKHOAN ValidateUser(string username, string password)
        {
            return db.TAIKHOANs.FirstOrDefault(x => x.TENDANGNHAP == username && x.MATKHAU == password);
        }

        public TAIKHOAN getItem(int id)
        {
            return db.TAIKHOANs.FirstOrDefault(x => x.IDTK == id);
        }

        public List<TAIKHOAN_DTO> getListFull()
        {
            var lstTK = db.TAIKHOANs.ToList();
            List<TAIKHOAN_DTO> lstDTO = new List<TAIKHOAN_DTO>();
            TAIKHOAN_DTO tkDTO;
            foreach (var item in lstTK)
            {
                tkDTO = new TAIKHOAN_DTO();
                tkDTO.IDTK = item.IDTK;
                tkDTO.TENDANGNHAP = item.TENDANGNHAP;
                tkDTO.MATKHAU = item.MATKHAU;
                tkDTO.TRANGTHAI = item.TRANGTHAI;
                tkDTO.LAST_LOGIN = item.LAST_LOGIN;

                tkDTO.MANV = item.MANV;
                var nv = db.NHANVIENs.FirstOrDefault(b => b.MANV == item.MANV);
                tkDTO.HOTEN = nv != null ? nv.HOTEN : null;


                tkDTO.IDQUYEN = item.IDQUYEN;
                var qh = db.QUYENHANs.FirstOrDefault(b => b.IDQUYEN == item.IDQUYEN);
                if (qh != null)
                {
                    tkDTO.TENQUYEN = qh.TENQUYEN;
                }
                else
                {
                    tkDTO.TENQUYEN = null;
                }

                lstDTO.Add(tkDTO);
            }
            return lstDTO;
        }

        public TAIKHOAN Add(TAIKHOAN tk)
        {
            try
            {
                db.TAIKHOANs.Add(tk);
                db.SaveChanges();
                return tk;
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi :" + ex.Message);
            }
        }


        public TAIKHOAN Update(TAIKHOAN tk)
        {
            try
            {
                var _tk = db.TAIKHOANs.FirstOrDefault(x => x.IDTK == tk.IDTK);
                _tk.MATKHAU = tk.MATKHAU;
                _tk.TRANGTHAI = tk.TRANGTHAI;
                _tk.LAST_LOGIN = tk.LAST_LOGIN;
                db.SaveChanges();
                return tk;
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi :" + ex.Message);
            }
        }

        public void Delete(int id)
        {
            try
            {
                var _tK = db.TAIKHOANs.FirstOrDefault(x => x.IDTK == id);
                db.TAIKHOANs.Remove(_tK);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi :" + ex.Message);
            }

        }

      
    }
}


//NGUYỄN HUỲNH NAM
//TRẦN NHƯ KHÁNH
//LÂM QUỐC ĐẠT 
//NGUYÊN QUANG VINH