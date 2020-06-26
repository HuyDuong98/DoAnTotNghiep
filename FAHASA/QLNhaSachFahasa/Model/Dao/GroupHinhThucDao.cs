using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dao
{
    public class GroupHinhThucDao
    {
        QLNhaSachFahasaDBContext db = null;
        public GroupHinhThucDao()
        {
            db = new QLNhaSachFahasaDBContext();
        }
        public List<HINHTHUCSACH> ListAll()
        {
            return db.HINHTHUCSACHes.ToList();
        }
    }
}
