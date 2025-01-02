using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DATALAYER;

namespace BUSINESSLAYER
{
    public class dbQUYENHAN
    {
        QLNHANSU db = new QLNHANSU();
        public List<QUYENHAN> getList()
        {
            return db.QUYENHANs.ToList();
        }
 


        public QUYENHAN getItem(int id)
        {
            return db.QUYENHANs.FirstOrDefault(x => x.IDQUYEN == id);
        }


        public QUYENHAN Add(QUYENHAN qh)
        {
            try
            {
                db.QUYENHANs.Add(qh);
                db.SaveChanges();
                return qh;
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi :" + ex.Message);
            }
        }


        public QUYENHAN Update(QUYENHAN qh)
        {
            try
            {
                var _qh = db.QUYENHANs.FirstOrDefault(x => x.IDQUYEN == qh.IDQUYEN);
                _qh.TENQUYEN = qh.TENQUYEN;
                db.SaveChanges();
                return qh;
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
                var _qh = db.QUYENHANs.FirstOrDefault(x => x.IDQUYEN == id);
                db.QUYENHANs.Remove(_qh);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi :" + ex.Message);
            }

        }
    }
}
