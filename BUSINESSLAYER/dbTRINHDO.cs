using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DATALAYER;

namespace BUSINESSLAYER
{
    public class dbTRINHDO
    {
        QLNHANSUEntities db = new QLNHANSUEntities();
        public List<TRINHDO> getList()
        {
            return db.TRINHDOes.ToList();
        }
    }
}
