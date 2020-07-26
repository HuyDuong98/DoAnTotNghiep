using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dao
{
    public class BookDao
    {
        QLNhaSachFahasaDBContext db = null;
        public BookDao()
        {
            db = new QLNhaSachFahasaDBContext();
        }
        public List<SANPHAM> GetDataBook(string keyWord)
        {
            if (string.IsNullOrEmpty(keyWord))
            {
                return db.SANPHAMs.Where(x=>x.TRANGTHAI==1).OrderByDescending(x => x.NGAYCAPNHAT).ToList<SANPHAM>();
            }
            else
            {
                return db.SANPHAMs.Where(x =>( x.TENSANPHAM.Contains(keyWord) || x.TACGIA.Contains(keyWord) || x.MASANPHAM.Contains(keyWord))&& x.TRANGTHAI==1).OrderByDescending(x=>x.NGAYCAPNHAT).ToList<SANPHAM>();
            }
        }
        public int InserBook(SANPHAM entity)
        {
            try
            {
                db.SANPHAMs.Add(entity);
                db.SaveChanges();
                return 1;
            }
            catch (Exception)
            {
                return 0;
            }
        }
        public int UpdateBook(SANPHAM entity)
        {
            try
            {
                var book = db.SANPHAMs.Find(entity.MASANPHAM);
                book.TENSANPHAM = entity.TENSANPHAM;
                book.TACGIA = entity.TACGIA;
                //book.DONGIA = entity.DONGIA;
                book.TRONGLUONG = entity.TRONGLUONG;
                book.SOTRANG = entity.SOTRANG;
                book.KICHTHUOC = entity.KICHTHUOC;
                book.GHICHU = entity.GHICHU;
                book.NHAXUATBAN = entity.NHAXUATBAN;
                book.NGONNGU = entity.NGONNGU;
                //book.MAPHANLOAISACH = entity.MAPHANLOAISACH;
                book.NGAYCAPNHAT = DateTime.Now;
                book.HINHTHUC = entity.HINHTHUC;
                db.SaveChanges();
                return 1;
            }
            catch (Exception)
            {
                return 0;
            }

        }
        public int UpdateVPP(SANPHAM entity)
        {
            try
            {
                var book = db.SANPHAMs.Find(entity.MASANPHAM);

                book.TENSANPHAM = entity.TENSANPHAM;
                book.CHATLIEU = entity.CHATLIEU;
                book.MAUSAC = entity.MAUSAC;
                book.TRONGLUONG = entity.TRONGLUONG;
                book.NHASANXUAT = entity.NHASANXUAT;
                book.KICHTHUOC = entity.KICHTHUOC;
                book.NHACUNGCAP = entity.NHACUNGCAP;
                book.PHANLOAI = entity.PHANLOAI;
                book.QUOCGIA = entity.QUOCGIA;
                book.GHICHU = entity.GHICHU;
                db.SaveChanges();
                return 1;
            }
            catch (Exception)
            {
                return 0;
            }

        }
        public bool Delete(string id)
        {
            try
            {
                var book = db.SANPHAMs.Find(id);
                book.TRANGTHAI = -1;
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public SANPHAM ViewDetail(string id)
        {
            return db.SANPHAMs.Find(id);
        }
        public bool CheckIDBook(string id)
        {
            var ma = db.SANPHAMs.SingleOrDefault(x => x.MASANPHAM == id);
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
            string idBook = "";
            do
            {
                idBook = ma + i;
                if (CheckIDBook(idBook))
                {
                    flag = true;
                }
                i++;
            } while (flag == false);
            return idBook;

        }
        public bool CheckBookExist(string bookName, string NXB)
        {
            return db.SANPHAMs.Count(x => x.TENSANPHAM == bookName && x.NHAXUATBAN == NXB) > 0;

        }

        public bool DeleteImage(string id)
        {
            try
            {
                var img = db.HINHANHs.Where(x=>x.MASANPHAM==id).ToList<HINHANH>();
                if (img.Count > 0)
                {
                    db.HINHANHs.RemoveRange(img);
                    db.SaveChanges();
                    return true;
                }
                else return false;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
