using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dao
{
    public class CustomerDao
    {
        QLNhaSachFahasaDBContext db = null;
        public CustomerDao()
        {
            db = new QLNhaSachFahasaDBContext();
        }
        public List<KHACHHANG> GetDataCustomer(string keyWord)
        {
            if (string.IsNullOrEmpty(keyWord))
            {
                return db.KHACHHANGs.Where(x=>x.TRANGTHAI == 1).OrderByDescending(x => x.NGAYTAO ).ToList<KHACHHANG>();
            }
            else
            {
                return db.KHACHHANGs.Where(x => (x.TENKHACHHANG.Contains(keyWord) || x.HOKHACHHANG.Contains(keyWord))&& x.TRANGTHAI == 1).OrderByDescending(x => x.NGAYTAO).ToList<KHACHHANG>();
            }
        }
        public KHACHHANG ViewDetail(string id)
        {
            return db.KHACHHANGs.Find(id);
        }
        public bool UpdateCustomer(KHACHHANG entity)
        {
            try
            {
                var customer = db.KHACHHANGs.Find(entity.MAKHACHHANG);
                customer.HOKHACHHANG = entity.HOKHACHHANG;
                customer.TENKHACHHANG = entity.TENKHACHHANG;
                customer.EMAIL = entity.EMAIL;
                customer.DIENTHOAI = entity.DIENTHOAI;
                //customer.QUOCGIA = entity.QUOCGIA;
                //customer.THANHPHO = entity.THANHPHO;
                //customer.QUAN = entity.QUAN;
                //customer.PHUONG = entity.PHUONG;
                customer.DIACHI = entity.DIACHI;
                customer.TENDANGNHAPKHACHHANG = entity.TENDANGNHAPKHACHHANG;
                if (!string.IsNullOrEmpty(entity.MATKHAUKHACHHANG))
                {
                    customer.MATKHAUKHACHHANG = entity.MATKHAUKHACHHANG;
                }
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }
        public bool Delete(string id)
        {
            try
            {
                var entity = db.KHACHHANGs.Find(id);
                entity.TRANGTHAI = -1;
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
