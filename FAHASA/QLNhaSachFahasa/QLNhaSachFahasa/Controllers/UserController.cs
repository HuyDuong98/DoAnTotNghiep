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
    public class UserController : FahasaController
    {
        // GET: User

        public ActionResult Index(bool islogin)
        {
            ViewBag.isLogin = islogin;
            return PartialView("Index");
        }
        public ActionResult Login(LoginModel model)
        {
            int message = 0;
            var dao = new UserDao();
            var result = dao.Login(model.UseeName, Encryptor.MD5Hash(model.Password));
            if (result == 1)
            {
                var user = dao.GetById(model.UseeName);
                var userSession = new UserLogin();
                userSession.UserName = user.TENDANGNHAPKHACHHANG;
                userSession.UserID = user.MAKHACHHANG;
                userSession.Name = user.TENKHACHHANG + " " + user.HOKHACHHANG;
                Session[CartSession.OrderSesstion] = null;
                Session[CommonConstants.USER_SEESION] = null;
                Session[CommonConstants.SESSION_CREDENTIALS] = null;
                Session.Add(CommonConstants.USER_SEESION, userSession);
                //return RedirectToAction("Index", "Home");
                message = 1;
            }
            else if (result == 0)
            {
                //ModelState.AddModelError("", "Tài khoản không tồn tại.");
                message = -2;
            }
            else if (result == -1)
            {
                //ModelState.AddModelError("", "Mật khẩu không đúng.");
                message = -1;
            }
            return Json(message, JsonRequestBehavior.AllowGet);
        }
        public ActionResult Logout()
        {
            Session[CommonConstants.USER_SEESION] = null;
            return Redirect("/");
        }
        [HttpGet]
        public ActionResult Register()
        {
            return PartialView("_Register");
        }
        [HttpPost]
        public ActionResult Register(LoginModel model)
        {
            int message = 0;
            var dao = new UserDao();
            if (dao.CheckUserName(model.UserName))
            {
                //ModelState.AddModelError("", "Tên đăng nhập đã tồn tại.");
                message = -2;
            }
            else if (dao.CheckEmail(model.Email))
            {
                //ModelState.AddModelError("", "Email đã tồn tại.");
                message = -3;
            }
            else
            {
                var user = new KHACHHANG();
                user.MAKHACHHANG = dao.CreateIDAuto("KH");
                user.HOKHACHHANG = model.HoKH;
                user.TENKHACHHANG = model.TenKH;
                user.EMAIL = model.Email;
                user.DIENTHOAI = model.Phone;
                user.DIACHI = model.Address;
                user.TENDANGNHAPKHACHHANG = model.UserName;
                user.MATKHAUKHACHHANG = Encryptor.MD5Hash(model.Password);
                user.NGAYTAO = DateTime.Now;
                user.TRANGTHAI = 1;
                var result = dao.Insert(user);
                if (result != null)
                {
                    //ViewBag.Success = "Đăng ký thành công";
                    message = 1;
                    //model = new LoginModel();

                }
                else
                {
                    //ModelState.AddModelError("", "Đăng ký không thành công.");
                    message = -1;
                }
            }
            return Json(message, JsonRequestBehavior.AllowGet);
        }
        public ActionResult ForgotPassword()
        {
            return PartialView("_ForgotPassword");
        }
        public ActionResult InputCode()
        {
            return PartialView("_InputCode");
        }
        public ActionResult ChangePassword()
        {
            return PartialView("_ChangePassword");
        }
        public ActionResult ProcessForgotPassword(string email)
        {
            int message = 0;
            var isEmail = new UserDao().IsEmail(email);
            if (isEmail)
            {
                Random rnd = new Random();
                int code = rnd.Next(100000, 999999);
                var session = new ForgotPasswordModel()
                {
                    code = code,
                    email = email
                };
                Session.Add(CommonConstants.CODE_SESSION, session);
                //Gửi mail
                string smtpUserName = "duongngochuy.hufi@gmail.com";
                string smtpPassword = "NgocHuy@123";
                string smtpHost = "smtp.gmail.com";
                int smtpPort = 587;

                string emailTo = email;
                string subject = "Mã xác nhận website Fahasa";
                string body = string.Format("Bạn vừa nhận được liên hê từ: <b>{0}</b><br/>Email: {1}<br/>Mã xác nhận của bạn là: " + code, "Fahasa ", "");

                EmailService service = new EmailService();
                bool kq = service.Send(smtpUserName, smtpPassword, smtpHost, smtpPort, emailTo, subject, body);
                message = 1;
            }
            else
            {
                message = -1;
            }
            return Json(message, JsonRequestBehavior.AllowGet);
        }

        public ActionResult ResentCode()
        {
            var session = (ForgotPasswordModel)Session[CommonConstants.CODE_SESSION];
            Random rnd = new Random();
            int code = rnd.Next(100000, 999999);
            var newSession = new ForgotPasswordModel()
            {
                email = session.email,
                code = code
            };
            Session[CommonConstants.CODE_SESSION] = null;
            Session.Add(CommonConstants.CODE_SESSION, newSession);
            //Gửi mail
            string smtpUserName = "duongngochuy.hufi@gmail.com";
            string smtpPassword = "ngochuy123";
            string smtpHost = "smtp.gmail.com";
            int smtpPort = 587;

            string emailTo = session.email;
            string subject = "Mã xác nhận website Fahasa";
            string body = string.Format("Bạn vừa nhận được liên hê từ: <b>{0}</b><br/>Email: {1}<br/>Mã xác nhận của bạn là: " + code, "Fahasa ", "");

            EmailService service = new EmailService();
            bool kq = service.Send(smtpUserName, smtpPassword, smtpHost, smtpPort, emailTo, subject, body);

            return Json(kq, JsonRequestBehavior.AllowGet);
        }
        public ActionResult SubmitCode(int code)
        {
            var message = 0;
            var session = (ForgotPasswordModel)Session[CommonConstants.CODE_SESSION];
            if(session.code==code && session.code!=0)
            {
                message = 1;
            }
            else
            {
                message = -1;
            }    
       
            return Json(message, JsonRequestBehavior.AllowGet);
        }
        public ActionResult RemoveCode()
        {
            var message = 0;
            var session = (ForgotPasswordModel)Session[CommonConstants.CODE_SESSION];
            var newSession = new ForgotPasswordModel()
            {
                email = session.email,
                code = 0,
            };
            Session[CommonConstants.CODE_SESSION] = null;
            Session.Add(CommonConstants.CODE_SESSION, newSession);
            return Json(message, JsonRequestBehavior.AllowGet);
        }
        public ActionResult SaveNewPassword(string newPass)
        {
            var message=0;
            var session = (ForgotPasswordModel)Session[CommonConstants.CODE_SESSION];
            message = new UserDao().UpdatePasswordCustomer(session.email, Encryptor.MD5Hash(newPass));
            return Json(message, JsonRequestBehavior.AllowGet);
        }
        public ActionResult CustomerInformation()
        {
            return View();
        } 
    }
}