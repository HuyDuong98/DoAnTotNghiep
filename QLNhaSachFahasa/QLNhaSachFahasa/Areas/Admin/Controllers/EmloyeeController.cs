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
        QLNhaSachFahasaDBContext db =  new QLNhaSachFahasaDBContext();
        // GET: Admin/Emloyee
        public ActionResult Index()
        {
            var employee = new List<EmployeeViewModel>();
            db.NHANVIENs.ToList().ForEach(p =>
            {
                employee.Add(new EmployeeViewModel(p.MANV, p.TENNV, p.DIACHINV, p.SDTNV, p.EMAIL, p.NGAYTAO, p.TRANGTHAI));
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
                    var result = dao.InsertEmloyee(user);
                    if (result != null)
                    {
                        ViewBag.Success = "Đăng ký thành công";
                        model = new RegisterEmloyeeModel();
                    }
                    else
                    {
                        ModelState.AddModelError("", "Đăng ký không thành công.");
                    }
                }
            }
            return View(model);
        }
        public ActionResult EditEmloyee(string id)
        {
            var model = new AdminDao().ViewDetail(id);
            return PartialView("~/Areas/Admin/Views/Emloyee/_EditEmloyee.cshtml", model);
        }
        [HttpPost]
        public ActionResult EditEmloyee(RegisterEmloyeeModel model)
        {
            if (ModelState.IsValid)
            {
                var dao = new AdminDao();
                var user = new NHANVIEN();
                //user.TENNV = model.TenNV;
                //user.PASSWORDNV = Encryptor.MD5Hash(model.Password);
                //user.DIACHINV = model.DiaChi;
                //user.EMAIL = model.Email;
                //user.SDTNV = model.SDT;
                //user.NGAYTAO = DateTime.Now;
                if(!string.IsNullOrEmpty(user.PASSWORDNV))
                {
                    user.PASSWORDNV = Encryptor.MD5Hash(model.Password);
                }
                var result = dao.UpdateEmloyee(user);
                if (result)
                {
                    return RedirectToAction("Edit", "Emloyee");
                }
                else
                {
                    ModelState.AddModelError("", "Cập nhật thành công.");
                }
            }
                return View("Edit");
            }
        }
    }