using Model.Dao;
using Model.EF;
using QLNhaSachFahasa.Areas.Admin.Models;
using QLNhaSachFahasa.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QLNhaSachFahasa.Areas.Admin.Controllers
{
    public class CustomerController : BaseController
    {
        // GET: Admin/Customer
        [HasCredential(RoleId = "VIEW_CUSTOMER")]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult GetListCustomer(string keywork)
        {
            var res = new CustomerDao().GetDataCustomer(keywork);
            List<CustomerModel> model = new List<CustomerModel>();
            foreach (var item in res)
            {
                model.Add(new CustomerModel
                {
                    MAKH = item.MAKHACHHANG,
                    //MANHOMNGUOIDUNG= item.MANHOMNGUOIDUNG,
                    HOKH = item.HOKHACHHANG,
                    TENKH = item.TENKHACHHANG,
                    EMAIL = item.EMAIL,
                    DIENTHOAI = item.DIENTHOAI,
                    QUOCGIA = item.QUOCGIA,
                    THANHPHO = item.THANHPHO,
                    QUAN = item.QUAN,
                    PHUONG = item.PHUONG,
                    DIACHI = item.DIACHI,
                    USERNAME = item.TENDANGNHAPKHACHHANG,
                    PASSWORD = item.MATKHAUKHACHHANG,
                    NGAYTAO = item.NGAYTAO

                });
            }
           
            return Json(model, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        [HasCredential(RoleId = "EDIT_CUSTOMER")]
        public ActionResult Edit(string id)
        {
            var model = new CustomerDao().ViewDetail(id);
            var customer = new CustomerModel();
            customer.MAKH = model.MAKHACHHANG;
            customer.TENKH = model.TENKHACHHANG;
            customer.HOKH = model.HOKHACHHANG;
            customer.EMAIL = model.EMAIL;
            customer.DIENTHOAI = model.DIENTHOAI;
            //customer.QUOCGIA = model.QUOCGIA;
            //customer.THANHPHO = model.THANHPHO;
            //customer.QUAN = model.QUAN;
            //customer.PHUONG = model.PHUONG;
            customer.DIACHI = model.DIACHI;
            customer.USERNAME = model.TENDANGNHAPKHACHHANG;
            return PartialView("~/Areas/Admin/Views/Customer/_Edit.cshtml", customer);
        }
        [HttpPost]
        public ActionResult Edit(KHACHHANG customer)
        {
            if (ModelState.IsValid)
            {
                var dao = new CustomerDao();

                if (!string.IsNullOrEmpty(customer.MATKHAUKHACHHANG))
                {
                    customer.MATKHAUKHACHHANG = Encryptor.MD5Hash(customer.MATKHAUKHACHHANG);
                }
                var result = dao.UpdateCustomer(customer);
                if (result)
                {
                    ModelState.AddModelError("", "Cập nhật thành công.");
                    return RedirectToAction("Index", "Customer");
                }
                else
                {
                    ModelState.AddModelError("", "Cập nhật không thành công.");
                }
            }

            return RedirectToAction("Index", "Customer");
        }
        [HasCredential(RoleId = "DELETE_CUSTOMER")]
        public ActionResult Delete(string id)
        {
            var result = new CustomerDao().Delete(id);
            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}