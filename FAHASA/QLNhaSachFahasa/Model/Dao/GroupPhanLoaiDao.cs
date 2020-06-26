using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dao
{
    public class GroupPhanLoaiDao
    {
        QLNhaSachFahasaDBContext db = null;
        public GroupPhanLoaiDao()
        {
            db = new QLNhaSachFahasaDBContext();
        }
        public List<PHANLOAI> ListAll()
        {
            return db.PHANLOAIs.ToList();
        }
        public int InserPhanLoaiSach(PHANLOAI entity)
        {
            try
            {
                db.PHANLOAIs.Add(entity);
                db.SaveChanges();
                return 1;
            }
            catch (Exception)
            {
                return 0;
            }
        }
    }
}
