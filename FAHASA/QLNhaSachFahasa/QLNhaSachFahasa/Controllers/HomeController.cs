using Model.Dao;
using Model.EF;
using QLNhaSachFahasa.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using QLNhaSachFahasa.UtilityHelpers;
using System.Threading;

namespace QLNhaSachFahasa.Controllers
{
    public class HomeController : FahasaController
    {
        
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Detail(string productID)
        {
            //SANPHAM product = new SanPhamDao().getProduct(productID);
            //List<HINHANH> images = new SanPhamDao().getListImages(productID);
            //var giaban = new SanPhamDao().getGiaBan(productID);
            //string chuongtrinhkhuyenmai = new SanPhamDao().getChuongTrinhKhuyenMai(productID);
            //SanPhamModel model = new SanPhamModel() {
            //    MASANPHAM = product.MASANPHAM,
            //    LOAIMATHANG = product.LOAIMATHANG,
            //    NGONNGU = product.NGONNGU,
            //    HINHTHUC = product.HINHTHUC,
            //    TENSANPHAM = product.TENSANPHAM,
            //    TACGIA = product.MASANPHAM,
            //    DONGIA = product.DONGIA,
            //    GIABAN = giaban.DONGIABAN,
            //    MASANPHAM = product.MASANPHAM,
            //    MASANPHAM = product.MASANPHAM,
            //    MASANPHAM = product.MASANPHAM,
            //    MASANPHAM = product.MASANPHAM,
            //    MASANPHAM = product.MASANPHAM,

            //}
            ViewBag.ProductID = productID;
            return View();
        }

        public ActionResult GetListBook()
        {
            List<SANPHAM> model = new SanPhamDao().getListSanPham();

            List<SanPhamModel> listProduct = new List<SanPhamModel>();
            foreach(SANPHAM item in model)
            {
                List<HINHANH> images = new SanPhamDao().getListImages(item.MASANPHAM);
                string chuongtrinhkhuyenmai = new SanPhamDao().getChuongTrinhKhuyenMai(item.MASANPHAM);
                listProduct.Add(new SanPhamModel {
                    
                    TENSANPHAM = item.TENSANPHAM ,
                    MASANPHAM = item.MASANPHAM,
                    DONGIA = item.DONGIA,
                    LINKHINHANH = images[0].LINKHINHANH,
                    GHICHU = item.GHICHU,
                    CHUONGTRINHKHUYENMAI = chuongtrinhkhuyenmai,
                    LUOTXEM = item.LUOTXEM
                });
            }
            return Json(listProduct, JsonRequestBehavior.AllowGet);
        }
        public ActionResult GetListBookSale(bool seeAll)
        {
            List<SANPHAM> model = new SanPhamDao().getListProductCTKM("FlashSale", seeAll);

            List<SanPhamModel> listProduct = new List<SanPhamModel>();
            foreach (SANPHAM item in model)
            {
                List<HINHANH> images = new SanPhamDao().getListImages(item.MASANPHAM);
                string chuongtrinhkhuyenmai = new SanPhamDao().getChuongTrinhKhuyenMai(item.MASANPHAM);
                listProduct.Add(new SanPhamModel
                {

                    TENSANPHAM = item.TENSANPHAM,
                    MASANPHAM = item.MASANPHAM,
                    DONGIA = item.DONGIA,
                    LINKHINHANH = images[0].LINKHINHANH,
                    GHICHU = item.GHICHU,
                    CHUONGTRINHKHUYENMAI = chuongtrinhkhuyenmai
                });
            }
            return Json(listProduct, JsonRequestBehavior.AllowGet);
        }
        public ActionResult Change(string languageAbbrevation)
        {
            if (languageAbbrevation == "vi")
            {
                CurrentLanguage = LanguageCulture.VIETNAMESE.Value;
            }
            else
            {
                CurrentLanguage = LanguageCulture.ENGLISH.Value;
            }

            string urlReferrer = Request.UrlReferrer.ToString();
            if (string.IsNullOrWhiteSpace(urlReferrer))
            {
                urlReferrer = "/Login";
            }

            return Redirect(urlReferrer);
        }

        public ActionResult GetDataSearchProduct(string keyword)
        {
            List<SANPHAM> list = new SanPhamDao().getListProductBoxSearch(keyword);
            List<SanPhamModel> product = new List<SanPhamModel>();
            if (list != null)
            {
                foreach (var item in list)
                {
                    List<HINHANH> images = new SanPhamDao().getListImages(item.MASANPHAM);
                    product.Add(new SanPhamModel
                    {
                        MASANPHAM = item.MASANPHAM,
                        TENSANPHAM = item.TENSANPHAM,
                        LINKHINHANH = images[0].LINKHINHANH,
                    });
                }
            }
          
            return Json(product, JsonRequestBehavior.AllowGet);
        }


    }
}