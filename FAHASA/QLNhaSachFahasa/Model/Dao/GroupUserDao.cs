using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dao
{
    public class GroupUserDao
    {
        QLNhaSachFahasaDBContext db = null;
        public GroupUserDao()
        {
            db = new QLNhaSachFahasaDBContext();
        }
        public List<NHOMNGUOIDUNG> ListAll ()
        {
            return db.NHOMNGUOIDUNGs.ToList();
        }
    }
}
