﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DATALAYER;
using DATALAYER.context;

namespace BUSINESSLAYER
{
    public class dbTRINHDO
    {
        QLNHANSU db = new QLNHANSU();
        public List<TRINHDO> getList()
        {
            return db.TRINHDOes.ToList();
        }


        public TRINHDO getItem(int id)
        {
            return db.TRINHDOes.FirstOrDefault(x => x.IDTD == id);
        }


        public TRINHDO Add(TRINHDO td)
        {
            try
            {
                db.TRINHDOes.Add(td);
                db.SaveChanges();
                return td;
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi :" + ex.Message);
            }
        }
        //NGUYỄN HUỲNH NAM
        //TRẦN NHƯ KHÁNH
        //LÂM QUỐC ĐẠT 
        //NGUYÊN QUANG VINH

        public TRINHDO Update(TRINHDO td)
        {
            try
            {
                var _td = db.TRINHDOes.FirstOrDefault(x => x.IDTD == td.IDTD);
                _td.TENTD = _td.TENTD;
                db.SaveChanges();
                return td;
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
                var _td = db.TRINHDOes.FirstOrDefault(x => x.IDTD == id);
                db.TRINHDOes.Remove(_td);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi :" + ex.Message);
            }

        }
    }
}
