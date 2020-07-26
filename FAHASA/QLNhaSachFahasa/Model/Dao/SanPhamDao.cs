using Model.EF;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
            return db.SANPHAMs.Where(x => x.TRANGTHAI == 1).ToList<SANPHAM>();
        }
        public SANPHAM getProduct(string id)
        {
            return db.SANPHAMs.Where(x => x.MASANPHAM == id).FirstOrDefault();
        }
        public List<SANPHAM> getListProductBoxSearch(string keyword)
        {
            var querya = db.SANPHAMs.Where(x => (x.TENSANPHAM.Contains(keyword) || x.TACGIA.Contains(keyword) || x.NHAXUATBAN.Contains(keyword) || x.MASANPHAM.Contains(keyword)) && x.TRANGTHAI == 1).Take(5).ToList<SANPHAM>();

            var queryb = db.SANPHAMs.Where(delegate (SANPHAM c)
            {
                if (FahasaDao.ConvertToUnSign(c.TENSANPHAM).IndexOf(keyword, StringComparison.CurrentCultureIgnoreCase) >= 0 ||
                FahasaDao.ConvertToUnSign(c.TACGIA).IndexOf(keyword, StringComparison.CurrentCultureIgnoreCase) >= 0 ||
                FahasaDao.ConvertToUnSign(c.NHAXUATBAN).IndexOf(keyword, StringComparison.CurrentCultureIgnoreCase) >= 0 ||
                FahasaDao.ConvertToUnSign(c.MASANPHAM).IndexOf(keyword, StringComparison.CurrentCultureIgnoreCase) >= 0)
                    return true;
                else
                    return false;
            }).AsQueryable();
            if (querya.Count == 0)
            {
                return queryb.Take(5).ToList();
            }
            else
            {
                return querya;
            }

        }

        public List<SANPHAM> getListSach()
        {
            return db.SANPHAMs.Where(x => x.PHANLOAI == "SACH" && x.TRANGTHAI == 1).ToList<SANPHAM>();
        }
        public List<SANPHAM> getListVPP()
        {
            return db.SANPHAMs.Where(x => x.PHANLOAI == "VPP" && x.TRANGTHAI == 1).ToList<SANPHAM>();
        }
        public List<HINHANH> getListImages(string ma)
        {
            return db.HINHANHs.Where(x => x.MASANPHAM == ma).ToList<HINHANH>();
        }
        public GIABAN getGiaBan(string masp)
        {
            return db.GIABANs.Where(x=>x.MASANPHAM == masp).OrderByDescending(x => x.NGAYCAPNHATGIA).FirstOrDefault();
        }

        public string getChuongTrinhKhuyenMai(string masp)
        {
            string name = "";
            CT_CHUONGTRINH_KHUYENMAI maCTKM = db.CT_CHUONGTRINH_KHUYENMAI.Where(x => x.MASANPHAM == masp).FirstOrDefault();
            if (maCTKM != null)
            {
                CHUONGTRINH_KHUYENMAI ctkm = db.CHUONGTRINH_KHUYENMAI.Where(x => x.MACHUONGTRINHKHUYENMAI == maCTKM.MACHUONGTRINHKHUYENMAI).FirstOrDefault();
                name = ctkm.TENCHUONGTRINHKHUYENMAI;
            }
            return name;
        }
        public List<SANPHAM> getListProductCTKM(string maCTKM, bool seeAll)
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
        public List<SANPHAM> getListProduct(string idPL)
        {
            return  db.SANPHAMs.Where(x => x.PHANLOAI == idPL && x.TRANGTHAI == 1).Take(10).ToList();
        }
        public int setViewsProduct(string productID)
        {
            var product = db.SANPHAMs.Where(x => x.MASANPHAM == productID).FirstOrDefault();
            product.LUOTXEM = product.LUOTXEM + 1;
            db.SaveChanges();
            return (int)product.LUOTXEM;
        }
        public List<PHANLOAI> getDataPhanLoai()
        {
            List<PHANLOAI> model = db.PHANLOAIs.ToList<PHANLOAI>();
            return model;
        }
        public bool CheckID(string id)
        {
            var ma = db.DONHANGs.SingleOrDefault(x => x.MAHOADON == id);
            if (ma != null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public string IdDonHangAuto(string ma)
        {
            int i = 1;
            bool flag = false;
            string id = "";
            do
            {
                id = ma + i;
                if (CheckID(id))
                {
                    flag = true;
                }
                i++;
            } while (flag == false);
            return id;
        }
        public string InsertDonHang(DONHANG entity)
        {
            db.DONHANGs.Add(entity);
            db.SaveChanges();
            return entity.MAHOADON;
        }
        public int InsertCTDonHang(CHITIETDONHANG entity)
        {
            db.CHITIETDONHANGs.Add(entity);
            db.SaveChanges();
            return entity.SOLUONG;
        }
        public int InsertProduct(SANPHAM entity)
        {
            try
            {
                db.SANPHAMs.Add(entity);
                db.SaveChanges();
                return 1;
            }
            catch
            {
                return 0;
            }
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
        public string CreateIDVPPAuto(string ma)
        {
            int i = 1;
            bool flag = false;
            string id = "";
            do
            {
                id = ma + i;
                if (CheckIDBook(id))
                {
                    flag = true;
                }
                i++;
            } while (flag == false);
            return id;

        }
        public List<NHASANXUAT> DataNSX()
        {
            return db.NHASANXUATs.ToList();
        }
        public List<NHACUNGCAP> DataNCC()
        {
            return db.NHACUNGCAPs.ToList();
        }
        public List<XUATXU> DataQG()
        {
            return db.XUATXUs.ToList();
        }
        public NHACUNGCAP GetItemNCC(string ma)
        {
            return db.NHACUNGCAPs.Find(ma);
        }
        public NHASANXUAT GetItemNSX(string ma)
        {
            return db.NHASANXUATs.Find(ma);
        }
        public List<SANPHAM> GetListSpByPL(string maPL)
        {
            return db.SANPHAMs.Where(x => x.PHANLOAI.Trim() == maPL).ToList();
        }
        public int updateSLProduct(string id, int sl)
        {
            try
            {
                var product = db.SANPHAMs.Where(x => x.MASANPHAM == id).FirstOrDefault();
                product.SOLUONG = sl;
                db.SaveChanges();
                return 1;
            }
            catch
            {
                return 0;
            }
        }
        public bool CheckIDPL(string id)
        {
            var ma = db.PHANLOAIs.SingleOrDefault(x => x.MAPHANLOAI == id);
            if (ma != null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public string CreateIDPLAuto(string ma)
        {
            int i = 1;
            bool flag = false;
            string id = "";
            do
            {
                id = ma + i;
                if (CheckIDPL(id))
                {
                    flag = true;
                }
                i++;
            } while (flag == false);
            return id;

        }
        public int ThemPhanLoai(string idParent, string text)
        {

            try
            {
                string id = CreateIDPLAuto("PL");
                var pl = new PHANLOAI()
                {
                    MAPHANLOAI = id,
                    MAPHANLOAICHA = idParent,
                    TENPHANLOAI = text
                };
                db.PHANLOAIs.Add(pl);
                db.SaveChanges();
                return 1;
            }
            catch
            {
                return 0;
            }
        }
        public bool CheckIDGia(string id)
        {
            var ma = db.GIABANs.SingleOrDefault(x => x.MAGIA == id);
            if (ma != null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public string CreateIDGiaBanAuto(string ma)
        {
            int i = 1;
            bool flag = false;
            string id = "";
            do
            {
                id = ma + i;
                if (CheckIDGia(id))
                {
                    flag = true;
                }
                i++;
            } while (flag == false);
            return id;

        }
        public int UpdateGiaBan(string idProduct, decimal giaban, string idNV)
        {
            try
            {
                var idGia = CreateIDGiaBanAuto("GIA");
                var gia = new GIABAN()
                {
                    MAGIA = idGia,
                    MASANPHAM = idProduct,
                    DONGIABAN = giaban,
                    NGAYCAPNHATGIA = DateTime.Now,
                    VAT = 0,
                    NGUOICAPNHAT = idNV,
                };
                db.GIABANs.Add(gia);
                db.SaveChanges();
                return 1;
            }
            catch
            {
                return 0;
            }
        }
    }
}
