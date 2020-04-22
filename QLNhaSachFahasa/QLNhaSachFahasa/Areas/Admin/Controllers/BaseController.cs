using QLNhaSachFahasa.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace QLNhaSachFahasa.Areas.Admin.Controllers
{
    public class BaseController : Controller
    {
        // GET: Admin/Base
        protected override void OnActionExecuting ( ActionExecutingContext filterContext)
        {
            var session = (UserLogin)Session[CommonConstants.USER_SEESION];
            if(session==null)
            {
                filterContext.Result = new RedirectToRouteResult(new
                    RouteValueDictionary(new { Controller = "Login", Action = "Index"}));
            }
            base.OnActionExecuting(filterContext);

        }
    }
}