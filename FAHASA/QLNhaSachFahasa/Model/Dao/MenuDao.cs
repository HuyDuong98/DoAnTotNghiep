using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dao
{
    public class MenuDao
    {
        QLNhaSachFahasaDBContext db = null;
        public MenuDao()
        {
            db = new QLNhaSachFahasaDBContext();
        }
        public List<MANHINHTRANGCHU> ListMenuHomeAdmin()
        {
            return db.MANHINHTRANGCHUs.Where(x => x.ADMIN == true).ToList();
        }
        public List<MANHINHTRANGCHU> ListMenuHomeMember()
        {
            return db.MANHINHTRANGCHUs.Where(x => x.MEMBER == true).ToList();
        }
        public List<MANHINHTRANGCHU> ListMenuHomeLeaderr()
        {
            return db.MANHINHTRANGCHUs.Where(x => x.LEADER == true).ToList();
        }
    }
}
