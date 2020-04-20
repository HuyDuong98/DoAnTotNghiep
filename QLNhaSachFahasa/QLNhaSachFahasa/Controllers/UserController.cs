using Model.Dao;
using QLNhaSachFahasa.Common;
using QLNhaSachFahasa.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QLNhaSachFahasa.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(RegisterModel model)
        {
            if(ModelState.IsValid)
            {

            }    
            return View(model);
        }
        public ActionResult Login(LoginModel model)
        {
            if(ModelState.IsValid)
            {
                var dao = new UserDao();
                var result = dao.Login(model.UseeName, Encryptor.MD5Hash( model.Password));
                if (result)
                {
                    var user = dao.GetById(model.UseeName);
                    var userSession = new UserLogin();
                    userSession.UserName = user.USERNAME;
                    userSession.UserID = user.MAKH;
                    Session.Add(CommonConstants.USER_SEESION, userSession);
                    return RedirectToAction("Index", "Home");
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