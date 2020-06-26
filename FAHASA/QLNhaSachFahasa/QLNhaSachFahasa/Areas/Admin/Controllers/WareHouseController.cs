using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QLNhaSachFahasa.Areas.Admin.Controllers
{
    public class WareHouseController : BaseController
    {
        // GET: Admin/WareHouse
        QLNhaSachFahasaDBContext db = new QLNhaSachFahasaDBContext();
        public ActionResult Index()
        {
            return View();
        }
    }
}