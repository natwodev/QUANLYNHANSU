using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DATALAYER;

namespace BUSINESSLAYER
{
    public class dbTAIKHOAN
    {
        QLNHANSU db = new QLNHANSU();
        public List<TAIKHOAN> getList()
        {
            return db.TAIKHOANs.ToList();
        }


        public TAIKHOAN getItem(int id)
        {
            return db.TAIKHOANs.FirstOrDefault(x => x.IDTK == id);
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
