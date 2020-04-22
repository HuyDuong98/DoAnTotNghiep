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
        QLNhaSachDBContext db = null;
        public UserDao()
        {
            db = new QLNhaSachDBContext();
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
        public int Login(string userName, string passWord)
        {
            var resuft = db.KHACHHANGs.SingleOrDefault(x => x.USERNAME == userName);
            if(resuft == null)
            {
                return 0;
            }else
            {
                if(resuft.PASSWORD==passWord)
                {
                    return 1;
                }else
                {
                    return -1;
                }    
            }
        }
        public int LoginAdmin(string userName, string passWord)
        {
            var resuft = db.NHANVIENs.SingleOrDefault(x => x.USERNAMENV == userName);
            if (resuft == null)
            {
                return 0;
            }
            else
            {
                if (resuft.PASSWORDNV == passWord)
                {
                    return 1;
                }
                else
                {
                    return -1;
                }
            }
        }

        public bool CheckUserName(string userName)
        {
            return db.KHACHHANGs.Count(x => x.USERNAME == userName) > 0;
        }
        public bool CheckEmail(string email)
        {
            return db.KHACHHANGs.Count(x => x.EMAIL == email) > 0;
        }
        
    }
}
