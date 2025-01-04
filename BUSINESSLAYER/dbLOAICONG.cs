using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DATALAYER;
using DATALAYER.context;
namespace BUSINESSLAYER
{
    public class dbLOAICONG
    {
        QLNHANSU db = new QLNHANSU();



        public List<LOAICONG> getList()
        {
            return db.LOAICONGs.ToList();
        }


        public LOAICONG getItem(int id)
        {
            return db.LOAICONGs.FirstOrDefault(x => x.IDLC == id);
        }


        public LOAICONG Add(LOAICONG lc)
        {
            try
            {
                db.LOAICONGs.Add(lc);
                db.SaveChanges();
                return lc;
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi :" + ex.Message);
            }
        }


        public LOAICONG Update(LOAICONG lc)
        {
            try
            {
                var _lc = db.LOAICONGs.FirstOrDefault(x => x.IDLC == lc.IDLC);
                _lc.TENLC = lc.TENLC;
                _lc.HESO = lc.HESO;
                db.SaveChanges();
                return lc;
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
                var _lc = db.LOAICONGs.FirstOrDefault(x => x.IDLC == id);
                db.LOAICONGs.Remove(_lc);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi :" + ex.Message);
            }

        }
    }
}
