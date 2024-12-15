using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DATALAYER;
namespace BUSINESSLAYER
{
    public class dbTONGIAO
    {
        QLNHANSUEntities db = new QLNHANSUEntities();
        public TONGIAO getItem(int id)
        {
            return db.TONGIAOs.FirstOrDefault(x => x.IDTG == id);
        }


        public List<TONGIAO> getList()
        {
            return db.TONGIAOs.ToList();
        }



        public TONGIAO Add(TONGIAO tg)
        {
            try
            {
                db.TONGIAOs.Add(tg);
                db.SaveChanges();
                return tg;
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi :" + ex.Message);
            }
        }


        public TONGIAO Update(TONGIAO tg)
        {
            try
            {
                var _tg = db.TONGIAOs.FirstOrDefault(x => x.IDTG == tg.IDTG);
                _tg.TENTG = tg.TENTG;
                db.SaveChanges();
                return tg;
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
                var _tg = db.TONGIAOs.FirstOrDefault(x => x.IDTG== id);
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
