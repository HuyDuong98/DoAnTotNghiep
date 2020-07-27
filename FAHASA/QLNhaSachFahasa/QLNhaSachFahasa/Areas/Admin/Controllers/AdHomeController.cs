using Model.Dao;
using QLNhaSachFahasa.Areas.Admin.Models;
using QLNhaSachFahasa.Common;
using QLNhaSachFahasa.UtilityHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QLNhaSachFahasa.Areas.Admin.Controllers
{
    public class AdHomeController : BaseController
    {
        // GET: Admin/AdHome
        public ActionResult Index()
        {
            var session = (UserLogin)Session[CommonConstants.USER_SEESION];
            
            if (session.GroupID == "ADMIN")
            {
                var emp = new MenuDao().ListMenuHomeAdmin();
                return View(emp);
            }
            else if(session.GroupID == "LEADER")
            {
                var emp = new MenuDao().ListMenuHomeLeaderr();
                return View(emp);
            }
            else
            {
                var emp = new MenuDao().ListMenuHomeMember();
                return View(emp);
            }
        }
        public ActionResult Change(string languageAbbrevation)
        {
            if (languageAbbrevation == "vi")
            {
                CurrentLanguage = LanguageCulture.VIETNAMESE.Value;
            }
            else
            {
                CurrentLanguage = LanguageCulture.ENGLISH.Value;
            }

            string urlReferrer = Request.UrlReferrer.ToString();
            if (string.IsNullOrWhiteSpace(urlReferrer))
            {
                urlReferrer = "/Login";
            }

            return Redirect(urlReferrer);
        }
    }
}