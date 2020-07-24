using Model.Dao;
using QLNhaSachFahasa.Areas.Admin.Models;
using QLNhaSachFahasa.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QLNhaSachFahasa.Areas.Admin.Controllers
{
    public class ReportController : BaseController
    {
        // GET: Admin/Report
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult SalesReport()
        {
            return View();
        }
        public ActionResult ReportProduct()
        {
            return View();
        }
        public ActionResult GetDataReportProduct(string keyword)
        {
            var list = new BookDao().GetDataBook(keyword);
            var model = new List<SanPhamModel>();
            //int nhap=0, xuat=0, ton = 0;

            foreach (var item in list)
            {
                var order = new OrdersDao().GetOrderDetailByIDProduct(item.MASANPHAM);
                int xuat = 0;
                if (order != null)
                {
                    foreach (var items in order)
                    {
                        xuat += items.SOLUONG;
                    }
                }
                var ncc = new SanPhamDao().GetItemNCC(item.NHACUNGCAP);
                string tenNCC = "";
                if (ncc != null)
                {
                    tenNCC = ncc.TENNHACUNGCAP;
                }
                model.Add(new SanPhamModel
                {
                    MASANPHAM = item.MASANPHAM,
                    TENSANPHAM = item.TENSANPHAM,
                    MAUSAC = item.MAUSAC,
                    TACGIA = item.TACGIA,
                    NGAYCAPNHAT = item.NGAYCAPNHAT,
                    NHASANXUAT = tenNCC,
                    XUAT = xuat,
                    TON = (int)item.SOLUONG,
                    NHAP = xuat + (int)item.SOLUONG
                });
            }
            return Json(model, JsonRequestBehavior.AllowGet);
        }
        public ActionResult GetDataOrederSuccesss(DateTime month)
        {
            var list = new OrdersDao().GetListOrderForMonth(month);
            int sumSuccess = 0, sumCancel = 0;
            double[] datasuccess = new double[31];
            for (int i = 1; i <= 31; i++)
            {
                int temp = 0;
                foreach (var item in list)
                {
                    if (item.NGAYCAPNHAT.Day == i && item.TRANGTHAI == 1)
                    {
                        temp += 1;
                        sumSuccess += 1;
                    }
                    datasuccess[i - 1] = temp;
                }
            }

            double[] datacancel = new double[31];
            for (int i = 1; i <= 31; i++)
            {
                int temp = 0;
                foreach (var item in list)
                {
                    if (item.NGAYCAPNHAT.Day == i && item.TRANGTHAI == -1)
                    {
                        temp += 1;
                        sumCancel += 1;
                    }
                    datacancel[i - 1] = temp;
                }
            }

            var oModel = new
            {
                datasuccess = datasuccess,
                datacancel = datacancel,
                sumCancel = sumCancel,
                sumSuccess = sumSuccess,
            };
            return Json(oModel, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetDataLineChartSalesReport(DateTime month)
        {
            double[] data = new double[DateTime.Now.Day];
            var list = new OrdersDao().GetListOrderForMonth(month);
            double sum = 0;
            double totalIn = 0;
            //for (int i = 1; i <= DateTime.Now.Day; i++)
            //{
            foreach (var item in list)
            {
                var ctDDH = new OrdersDao().GetOrderDetail(item.MAHOADON);
                if (item.TRANGTHAI == 1)
                {

                    double total = 0;
                    //double totaltemp = 0;
                    foreach (var k in ctDDH)
                    {
                        var product = new SanPhamDao().getProduct(k.MASANPHAM);
                        totalIn += k.SOLUONG * (double)product.DONGIA;
                        total += k.SOLUONG * (double)k.THANHTIEN;
                    }
                    //if (totaltemp < 300000)
                    //{
                    //    total = totaltemp + 30000;
                    //}
                    //else
                    //{
                    //    total = totaltemp;
                    //}
                    sum += total;
                    data[item.NGAYCAPNHAT.Day - 1] += total;
                }
            }
            //}
            var oModel = new
            {
                data = data,
                sum = sum,
                totalIn = totalIn
            };
            return Json(oModel, JsonRequestBehavior.AllowGet);
        } 
        public ActionResult GetDataGridOrder(DateTime month)
        {
            var listDDH = new OrdersDao().GetListOrderForMonth(month);
            var model = new List<OrdersModel>();
            foreach (var item in listDDH)
            {
                var infoCustomer = new CustomerDao().ViewDetail(item.MAKHACHHANG);
                var ctDDH = new OrdersDao().GetOrderDetail(item.MAHOADON);
                var NhanVien = new AdminDao().ViewDetail(item.NGUOICAPNHAT);
                var TenNhanVien = "";
                if (NhanVien != null)
                {
                    TenNhanVien = NhanVien.TENNHANVIEN + " (" + NhanVien.MANHANVIEN + ")";
                }
                var dateUpdate = item.NGAYCAPNHAT;
                decimal TongTien = 0;
                decimal ship = 0;
                foreach (var i in ctDDH)
                {
                    TongTien = TongTien + i.THANHTIEN * i.SOLUONG;
                }
                if (TongTien <= 300000)
                {
                    ship = 30000;
                    TongTien += ship;
                }
                if (dateUpdate == null)
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
                    PhiShip = ship,
                    HinhThucThanhToan = "",
                });
            }
            return Json(model, JsonRequestBehavior.AllowGet);
        }
        public ActionResult GetDataGridOrderSales(DateTime month)
        {
            var listDDH = new OrdersDao().GetListOrderForMonth(month);
            var model = new List<OrdersModel>();
            foreach (var item in listDDH)
            {
                if (item.TRANGTHAI == 1)
                {
                    var infoCustomer = new CustomerDao().ViewDetail(item.MAKHACHHANG);
                    var ctDDH = new OrdersDao().GetOrderDetail(item.MAHOADON);
                    var NhanVien = new AdminDao().ViewDetail(item.NGUOICAPNHAT);
                    var TenNhanVien = "";
                    if (NhanVien != null)
                    {
                        TenNhanVien = NhanVien.TENNHANVIEN + " (" + NhanVien.MANHANVIEN + ")";
                    }
                    var dateUpdate = item.NGAYCAPNHAT;
                    decimal TongTien = 0;
                    //decimal ship = 0;
                    decimal totalIn = 0;
                    foreach (var i in ctDDH)
                    {
                        var product = new SanPhamDao().getProduct(i.MASANPHAM);
                        TongTien = TongTien + i.THANHTIEN * i.SOLUONG;
                        totalIn += i.SOLUONG * product.DONGIA;
                    }
                    //if (TongTien <= 300000)
                    //{
                    //    ship = 30000;
                    //    TongTien += ship;
                    //}
                    if (dateUpdate == null)
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
                        //PhiShip = ship,
                        TongNhap = totalIn,
                        HinhThucThanhToan = "",
                    });
                }
            }
            return Json(model, JsonRequestBehavior.AllowGet);
        }
    }
}