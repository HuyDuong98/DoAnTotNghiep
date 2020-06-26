using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dao
{
    public class GroupNgonNguDao
    {
        QLNhaSachFahasaDBContext db = null;
        public GroupNgonNguDao()
        {
            db = new QLNhaSachFahasaDBContext();
        }
        public List<NGONNGU> ListAll()
        {
            return db.NGONNGUs.ToList();
        }
    }
}
