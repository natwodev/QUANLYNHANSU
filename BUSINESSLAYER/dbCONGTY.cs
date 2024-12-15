using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DATALAYER;
namespace BUSINESSLAYER
{
    public class dbCONGTY
    {
        QLNHANSUEntities db = new QLNHANSUEntities();
        public CONGTY getItem(int id)
        {
            return db.CONGTies.FirstOrDefault(x => x.IDCT == id);
        }


        public List<CONGTY> getList()
        {
            return db.CONGTies.ToList();
        }



        public CONGTY Add(CONGTY ct)
        {
            try
            {
                db.CONGTies.Add(ct);
                db.SaveChanges();
                return ct;
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi :" + ex.Message);
            }
        }


        public CONGTY Update(CONGTY ct)
        {
            try
            {
                var _ct = db.CONGTies.FirstOrDefault(x => x.IDCT == ct.IDCT);
                _ct.TENCT = ct.TENCT;
                db.SaveChanges();
                return ct;
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
                var _ct = db.CONGTies.FirstOrDefault(x => x.IDCT == id);
                db.CONGTies.Remove(_ct);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi :" + ex.Message);
            }

        }
    }
}
