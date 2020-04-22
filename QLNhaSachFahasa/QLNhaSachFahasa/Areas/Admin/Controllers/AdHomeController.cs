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
            return View();
        }
    }
}