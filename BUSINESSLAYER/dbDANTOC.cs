using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DATALAYER;
using DATALAYER.context;
namespace BUSINESSLAYER
{
    public class dbDANTOC
    {
        QLNHANSU db = new QLNHANSU();
        public DANTOC getItem(int id)
        {
            return db.DANTOCs.FirstOrDefault(x=>x.IDDT==id);
        }


        public List<DANTOC> getList() { 
            return db.DANTOCs.ToList();
        }

        //NGUYỄN HUỲNH NAM
        //TRẦN NHƯ KHÁNH
        //LÂM QUỐC ĐẠT 
        //NGUYÊN QUANG VINH

        public DANTOC Add(DANTOC dt)
        {
            try
            {         
                db.DANTOCs.Add(dt);
                db.SaveChanges();
                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi :" + ex.Message);
            }
        }

       
        public DANTOC Update(DANTOC dt)
        {
            try
            {
                var _dt = db.DANTOCs.FirstOrDefault(x => x.IDDT == dt.IDDT);
                _dt.TENDT = dt.TENDT;
                db.SaveChanges();
                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi :" + ex.Message);
            }
        }
        /*
        public void Delete(int id)
        {
            try
            {
                var _dt = db.DANTOCs.FirstOrDefault(x => x.IDDT == id);
                db.DANTOCs.Remove(_dt);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi :" + ex.Message);
            }
        }
          */
        public void Delete(int id)
        {
            try
            {
                var _dt = db.DANTOCs.FirstOrDefault(x => x.IDDT == id);
                db.DANTOCs.Remove(_dt);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi: " + ex.Message);
            }
        }
      
    }
}
