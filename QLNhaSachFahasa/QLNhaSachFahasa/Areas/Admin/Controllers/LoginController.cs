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
                var dao = new UserDao();
                var result = dao.LoginAdmin(model.UseeName, Encryptor.MD5Hash(model.Password));
                if (result == 1)
                {
                    var user = dao.GetById(model.UseeName);
                    var userSession = new UserLogin();
                    userSession.UserName = user.USERNAME;
                    userSession.UserID = user.MAKH;
                    Session.Add(CommonConstants.USER_SEESION, userSession);
                    return RedirectToAction("Index", "AdHome");
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
    }
}