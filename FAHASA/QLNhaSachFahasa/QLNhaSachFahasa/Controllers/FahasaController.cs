using QLNhaSachFahasa.UtilityHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;

namespace QLNhaSachFahasa.Controllers
{
    public class FahasaController : Controller
    {
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