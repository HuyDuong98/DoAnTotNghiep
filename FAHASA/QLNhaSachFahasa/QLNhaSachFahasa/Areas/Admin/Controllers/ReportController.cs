﻿using Model.Dao;
using QLNhaSachFahasa.Areas.Admin.Models;
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
        public ActionResult ReportByDay()
        {
            return View();
        }
        public ActionResult GetDataOrederSuccesss(DateTime month)
        {
            var list = new OrdersDao().GetListOrderForMonth(month);
            int sumSuccess = 0,sumCancel =0;
            double[] datasuccess = new double[31];
            for(int i = 1; i <= 31; i++)
            {
                int temp = 0;
                foreach (var item in list)
                {
                    if (item.NGAYCAPNHAT.Day == i && item.TRANGTHAI == 1)
                    {
                        temp += 1;
                        sumSuccess += 1;
                    }
                    datasuccess[i-1] = temp;
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
    }
}