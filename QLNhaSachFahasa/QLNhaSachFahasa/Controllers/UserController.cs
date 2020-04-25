using Model.Dao;
using Model.EF;
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

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Login(LoginModel model)
        {
            if(ModelState.IsValid)
            {
                var dao = new UserDao();
                var result = dao.Login(model.UseeName, Encryptor.MD5Hash( model.Password));
                if (result==1)
                {
                    var user = dao.GetById(model.UseeName);
                    var userSession = new UserLogin();
                    userSession.UserName = user.USERNAME;
                    userSession.UserID = user.MAKH;
                    userSession.Name = user.TENKH+" "+user.HOKH;
                    Session.Add(CommonConstants.USER_SEESION, userSession);
                    return RedirectToAction("Index", "Home");
                }else if(result == 0)
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
            return Redirect("/");
        }
        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                var dao = new UserDao();
                if(dao.CheckUserName(model.UserName))
                {
                    ModelState.AddModelError("", "Tên đăng nhập đã tồn tại.");
                }else if(dao.CheckEmail(model.Email))
                {
                    ModelState.AddModelError("", "Email đã tồn tại.");

                }
                else
                {
                    var user = new KHACHHANG();
                    user.MAKH = dao.CreateIDAuto("KH");
                    user.HOKH = model.HoKH;
                    user.TENKH = model.TenKH;
                    user.EMAIL = model.Email;
                    user.DIENTHOAI = model.Phone;
                    user.QUOCGIA = model.QuocGia;
                    user.THANHPHO = model.ThanhPho;
                    user.QUAN = model.Quan;
                    user.PHUONG = model.Phuong;
                    user.DIACHI = model.Address;
                    user.USERNAME = model.UserName;
                    user.PASSWORD = Encryptor.MD5Hash(model.Password);
                    user.NGAYTAO = DateTime.Now;
                    var result = dao.Insert(user);
                    if (result != null)
                    {
                        ViewBag.Success = "Đăng ký thành công";
                        model = new RegisterModel();

                    }else
                    {
                        ModelState.AddModelError("", "Đăng ký không thành công.");
                    }    
                }
            }
            return View(model);
        }
    }
}