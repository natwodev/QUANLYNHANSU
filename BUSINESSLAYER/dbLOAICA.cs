using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DATALAYER;
using DATALAYER.context;
namespace BUSINESSLAYER
{
    public class dbLOAICA
    {
        QLNHANSU db = new QLNHANSU();



        public List<LOAICA> getList()
        {
            return db.LOAICAs.ToList();
        }


        public LOAICA getItem(int id)
        {
            return db.LOAICAs.FirstOrDefault(x => x.IDLOAICA == id);
        }


        public LOAICA Add(LOAICA lc)
        {
            try
            {
                db.LOAICAs.Add(lc);
                db.SaveChanges();
                return lc;
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi :" + ex.Message);
            }
        }


        public LOAICA Update(LOAICA lc)
        {
            try
            {
                var _lc = db.LOAICAs.FirstOrDefault(x => x.IDLOAICA == lc.IDLOAICA);
                _lc.TENLOAICA = lc.TENLOAICA;
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
                var _tg = db.TONGIAOs.FirstOrDefault(x => x.IDTG == id);
                db.TONGIAOs.Remove(_tg);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi :" + ex.Message);
            }

        }
    }
}
