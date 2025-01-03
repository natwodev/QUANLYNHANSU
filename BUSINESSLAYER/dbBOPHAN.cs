using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DATALAYER;
using DATALAYER.context;
namespace BUSINESSLAYER
{
    public class dbBOPHAN
    {
        QLNHANSU db = new QLNHANSU();
        public BOPHAN getItem(int id)
        {
            return db.BOPHANs.FirstOrDefault(x => x.IDBP == id);
        }


        public List<BOPHAN> getList()
        {
            return db.BOPHANs.ToList();
        }



        public BOPHAN Add(BOPHAN bp)
        {
            try
            {
                db.BOPHANs.Add(bp);
                db.SaveChanges();
                return bp;
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi :" + ex.Message);
            }
        }


        public BOPHAN Update(BOPHAN bp)
        {
            try
            {
                var _bp = db.BOPHANs.FirstOrDefault(x => x.IDBP == bp.IDBP);
                _bp.TENBP = bp.TENBP;
                db.SaveChanges();
                return bp;
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
                var _bp = db.BOPHANs.FirstOrDefault(x => x.IDBP == id);
                db.BOPHANs.Remove(_bp);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi :" + ex.Message);
            }

        }
    }
}
