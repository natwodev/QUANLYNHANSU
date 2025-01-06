using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BUSINESSLAYER.DATA_OBJECT;
using DATALAYER.context;

namespace BUSINESSLAYER
{
    public class dbNHANVIEN_PHU
    {
        QLNHANSU db = new QLNHANSU();
        public List<NHANVIEN_PHU> getList()
        {
            return db.NHANVIEN_PHU.ToList();
        }
        public NHANVIEN_PHU getItem(int id)
        {
            return db.NHANVIEN_PHU.FirstOrDefault(x => x.IDNVP == id);
        }


        //NGUYỄN HUỲNH NAM
        //TRẦN NHƯ KHÁNH
        //LÂM QUỐC ĐẠT 
        //NGUYÊN QUANG VINH
        public List<NHANVIEN_PHU_DTO> getListFull()
        {
            var lstNV = db.NHANVIEN_PHU.ToList();
            List<NHANVIEN_PHU_DTO> lstDTO = new List<NHANVIEN_PHU_DTO>();
            NHANVIEN_PHU_DTO nvDTO;
            foreach (var item in lstNV)
            {
                nvDTO = new NHANVIEN_PHU_DTO();
                nvDTO.IDNVP = item.IDNVP;
                nvDTO.MANV = item.MANV;
                nvDTO.NGAY = item.NGAY;
                nvDTO.GHICHU = item.GHICHU;
                nvDTO.TENPC = item.TENPC;
                nvDTO.SOTIEN = item.SOTIEN;
                var nv = db.NHANVIENs.FirstOrDefault(x => x.MANV == item.MANV);
                nvDTO.HOTEN = nv.HOTEN;
                nvDTO.CREATED = item.CREATED;
                nvDTO.CREATED_DATE = item.CREATED_DATE;
                nvDTO.DELETED = item.DELETED;
                nvDTO.DELETED_DATE = item.DELETED_DATE;
                nvDTO.UPDATED = item.UPDATED;
                nvDTO.UPDATED_DATE = item.UPDATED_DATE;
         
                lstDTO.Add(nvDTO);
            }
            return lstDTO;
        }



        public NHANVIEN_PHU Add(NHANVIEN_PHU nvp)
        {
            try
            {
                db.NHANVIEN_PHU.Add(nvp);
                db.SaveChanges();
                return nvp;
            }
            catch (Exception ex)
            {
                throw new Exception("Error!" + ex.Message);
            }
        }

        public NHANVIEN_PHU Update(NHANVIEN_PHU nvp)
        {
            try
            {
                var _nvp = db.NHANVIEN_PHU.FirstOrDefault(x =>x.IDNVP == nvp.IDNVP);
               _nvp.IDNVP = nvp.IDNVP;
                _nvp.MANV = nvp.MANV;
                _nvp.NGAY = nvp.NGAY;
                _nvp.GHICHU = nvp.GHICHU;
                _nvp.SOTIEN = nvp.SOTIEN;
                _nvp.TENPC = nvp.TENPC;
                _nvp.UPDATED = nvp.UPDATED;
                _nvp.UPDATED_DATE = DateTime.Now;
                db.SaveChanges();
                return _nvp;
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
                var _nvdc = db.NHANVIEN_PHU.FirstOrDefault(x => x.IDNVP == id);
                _nvdc.DELETED = _user;
                _nvdc.DELETED_DATE = DateTime.Now;
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi: " + ex.Message);
            }
        }
    }
}
