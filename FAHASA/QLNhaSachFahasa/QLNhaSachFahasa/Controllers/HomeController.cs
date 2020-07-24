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
            var listImg = new SanPhamDao().getListImages(productID);
            var img = new List<ImagesModel>();
            foreach(var item in listImg)
            {
                img.Add(new ImagesModel
                {
                    LINKHINHANH= item.LINKHINHANH,
                    TENHINHANH=item.TENHINHANH,
                });
            }
            ViewBag.ProductID = productID;
            return View(img);
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
                var gia = item.DONGIA;
                if (giaban != null)
                {
                    gia = giaban.DONGIABAN;
                }
                var sp = new SanPhamModel
                {
                    TENSANPHAM = item.TENSANPHAM,
                    MASANPHAM = item.MASANPHAM,
                    DONGIA = gia,
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
            decimal dongiaban = model.DONGIA;
            if(giaban != null)
            {
                dongiaban = giaban.DONGIABAN;
            }
            var ncc = new SanPhamDao().GetItemNCC(model.NHACUNGCAP);
            var tenNCC = model.NHASANXUAT;
            if(ncc != null)
            {
                tenNCC = ncc.TENNHACUNGCAP;
            }
            SanPhamModel Product = new SanPhamModel()
            {
                TENSANPHAM = model.TENSANPHAM,
                MASANPHAM = model.MASANPHAM,
                GIABAN = dongiaban,
                DONGIA = model.DONGIA,
                LINKHINHANH = link,
                GHICHU = System.Web.HttpUtility.HtmlDecode(model.GHICHU),
                CHUONGTRINHKHUYENMAI = chuongtrinhkhuyenmai,
                LUOTXEM = model.LUOTXEM,
                SOLUONG = model.SOLUONG,
                NHAXUATBAN = model.NHAXUATBAN,
                NHASANXUAT = tenNCC,
                TACGIA = model.TACGIA,
                HINHANH = listImg,
                MAUSAC = model.MAUSAC,
                KICHTHUOC = model.KICHTHUOC,
                TRONGLUONG = (float)model.TRONGLUONG
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
        private static List<PhanLoaiModel> FillAll(List<PHANLOAI> flatObjects, string parentCode)
        {
            List<PhanLoaiModel> model = new List<PhanLoaiModel>();
            foreach (var item in flatObjects)
            {
                if (item.MAPHANLOAI.Trim() == parentCode.Trim())
                {
                    model.Add(new PhanLoaiModel()
                    {
                        id = item.MAPHANLOAI,
                        text = item.TENPHANLOAI
                    });
                    model = FillAllChill(flatObjects, model, item.MAPHANLOAI);
                }
            }
            return model.ToList();
        }

        private static List<PhanLoaiModel> FillAllChill(List<PHANLOAI> flatObjects, List<PhanLoaiModel> model, string parentCode)
        {
            foreach (var item in flatObjects)
            {
                if (item.MAPHANLOAICHA != null && item.MAPHANLOAICHA.Trim() == parentCode.Trim())
                {
                    model.Add(new PhanLoaiModel()
                    {
                        id = item.MAPHANLOAI,
                        text = item.TENPHANLOAI
                    });
                    model = FillAllChill(flatObjects, model, item.MAPHANLOAI);
                }
            }
            return model.ToList();
        }
        public ActionResult ProductsByPL(string pl)
        {
            ViewBag.IdPL = pl.Trim();
            return View();
        }
        public ActionResult GetSPbyPL(string id)
        {
            var listTemp = new SanPhamDao().getDataPhanLoai();
            var root = listTemp.Find(x => x.MAPHANLOAI.Trim() == id);
            var model = FillAll(listTemp, id.Trim());
            List<SanPhamModel> products = new List<SanPhamModel>();
            foreach(var item in model)
            {
                var temp = new SanPhamDao().GetListSpByPL(item.id);
                if(temp != null)
                {
                    foreach(var sp in temp)
                    {
                        List<HINHANH> images = new SanPhamDao().getListImages(sp.MASANPHAM);
                        string chuongtrinhkhuyenmai = new SanPhamDao().getChuongTrinhKhuyenMai(sp.MASANPHAM);
                        var giaban = new SanPhamDao().getGiaBan(sp.MASANPHAM);
                        var gia = sp.DONGIA;
                        if (giaban != null)
                        {
                            gia = giaban.DONGIABAN;
                        }
                        var product = new SanPhamModel()
                        {
                            TENSANPHAM = sp.TENSANPHAM,
                            MASANPHAM = sp.MASANPHAM,
                            DONGIA = sp.DONGIA,
                            GIABAN = gia,
                            GHICHU = System.Web.HttpUtility.HtmlDecode(sp.GHICHU),
                            CHUONGTRINHKHUYENMAI = chuongtrinhkhuyenmai,
                            LUOTXEM = sp.LUOTXEM
                        };
                        if (images.Count > 0)
                        {
                            product.LINKHINHANH = images[0].LINKHINHANH;
                        }
                        products.Add(product);
                    }
                }
            }
            var oModel = new
            {
                products= products,
                rootname = root.TENPHANLOAI,
            };
            return Json(oModel, JsonRequestBehavior.AllowGet);
        }
    }
}