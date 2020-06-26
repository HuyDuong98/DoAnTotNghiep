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
        //Khách hàng Web Account
        public string Insert(KHACHHANG entity )
        {
            db.KHACHHANGs.Add(entity);
            db.SaveChanges();
            return entity.MAKHACHHANG;
        }
        public KHACHHANG GetById(string userName)
        {
            return db.KHACHHANGs.SingleOrDefault(x => x.TENDANGNHAPKHACHHANG == userName);
        }
        public int Login(string userName, string passWord)
        {
            var resuft = db.KHACHHANGs.SingleOrDefault(x => x.TENDANGNHAPKHACHHANG == userName);
            if (resuft == null)
            {
                return 0;
            }
            else
            {
                if (resuft.MATKHAUKHACHHANG == passWord)
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
            return db.KHACHHANGs.Count(x => x.TENDANGNHAPKHACHHANG == userName) > 0;
        }
        public bool CheckEmail(string email)
        {
            return db.KHACHHANGs.Count(x => x.EMAIL == email) > 0;
        }

        public bool CheckIDCustomer(string id)
        {
            var ma = db.KHACHHANGs.SingleOrDefault(x => x.MAKHACHHANG == id);
            if (ma != null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public string CreateIDAuto(string ma)
        {
            int i = 1;
            bool flag = false;
            string idCustomer = "";
            do
            {
                idCustomer = ma + i;
                if (CheckIDCustomer(idCustomer))
                {
                    flag = true;
                }
                i++;
            } while (flag == false);
            return idCustomer;
        }

    }
}
