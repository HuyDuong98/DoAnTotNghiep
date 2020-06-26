using Model.EF;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dao
{
    public class SanPhamDao
    {
        QLNhaSachFahasaDBContext db = null;
        public SanPhamDao()
        {
            db = new QLNhaSachFahasaDBContext();
        }
        public List<SANPHAM> getListSanPham()
        {
            return db.SANPHAMs.Where(x=>x.TRANGTHAI==1).ToList<SANPHAM>();
        }
        public SANPHAM getProduct(string id)
        {
            return db.SANPHAMs.Where(x => x.MASANPHAM == id).FirstOrDefault();
        }
        public List<SANPHAM> getListProductBoxSearch(string keyword)
        {
            return db.SANPHAMs.Where(x =>( x.TENSANPHAM.Contains(keyword)|| x.TACGIA.Contains(keyword) || x.NHAXUATBAN.Contains(keyword) || x.MASANPHAM.Contains(keyword)) && x.TRANGTHAI ==1).Take(5).ToList<SANPHAM>();
        }
        public List<SANPHAM> getListSach()
        {
            return db.SANPHAMs.Where(x => x.PHANLOAI == "SACH" && x.TRANGTHAI == 1).ToList<SANPHAM>();
        }
        public List<SANPHAM> getListVPP()
        {
            return db.SANPHAMs.Where(x =>  x.PHANLOAI =="VPP" && x.TRANGTHAI ==1).ToList<SANPHAM>();
        }
        public List<HINHANH> getListImages(string ma)
        {
            return db.HINHANHs.Where(x => x.MASANPHAM == ma).ToList<HINHANH>();
        }
        public GIABAN getGiaBan(string masp)
        {
            return db.GIABANs.Find(masp);
        }

        public string getChuongTrinhKhuyenMai(string masp)
        {
            string name = "";
            CT_CHUONGTRINH_KHUYENMAI maCTKM = db.CT_CHUONGTRINH_KHUYENMAI.Where(x => x.MASANPHAM == masp).FirstOrDefault();
            if(maCTKM != null)
            {
                CHUONGTRINH_KHUYENMAI ctkm = db.CHUONGTRINH_KHUYENMAI.Where(x => x.MACHUONGTRINHKHUYENMAI == maCTKM.MACHUONGTRINHKHUYENMAI).FirstOrDefault();
                name = ctkm.TENCHUONGTRINHKHUYENMAI;
            }
            return name;
        }
        public List<SANPHAM> getListProductCTKM(string maCTKM,bool seeAll)
        {
            List<CT_CHUONGTRINH_KHUYENMAI> ctkm = new List<CT_CHUONGTRINH_KHUYENMAI>();
            if (seeAll)
            {
                ctkm = db.CT_CHUONGTRINH_KHUYENMAI.Where(x => x.MACHUONGTRINHKHUYENMAI == maCTKM).ToList<CT_CHUONGTRINH_KHUYENMAI>();
            }
            else
            {
                ctkm = db.CT_CHUONGTRINH_KHUYENMAI.Where(x => x.MACHUONGTRINHKHUYENMAI == maCTKM).Take(4).ToList<CT_CHUONGTRINH_KHUYENMAI>();
            }
            
            List<SANPHAM> list = new List<SANPHAM>();
            foreach (var item in ctkm)
            {
                SANPHAM sp = db.SANPHAMs.Where(x => x.MASANPHAM == item.MASANPHAM && x.TRANGTHAI == 1).FirstOrDefault();
                list.Add(sp);
            }

            return list;
        }
    }
}
