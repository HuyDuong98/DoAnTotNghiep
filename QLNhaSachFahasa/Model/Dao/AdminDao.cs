using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.EF;
using PagedList;
using PagedList;

namespace Model.Dao
{
    public class AdminDao
    {
        QLNhaSachFahasaDBContext db = null;
        public AdminDao()
        {
            db = new QLNhaSachFahasaDBContext();
        }
        public string InsertEmloyee(NHANVIEN entity)
        {
            try
            {
                db.NHANVIENs.Add(entity);
                db.SaveChanges();
                return entity.MANV;
            }
            catch(Exception ex)
            {
                return "";
            }
        }
        
        public bool UpdateEmloyee(NHANVIEN entity)
        {
            try
            {
                var emloyee = db.NHANVIENs.Find(entity.MANV);
                emloyee.TENNV = entity.TENNV;
                if(!string.IsNullOrEmpty(entity.PASSWORDNV))
                {
                    emloyee.PASSWORDNV = entity.PASSWORDNV;
                }
                emloyee.DIACHINV = entity.DIACHINV;
                emloyee.SDTNV = entity.SDTNV;
                emloyee.EMAIL = entity.EMAIL;
                db.SaveChanges();
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
          
        }
        public NHANVIEN GetByIdEmloyee(string userName)
        {
            return db.NHANVIENs.SingleOrDefault(x => x.USERNAMENV == userName);
        }

        public NHANVIEN ViewDetail(string id)
        {
            return db.NHANVIENs.Find(id);
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
                if(resuft.TRANGTHAI== false)
                {
                    return 2;
                }else if (resuft.PASSWORDNV == passWord)
                {
                    return 1;
                }
                else
                {
                    return -1;
                }
            }
        }
        public bool CheckUserNameEmloyee(string userName)
        {
            return db.NHANVIENs.Count(x => x.USERNAMENV == userName) > 0;
            
        }
        public bool CheckEmailEmloyee(string email)
        {
            return db.NHANVIENs.Count(x => x.EMAIL == email) > 0;
        }
        public bool CheckIDEmloyee (string id)
        {
            var ma = db.NHANVIENs.SingleOrDefault(x => x.MANV == id);
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
            string idEmloyee = "";
            do
            {
                idEmloyee = ma + i;
                if(CheckIDEmloyee(idEmloyee))
                {
                    flag = true;
                }
                i++;
            } while (flag == false);
            return idEmloyee;

        }
    }
}
