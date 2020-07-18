using Microsoft.Ajax.Utilities;
using Model.Dao;
using QLNhaSachFahasa.Areas.Admin.Models;
using QLNhaSachFahasa.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QLNhaSachFahasa.Areas.Admin.Controllers
{
    public class OrdersController : BaseController
    {
        // GET: Admin/Order
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult GetDataGridOrder(string keyword, int? status)
        {
            var listDDH = new OrdersDao().GetListDonHang(keyword, status);
            var model = new List<OrdersModel>();
            foreach (var item in listDDH)
            {
                var infoCustomer = new CustomerDao().ViewDetail(item.MAKHACHHANG);
                var ctDDH = new OrdersDao().GetOrderDetail(item.MAHOADON);
                var NhanVien = new AdminDao().ViewDetail(item.NGUOICAPNHAT);
                var TenNhanVien = "";
                if (NhanVien!=null)
                {
                    TenNhanVien = NhanVien.TENNHANVIEN + " ("+NhanVien.MANHANVIEN+")";
                }
                var dateUpdate = item.NGAYCAPNHAT;
                decimal TongTien = 0;
                decimal ship = 0;
                foreach (var i in ctDDH)
                {
                    TongTien = TongTien +i.THANHTIEN*i.SOLUONG;
                }
                if (TongTien <= 300000)
                {
                    ship = 30000;
                    TongTien += ship;
                }
                if(dateUpdate == null)
                {
                    dateUpdate = item.NGAYLAP;
                }
                model.Add(new OrdersModel
                {
                    MaDDH = item.MAHOADON,
                    TenKH = infoCustomer.TENKHACHHANG,
                    SDT = infoCustomer.DIENTHOAI,
                    DiaChi = infoCustomer.DIACHI,
                    TrangThai = item.TRANGTHAI,
                    NgayCapNhat = dateUpdate,
                    TenNguoiCapNhat = TenNhanVien,
                    TongTien = TongTien,
                    PhiShip = ship
                });
            }
            return Json(model, JsonRequestBehavior.AllowGet);
        }
        public ActionResult ViewDetail(string id, string ship, string tongTien)
        {
            ViewBag.ID = id;
            ViewBag.Ship = string.Format("{0:0,0}", Decimal.Parse(ship));
            ViewBag.TongTien = string.Format("{0:0,0}", Decimal.Parse(tongTien));
            return PartialView("_ViewDetail");
        }
        public ActionResult ChangeStatus(string id, int status)
        {
            ViewBag.ID = id;
            ViewBag.Status = status;
            return PartialView("_ChangeStatus");
        }
        public ActionResult GetDataOrderDetail(string id)
        {
            var list = new OrdersDao().GetOrderDetail(id);
            var model = new List<OrderDetailModel>();
            foreach (var item in list)
            {
                var product = new SanPhamDao().getProduct(item.MASANPHAM);
                var img = new SanPhamDao().getListImages(item.MASANPHAM);
                model.Add(new OrderDetailModel
                {
                    MaDDH = item.MAHOADON,
                    MaSanPham = item.MASANPHAM,
                    DonGiaBan = item.THANHTIEN,
                    SoLuong = item.SOLUONG,
                    MauSac = product.MAUSAC,
                    TenSanPham = product.TENSANPHAM,
                    Link = img[0].LINKHINHANH
                });
            }
            return Json(model, JsonRequestBehavior.AllowGet);
        }
        public ActionResult SaveChangeStatus(string id,int status)
        {
            var session = (UserLogin)Session[CommonConstants.USER_SEESION];
            var nv = session.UserID;
            var model = new OrdersDao().SaveChangeStatus(id, status,nv);
            
            return Json(model, JsonRequestBehavior.AllowGet);
        }
    }
}