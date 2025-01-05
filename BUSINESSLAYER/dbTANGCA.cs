using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BUSINESSLAYER.DATA_OBJECT;
using DATALAYER.context;

namespace BUSINESSLAYER
{
    public class dbTANGCA
    {
        QLNHANSU db = new QLNHANSU();
        public List<TANGCA> getList()
        {
            return db.TANGCAs.ToList();
        }
        public TANGCA getItem(int id)
        {
            return db.TANGCAs.FirstOrDefault(x => x.IDTC == id);
        }



        public List<TANGCA_DTO> getListFull()
        {
            var lstTC = db.TANGCAs.ToList();
            List<TANGCA_DTO> lstDTO = new List<TANGCA_DTO>();
            TANGCA_DTO tcDTO;
            foreach (var item in lstTC)
            {
                tcDTO = new TANGCA_DTO();
                tcDTO.IDTC = item.IDTC;
                tcDTO.NAM = item.NAM;
                tcDTO.THANG = item.THANG;
                tcDTO.NGAY = item.NGAY;
                tcDTO.SOGIO = item.SOGIO;
                tcDTO.GHICHU = item.GHICHU;
                tcDTO.MANV = item.MANV;
                tcDTO.IDLOAICA = item.IDLOAICA;
                tcDTO.DELETED = item.DELETED;
                tcDTO.DELETED_DATE = item.DELETED_DATE;
                tcDTO.CREATED = item.CREATED;
                tcDTO.CREATED_DATE = item.CREATED_DATE;
                tcDTO.UPDATED = item.UPDATED;
                tcDTO.UPDATED_DATE = item.UPDATED_DATE;
                tcDTO.HOTEN = db.NHANVIENs.FirstOrDefault(x => x.MANV == item.MANV).HOTEN;
                tcDTO.TENLOAICA = db.LOAICAs.FirstOrDefault(x => x.IDLOAICA == item.IDLOAICA).TENLOAICA;
                tcDTO.HESO = db.LOAICAs.FirstOrDefault(x => x.IDLOAICA == item.IDLOAICA).HESO;
                lstDTO.Add(tcDTO);
            }
            return lstDTO;
        }



        public TANGCA Add(TANGCA tc)
        {
            try
            {
                db.TANGCAs.Add(tc);
                db.SaveChanges();
                return tc;
            }
            catch (Exception ex)
            {
                throw new Exception("Error!" + ex.Message);
            }
        }

        public TANGCA Update(TANGCA tc)
        {
            try
            {
                var _tc = db.TANGCAs.FirstOrDefault(x => x.IDTC == tc.IDTC);
                _tc.SOGIO = tc.SOGIO;
                _tc.THANG = tc.THANG;
                _tc.NGAY = tc.NGAY;
                _tc.NAM = tc.NAM;
                _tc.GHICHU = tc.GHICHU;
                _tc.MANV = tc.MANV;
                _tc.IDLOAICA = tc.IDLOAICA;
                _tc.UPDATED = tc.UPDATED;
                _tc.UPDATED_DATE = DateTime.Now;
                db.SaveChanges();
                return _tc;
            }
            catch (Exception ex)
            {
                throw new Exception("Error!" + ex.Message);

            }
        }
        public void Delete(int id, string _user)
        {
            try
            {
                var _tc = db.TANGCAs.FirstOrDefault(x => x.IDTC == id);
                _tc.DELETED = _user;
                _tc.DELETED_DATE = DateTime.Now;
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi: " + ex.Message);
            }
        }
    }
}
