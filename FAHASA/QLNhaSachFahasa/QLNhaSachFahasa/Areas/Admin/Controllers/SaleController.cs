using Model.Dao;
using Model.EF;
using QLNhaSachFahasa.Areas.Admin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QLNhaSachFahasa.Areas.Admin.Controllers
{
    public class SaleController : Controller
    {
        // GET: Admin/Sale
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult GetDataGridSale()
        {
            var ctkm = new SanPhamDao().GetListCTKM();
            var modelTemp = new List<SaleModel>();
            foreach(var item in ctkm)
            {
                var date = new SanPhamDao().GetTimeSale(item.MATHOIGIAN);
                modelTemp.Add(new SaleModel()
                {
                    MaCTKM = item.MACHUONGTRINHKHUYENMAI,
                    TenCTKM = item.TENCHUONGTRINHKHUYENMAI,
                    NgayBatDau = date.THOIGIANBATDAU,
                    NgayKetThuc = date.THOIGIANKETTHUC,
                    PhanTramGiamGia = (int)item.MUCGIAMGIA
                });
            }
            var model = modelTemp.OrderByDescending(x => x.NgayBatDau).ToList();
            return Json(model, JsonRequestBehavior.AllowGet);
        }
        public ActionResult EditSale(string id)
        {
            var item = new SanPhamDao().FindCTKM(id);
            var date = new SanPhamDao().GetTimeSale(item.MATHOIGIAN);
            var model = new SaleModel()
            {
                MaCTKM = item.MACHUONGTRINHKHUYENMAI,
                TenCTKM = item.TENCHUONGTRINHKHUYENMAI,
                NgayBatDau = date.THOIGIANBATDAU,
                NgayKetThuc = date.THOIGIANKETTHUC,
                PhanTramGiamGia = (int)item.MUCGIAMGIA,
                MaThoiGian = item.MATHOIGIAN,
            };
            return PartialView("~/Areas/Admin/Views/Sale/_EditSale.cshtml",model);
        }
        public ActionResult SaveEdit(DateTime ngayBD, DateTime ngKT, int MucGiam, string idCTKM, string idTG)
        {
            var message = 0;
            var thoigian = new THOIGIAN();
            thoigian.MATHOIGIAN = idTG;
            thoigian.THOIGIANBATDAU = ngayBD;
            thoigian.THOIGIANKETTHUC = ngKT;

            var giatri = new CHUONGTRINH_KHUYENMAI();
            giatri.MACHUONGTRINHKHUYENMAI = idCTKM;
            giatri.MUCGIAMGIA = MucGiam;

            message = new SanPhamDao().updateCTKM(thoigian, giatri);
            return Json(message, JsonRequestBehavior.AllowGet);
        }
        public ActionResult ProductSale(string id)
        {
            var item = new SanPhamDao().FindCTKM(id);
            var date = new SanPhamDao().GetTimeSale(item.MATHOIGIAN);
            var model = new SaleModel()
            {
                MaCTKM = item.MACHUONGTRINHKHUYENMAI,
                TenCTKM = item.TENCHUONGTRINHKHUYENMAI,
                NgayBatDau = date.THOIGIANBATDAU,
                NgayKetThuc = date.THOIGIANKETTHUC,
                PhanTramGiamGia = (int)item.MUCGIAMGIA
            };
            return PartialView("~/Areas/Admin/Views/Sale/_ProductSale.cshtml", model);
        }

        public ActionResult GetProduct(string id,string keyword)
        {
            var listProduct = new SanPhamDao().getListSanPham();
            var model = new List<ProductModel>();
            var ctCTKM = new SanPhamDao().getListctCTKM(id);
            foreach (var item in listProduct)
            {
                var check = false;
                var temp = ctCTKM.Where(x => x.MASANPHAM == item.MASANPHAM).FirstOrDefault();
                if (temp != null)
                {
                    check = true;
                }
                model.Add(new ProductModel()
                {
                    MaSanPham = item.MASANPHAM,
                    TenSanPham = item.TENSANPHAM,
                    select = check
                });
            }
            if (string.IsNullOrEmpty(keyword))
            {
                return Json(model, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(model.Where(x=>x.TenSanPham.Contains(keyword) || x.MaSanPham.Contains(keyword)), JsonRequestBehavior.AllowGet);
            }
            
        }

        public ActionResult SaveProductSave(string idCTKM, List<string> data)
        {
            var message = 0;
            message = new SanPhamDao().ChangeProductSale(idCTKM, data);
            return Json(message, JsonRequestBehavior.AllowGet);
        }
    }
}