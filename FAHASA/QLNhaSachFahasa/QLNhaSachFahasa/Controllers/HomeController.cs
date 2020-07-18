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
using System.Net;
using QLNhaSachFahasa.Areas.Admin.Models;

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
            var i = new SanPhamDao().setViewsProduct(productID);
            ViewBag.ProductID = productID;
            return View();
        }

        public ActionResult GetListBook()
        {
            List<SANPHAM> model = new SanPhamDao().getListSanPham();
            
            List<SanPhamModel> listProduct = new List<SanPhamModel>();
            foreach (SANPHAM item in model)
            {
                List<HINHANH> images = new SanPhamDao().getListImages(item.MASANPHAM);
                string chuongtrinhkhuyenmai = new SanPhamDao().getChuongTrinhKhuyenMai(item.MASANPHAM);
                var giaban = new SanPhamDao().getGiaBan(item.MASANPHAM);
                var sp = new SanPhamModel
                {
                    TENSANPHAM = item.TENSANPHAM,
                    MASANPHAM = item.MASANPHAM,
                    DONGIA = item.DONGIA,
                    //GIABAN = giaban.DONGIABAN,
                    GHICHU = System.Web.HttpUtility.HtmlDecode(item.GHICHU),
                    CHUONGTRINHKHUYENMAI = chuongtrinhkhuyenmai,
                    LUOTXEM = item.LUOTXEM
                };
                if (images.Count >0)
                {
                    sp.LINKHINHANH = images[0].LINKHINHANH;
                }
                listProduct.Add(sp);
            }
            return Json(listProduct, JsonRequestBehavior.AllowGet);
        }
        public ActionResult GetBook(string productID)
        {
            SANPHAM model = new SanPhamDao().getProduct(productID);
            List<HINHANH> images = new SanPhamDao().getListImages(productID);
            List<ImagesModel> listImg = new List<ImagesModel>();
            foreach(var img in images)
            {
                listImg.Add(new ImagesModel
                {
                    LINKHINHANH = img.LINKHINHANH,
                    TENHINHANH = img.TENHINHANH,
                    MASANPHAM = img.MASANPHAM,
                    TENLUUTEPTIN = img.TENLUUTEPTIN
                });
            }
            string chuongtrinhkhuyenmai = new SanPhamDao().getChuongTrinhKhuyenMai(model.MASANPHAM);
            string link = "";
            if(images != null && images.Count > 0)
            {
                link = images[0].LINKHINHANH;
            }
            var giaban = new SanPhamDao().getGiaBan(model.MASANPHAM);
            SanPhamModel Product = new SanPhamModel()
            {
                TENSANPHAM = model.TENSANPHAM,
                MASANPHAM = model.MASANPHAM,
                GIABAN = giaban.DONGIABAN,
                DONGIA = model.DONGIA,
                LINKHINHANH = link,
                GHICHU = System.Web.HttpUtility.HtmlDecode(model.GHICHU),
                CHUONGTRINHKHUYENMAI = chuongtrinhkhuyenmai,
                LUOTXEM = model.LUOTXEM,
                NHAXUATBAN = model.NHAXUATBAN,
                NHASANXUAT = model.NHASANXUAT,
                TACGIA = model.TACGIA,
                HINHANH = listImg
            };
            var oModel = new
            {
                product = Product,
                images = images
            };
            return Json(Product, JsonRequestBehavior.AllowGet);
        }
        public ActionResult GetImagesBook(string productID)
        {
            List<HINHANH> images = new SanPhamDao().getListImages(productID);
            return Json(images, JsonRequestBehavior.AllowGet);
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
                    CHUONGTRINHKHUYENMAI = chuongtrinhkhuyenmai,
                    LUOTXEM = item.LUOTXEM
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
        private static List<PhanLoaiModel> FillRecursive(List<PHANLOAI> flatObjects, string parentCode)
        {
            return (flatObjects.Where(x => x.MAPHANLOAI.Trim() == parentCode.Trim()).Select(item => new PhanLoaiModel
            {
                id = item.MAPHANLOAI,
                text = item.TENPHANLOAI,
                items = FillRecursiveChil(flatObjects, item.MAPHANLOAI)
            })).ToList();
        }

        private static List<PhanLoaiModel> FillRecursiveChil(List<PHANLOAI> flatObjects, string parentCode)
        {
            return (flatObjects.Where(x => x.MAPHANLOAICHA != null && x.MAPHANLOAICHA.Trim() == parentCode.Trim()).Select(item => new PhanLoaiModel
            {
                id = item.MAPHANLOAI,
                text = item.TENPHANLOAI,
                items = FillRecursiveChil(flatObjects, item.MAPHANLOAI)
            })).ToList();
        }
        public ActionResult GetListContentMenu(string id)
        {
            var listTemp = new SanPhamDao().getDataPhanLoai();
            var model = FillRecursiveChil(listTemp, id);
            //var list = listTemp.Where(x =>x.MAPHANLOAICHA != null && x.MAPHANLOAICHA.Trim() == id).ToList<PHANLOAI>();
            //var model = new List<MenuPhanLoai>();
            //foreach(var item in list)
            //{
            //    model.Add(new MenuPhanLoai {
            //        title = item.TENPHANLOAI
            //    });
            //}
            return Json(model, JsonRequestBehavior.AllowGet);
        }
    }
}