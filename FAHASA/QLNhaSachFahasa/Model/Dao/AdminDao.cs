using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.EF;

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
                return entity.MANHANVIEN;
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
                var emloyee = db.NHANVIENs.Find(entity.MANHANVIEN);
                if (!string.IsNullOrEmpty(entity.MATKHAUNHANVIEN))
                {
                    emloyee.MATKHAUNHANVIEN = entity.MATKHAUNHANVIEN;
                }
                emloyee.DIACHINHANVIEN = entity.DIACHINHANVIEN;
                emloyee.SDT = entity.SDT;
                emloyee.EMAIL = entity.EMAIL;
                emloyee.TENNHANVIEN = entity.TENNHANVIEN;
                //emloyee.NGAYTAO = DateTime.Now;
                //emloyee.TRANGTHAI = entity.TRANGTHAI;
                db.SaveChanges();
                return true;
            }
            catch(Exception)
            {
                return false;
            }
          
        }
        public bool DeleteEmployee(string id)
        {
            try
            {
                var employee = db.NHANVIENs.Find(id);
                db.NHANVIENs.Remove(employee);
                db.SaveChanges();
                return true;
            }
            catch(Exception)
            {
                return false;
            }
        }
        public bool ChangeStatus(string id)
        {
            var emp = db.NHANVIENs.Find(id);
            emp.TRANGTHAI = !emp.TRANGTHAI;
            db.SaveChanges();
            return emp.TRANGTHAI;
        }
        public NHANVIEN GetByIdEmloyee(string userName)
        {
            return db.NHANVIENs.SingleOrDefault(x => x.TENDANGNHAPNHANVIEN == userName);
        }

        public NHANVIEN ViewDetail(string id)
        {
            return db.NHANVIENs.Find(id);
        }
        
        public List<NHANVIEN> ListEmployeeAll()
        {
            return db.NHANVIENs.ToList<NHANVIEN>();
        }
        public string getNameGroup(string idGroup)
        {
            return db.NHOMNGUOIDUNGs.Where(x => x.MANHOMNGUOIDUNG == idGroup).Select(x => x.TENNHOMNGUOIDUNG).ToString();
        }
        public List<NHANVIEN> GetDataEmloyee(string keyWord, string status)
        {
            if(string.IsNullOrEmpty(keyWord))
            {
                if(string.IsNullOrEmpty(status))
                {
                    return db.NHANVIENs.OrderByDescending(x => x.NGAYTAO).ToList<NHANVIEN>();
                }else if(status == "true")
                {
                    return db.NHANVIENs.Where(x=>x.TRANGTHAI == true).OrderByDescending(x => x.NGAYTAO).ToList<NHANVIEN>();
                }else
                {
                    return db.NHANVIENs.Where(x => x.TRANGTHAI == false).OrderByDescending(x => x.NGAYTAO).ToList<NHANVIEN>();
                }
            }
            else
            {
                if(string.IsNullOrEmpty(status))
                {
                    return db.NHANVIENs.Where(x => x.TENNHANVIEN.Contains(keyWord) || x.MANHANVIEN.Contains(keyWord) || x.EMAIL.Contains(keyWord) || x.SDT.Contains(keyWord)).OrderByDescending(x => x.NGAYTAO).ToList<NHANVIEN>();
                }
                else if(status == "true")
                {
                    return db.NHANVIENs.Where(x => x.TENNHANVIEN.Contains(keyWord) || x.MANHANVIEN.Contains(keyWord) || x.EMAIL.Contains(keyWord) || x.SDT.Contains(keyWord) && x.TRANGTHAI == true).OrderByDescending(x => x.NGAYTAO).ToList<NHANVIEN>();
                }
                else
                {
                    return db.NHANVIENs.Where(x => x.TENNHANVIEN.Contains(keyWord) || x.MANHANVIEN.Contains(keyWord) || x.EMAIL.Contains(keyWord) || x.SDT.Contains(keyWord) && x.TRANGTHAI == false).OrderByDescending(x => x.NGAYTAO).ToList<NHANVIEN>();
                }
            }    
        }
        public List<string> GetListCredential(string userName)
        {
            var user = db.NHANVIENs.Single(x => x.TENDANGNHAPNHANVIEN == userName);
            var data = (from a in db.CAPQUYENs
                        join b in db.NHOMNGUOIDUNGs
                         on a.MANHOMNGUOIDUNG equals b.MANHOMNGUOIDUNG
                        join c in db.VAITROes on a.MAVAITRO equals c.MAVAITRO
                        where b.MANHOMNGUOIDUNG == user.MANHOMNGUOIDUNG
                        select new 
                        {
                            MAVAITRO = a.MAVAITRO,
                            MANHOMNGUOIDUNG = a.MANHOMNGUOIDUNG,

                        }).AsEnumerable().Select(x => new CAPQUYEN()
                        {
                            MANHOMNGUOIDUNG = x.MANHOMNGUOIDUNG,
                            MAVAITRO = x.MAVAITRO,
                        });
            return data.Select(x=>x.MAVAITRO).ToList();
        }

        public int LoginAdmin(string userName, string passWord)
        {
            var resuft = db.NHANVIENs.SingleOrDefault(x => x.TENDANGNHAPNHANVIEN == userName);
            if (resuft == null)
            {
                return 0;
            }
            else
            {
                if(resuft.TRANGTHAI== false)
                {
                    return 2;
                }else if (resuft.MATKHAUNHANVIEN == passWord)
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
            return db.NHANVIENs.Count(x => x.TENDANGNHAPNHANVIEN == userName) > 0;
            
        }
        public bool CheckEmailEmloyee(string email)
        {
            return db.NHANVIENs.Count(x => x.EMAIL == email) > 0;
        }
        public bool CheckIDEmloyee (string id)
        {
            var ma = db.NHANVIENs.SingleOrDefault(x => x.MANHANVIEN == id);
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
