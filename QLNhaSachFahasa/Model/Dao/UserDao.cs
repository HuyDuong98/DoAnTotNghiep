using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.EF;

namespace Model.Dao
{
    public class UserDao
    {
        QLNhaSachFahasaDBContext db = null;
        public UserDao()
        {
            db = new QLNhaSachFahasaDBContext();
        }
        public string Insert(KHACHHANG entity )
        {
            db.KHACHHANGs.Add(entity);
            db.SaveChanges();
            return entity.MAKH;
        }
        public KHACHHANG GetById(string userName)
        {
            return db.KHACHHANGs.SingleOrDefault(x=>x.USERNAME== userName);
        }
        public bool Login(string userName, string passWord)
        {
            var resuft = db.KHACHHANGs.Count(x => x.USERNAME == userName && x.PASSWORD == passWord);
            if(resuft>0)
            {
                return true;
            }else
            {
                return false;
            }
        }

    }
}
