﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace QLNhaSachFahasa
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            //routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "Register",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "User", action = "Register", id = UrlParameter.Optional },
                namespaces: new[] { "QLNhaSachFahasa.Controllers" }
            );
            routes.MapRoute(
                name: "Login",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "User", action = "Index", id = UrlParameter.Optional },
                namespaces: new[] { "QLNhaSachFahasa.Controllers" }
            );
            routes.MapRoute(
                 name: "Order",
                 url: "{controller}/{action}/{id}",
                 defaults: new { controller = "Order", action = "Index", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                 name: "Sale",
                 url: "{controller}/{action}/{id}",
                 defaults: new { controller = "Sale", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
