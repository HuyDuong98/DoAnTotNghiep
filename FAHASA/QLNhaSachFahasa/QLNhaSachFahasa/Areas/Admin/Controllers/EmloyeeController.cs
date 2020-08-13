using Model.Dao;
using Model.EF;
using QLNhaSachFahasa.Areas.Admin.Models;
using QLNhaSachFahasa.Areas.Admin.ViewModels;
using QLNhaSachFahasa.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;
namespace QLNhaSachFahasa.Areas.Admin.Controllers
{
    public class EmloyeeController : BaseController
    {
        QLNhaSachFahasaDBContext db = new QLNhaSachFahasaDBContext();
        // GET: Admin/Emloyee
        [HasCredential(RoleId = "VIEW_EMPLOYEE")]
        public ActionResult Index()
        {
            //var employee = new List<EmployeeViewModel>();
            ////ViewBag.Title = "Employee";
            ////db.NHANVIENs.ToList().ForEach(p =>
            ////{
            ////    employee.Add(new EmployeeViewModel(p.MANV, p.TENNV, p.USERNAMENV, p.PASSWORDNV, p.DIACHINV, p.SDTNV, p.EMAIL, p.NGAYTAO, p.TRANGTHAI));
            ////});
            return View();
        }
        [HasCredential(RoleId = "CREATE_EMPLOYEE")]
        public ActionResult Create()
        {
            SetViewBag();
            return View();
        }
        public void SetViewBag()
        {
            var dao = new GroupUserDao();
            ViewBag.MANHOMNGUOIDUNG = new SelectList(dao.ListAll(), "MANHOMNGUOIDUNG", "TENNHOMNGUOIDUNG", "MEMBER");
        }
        [HasCredential(RoleId = "INFO_EMPLOYEE")]
        public ActionResult InfoEmployee(string id)
        {
            var model = new AdminDao().ViewDetail(id);
            var emp = new NhaVienModel()
            {
                MANHANVIEN = model.MANHANVIEN,
                TENNHANVIEN = model.TENNHANVIEN,
                TENDANGNHAPNHANVIEN = model.TENDANGNHAPNHANVIEN,
                EMAIL = model.EMAIL,
                DIACHINHANVIEN = model.DIACHINHANVIEN,
                SDT = model.SDT,
                NGAYTAO = model.NGAYTAO,
                NGAYSINH = model.NGAYSINH,
                CMND = model.CMND,
                HINHANH = model.HINHANH,
                LOAIHINHCONGVIEC = model.LOAIHINHCONGVIEC,
                CHUCVU = model.CHUCVU,
                TRANGTHAI = model.TRANGTHAI,
                MANHOMNGUOIDUNG = model.MANHOMNGUOIDUNG,
                NameGroup = new AdminDao().getNameGroup(model.MANHOMNGUOIDUNG)
            };

            return PartialView("~/Areas/Admin/Views/Emloyee/_InfoEmployee.cshtml", emp);
        }


        [HttpPost]
        public ActionResult Create(NhaVienModel model)
        {
            var message = 0;
            var dao = new AdminDao();
            if (dao.CheckUserNameEmloyee(model.TENDANGNHAPNHANVIEN))
            {
                message = -1;
            }
            else if (dao.CheckEmailEmloyee(model.EMAIL))
            {
                message = -2;

            }
            else
            {
                var user = new NHANVIEN()
                {
                    MANHANVIEN = dao.CreateIDAuto("NV"),
                    TENNHANVIEN = model.TENNHANVIEN,
                    TENDANGNHAPNHANVIEN = model.TENDANGNHAPNHANVIEN,
                    MATKHAUNHANVIEN = Encryptor.MD5Hash(model.MATKHAUNHANVIEN),
                    DIACHINHANVIEN = model.DIACHINHANVIEN,
                    EMAIL = model.EMAIL,
                    SDT = model.SDT,
                    NGAYSINH = model.NGAYSINH,
                    CMND = model.CMND,
                    HINHANH = model.HINHANH,
                    LOAIHINHCONGVIEC = model.LOAIHINHCONGVIEC,
                    CHUCVU = model.CHUCVU,
                    NGAYTAO = DateTime.Now,
                    MANHOMNGUOIDUNG = model.MANHOMNGUOIDUNG,
                    TRANGTHAI = true
                };

                var result = dao.InsertEmloyee(user);
                if (result != null)
                {
                    message = 1;
                    //model = new RegisterEmloyeeModel();
                }
                else
                {
                    message = 0;
                }
            }

            return Json(message, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        [HasCredential(RoleId = "EIDT_EMPLOYEE")]
        public ActionResult EditEmloyee(string id)
        {
            var model = new AdminDao().ViewDetail(id);
            var emp = new NhaVienModel()
            {
                MANHANVIEN = model.MANHANVIEN,
                TENNHANVIEN = model.TENNHANVIEN,
                TENDANGNHAPNHANVIEN = model.TENDANGNHAPNHANVIEN,
                MATKHAUNHANVIEN = model.MATKHAUNHANVIEN,
                DIACHINHANVIEN = model.DIACHINHANVIEN,
                EMAIL = model.EMAIL,
                SDT = model.SDT,
                NGAYSINH = model.NGAYSINH,
                CMND = model.CMND,
                HINHANH = model.HINHANH,
                LOAIHINHCONGVIEC = model.LOAIHINHCONGVIEC,
                CHUCVU = model.CHUCVU,
                TRANGTHAI = model.TRANGTHAI,
                MANHOMNGUOIDUNG = model.MANHOMNGUOIDUNG,
            };
            var dao = new GroupUserDao();
            ViewBag.MANHOMNGUOIDUNG = new SelectList(dao.ListAll(), "MANHOMNGUOIDUNG", "TENNHOMNGUOIDUNG", emp.MANHOMNGUOIDUNG);
            return PartialView("~/Areas/Admin/Views/Emloyee/_EditEmloyee.cshtml", emp);
        }


        //public ActionResult GetListEmloyee(string keywork)
        //{
        //    var res = new AdminDao().GetDataEmloyee(keywork);
        //    return Json(res, JsonRequestBehavior.AllowGet);
        //}
        [HttpPost]
        public ActionResult GetList(string keywork, string status)
        {
            var res = new AdminDao().GetDataEmloyee(keywork, status);

            return Json(res.Select(x => new
            {
                MANV = x.MANHANVIEN,
                TENNV = x.TENNHANVIEN,
                DIACHINV = x.DIACHINHANVIEN,
                SDTNV = x.SDT,
                EMAIL = x.EMAIL,
                NGAYTAO = x.NGAYTAO,
                TRANGTHAI = x.TRANGTHAI,
                MANHOMNGUOIDUNG = x.MANHOMNGUOIDUNG,
                USERNAMENV = x.TENDANGNHAPNHANVIEN
            }
            ), JsonRequestBehavior.AllowGet);
        }
        public ActionResult DeleteEmployee(string id)
        {
            var result = new AdminDao().DeleteEmployee(id);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public ActionResult UpdateStatusEmployee(string id)
        {
            var model = new AdminDao().ViewDetail(id);
            var dao = new AdminDao();
            ViewBag.TRANGTHAI = new SelectList(dao.ListEmployeeAll(), "TRANGTHAI", "TRANGTHAI", "--Chọn--");

            return PartialView("~/Areas/Admin/Views/Emloyee/_UpdateStatusEmployee.cshtml", model);
        }
        [HttpPost]
        public JsonResult ChangeStatusEmployee(string id)
        {
            var result = new AdminDao().ChangeStatus(id);
            return Json(new
            {
                status = result
            });

        }
        [HttpPost]
        public ActionResult EditEmloyee(NHANVIEN employee)
        {
            if (ModelState.IsValid)
            {
                var dao = new AdminDao();
                if (!string.IsNullOrEmpty(employee.MATKHAUNHANVIEN))
                {
                    employee.MATKHAUNHANVIEN = Encryptor.MD5Hash(employee.MATKHAUNHANVIEN);
                }
                var result = dao.UpdateEmloyee(employee);
                return Json(result);
            }
            return RedirectToAction("Index", "Emloyee");
        }


    }
}