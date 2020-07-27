using QLNhaSachFahasa.Common;
using QLNhaSachFahasa.UtilityHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;
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
        public static string CurrentLanguage;
        // GET: Fahasa
        protected override void Initialize(System.Web.Routing.RequestContext requestContext)
        {

            if (string.IsNullOrWhiteSpace(CurrentLanguage))
            {
                CurrentLanguage = LanguageCulture.VIETNAMESE.Value;
            }

            // Modify current thread's cultures            
            Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo(CurrentLanguage);
            Thread.CurrentThread.CurrentUICulture = Thread.CurrentThread.CurrentCulture;

            base.Initialize(requestContext);
        }
    }
}