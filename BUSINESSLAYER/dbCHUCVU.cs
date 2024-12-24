using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DATALAYER;
namespace BUSINESSLAYER
{
    public class dbCHUCVU
    {
        QLNHANSU db = new QLNHANSU();
        public CHUCVU getItem(int id)
        {
            return db.CHUCVUs.FirstOrDefault(x => x.IDCV == id);
        }


        public List<CHUCVU> getList()
        {
            return db.CHUCVUs.ToList();
        }



        public CHUCVU Add(CHUCVU cv)
        {
            try
            {
                db.CHUCVUs.Add(cv);
                db.SaveChanges();
                return cv;
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi :" + ex.Message);
            }
        }


        public CHUCVU Update(CHUCVU cv)
        {
            try
            {
                var _cv = db.CHUCVUs.FirstOrDefault(x => x.IDCV == cv.IDCV);
                _cv.TENCV = cv.TENCV;
                db.SaveChanges();
                return cv;
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
                var _cv = db.CHUCVUs.FirstOrDefault(x => x.IDCV == id);
                db.CHUCVUs.Remove(_cv);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi :" + ex.Message);
            }

        }
    }
}
