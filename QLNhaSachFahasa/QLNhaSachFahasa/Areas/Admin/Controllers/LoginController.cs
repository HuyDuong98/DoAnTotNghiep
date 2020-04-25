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
    public class LoginController : Controller
    {
        // GET: Admin/AdLogin
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Login(AdminLoginModel model)
        {
            if (ModelState.IsValid)
            {
                var dao = new AdminDao();
                var result = dao.LoginAdmin(model.UseeName, Encryptor.MD5Hash(model.Password));
                if (result == 1)
                {
                    var user = dao.GetByIdEmloyee(model.UseeName);
                    var userSession = new UserLogin();
                    userSession.UserName = user.USERNAMENV;
                    userSession.UserID = user.MANV;
                    userSession.Name = user.TENNV;
                    Session.Add(CommonConstants.USER_SEESION, userSession);
                    return RedirectToAction("Index", "AdHome");
                }
                else if (result == 2)
                {
                    ModelState.AddModelError("", "Tài khoản bị khóa.");
                }
                else if (result == 0)
                {
                    ModelState.AddModelError("", "Tài khoản không tồn tại.");
                }
                else if (result == -1)
                {
                    ModelState.AddModelError("", "Mật khẩu không đúng.");
                }
                else
                {
                    ModelState.AddModelError("", "Đăng nhập không thành công.");
                }
            }
            return View("Index");
        }
        public ActionResult Logout()
        {
            Session[CommonConstants.USER_SEESION] = null;
            return Redirect("/Admin");
        }
    }
}