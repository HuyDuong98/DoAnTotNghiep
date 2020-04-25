using Model.Dao;
using Model.EF;
using QLNhaSachFahasa.Areas.Admin.Models;
using QLNhaSachFahasa.Areas.Admin.ViewModels;
using QLNhaSachFahasa.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
namespace QLNhaSachFahasa.Areas.Admin.Controllers
{
    public class EmloyeeController : BaseController
    {
        QLNhaSachFahasaDBContext db = new QLNhaSachFahasaDBContext();
        // GET: Admin/Emloyee
        public ActionResult Index()
        {
            var employee = new List<EmployeeViewModel>();
            ViewBag.Title = "Employee";
            db.NHANVIENs.ToList().ForEach(p =>
            {
                employee.Add(new EmployeeViewModel(p.MANV, p.TENNV, p.USERNAMENV, p.PASSWORDNV, p.DIACHINV, p.SDTNV, p.EMAIL, p.NGAYTAO, p.TRANGTHAI));
            });
            return View(employee);
        }
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(RegisterEmloyeeModel model)
        {
            if (ModelState.IsValid)
            {
                var dao = new AdminDao();
                if (dao.CheckUserNameEmloyee(model.UserName))
                {
                    ModelState.AddModelError("", "Tên đăng nhập đã tồn tại.");
                }
                else if (dao.CheckEmailEmloyee(model.Email))
                {
                    ModelState.AddModelError("", "Email đã tồn tại.");

                }
                else
                {
                    var user = new NHANVIEN();
                    user.MANV = dao.CreateIDAuto("NV");
                    user.TENNV = model.TenNV;
                    user.USERNAMENV = model.UserName;
                    user.PASSWORDNV = Encryptor.MD5Hash(model.Password);
                    user.DIACHINV = model.DiaChi;
                    user.EMAIL = model.Email;
                    user.SDTNV = model.SDT;
                    user.NGAYTAO = DateTime.Now;
                    user.TRANGTHAI = true;
                    var result = dao.InsertEmloyee(user);
                    if (result != null)
                    {
                        ViewBag.Success = "Đăng ký thành công";
                        return RedirectToAction("Index", "Emloyee");
                        //model = new RegisterEmloyeeModel();
                    }
                    else
                    {
                        ModelState.AddModelError("", "Đăng ký không thành công.");
                    }
                }
            }
            return View(model);
        }
        [HttpGet]
        public ActionResult EditEmloyee(string id)
        {
            var model = new AdminDao().ViewDetail(id);
            return PartialView("~/Areas/Admin/Views/Emloyee/_EditEmloyee.cshtml", model);
        }
        
      
        public ActionResult GetListEmloyee(string keywork)
        {
            var res = new AdminDao().GetDataEmloyee(keywork);
            return Json(res, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult GetList(string keywork)
        {
            var res = new AdminDao().GetDataEmloyee(keywork);
            return Json(res, JsonRequestBehavior.AllowGet);
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
            }) ;

        }
        [HttpPost]
        public ActionResult EditEmloyee(NHANVIEN employee)
        {
            if (ModelState.IsValid)
            {
                var dao = new AdminDao();
                var result = dao.UpdateEmloyee(employee);
                if (result)
                {
                    return RedirectToAction("Index", "Emloyee");
                }
                else
                {
                    ModelState.AddModelError("", "Cập nhật không thành công.");
                }
            }
            return RedirectToAction("Index", "Emloyee");
        }
    }
}