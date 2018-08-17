using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace ZarzadzanieNieruchomosciami
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                 name: "StronyStatyczne",
                 url: "strona/{nazwa}.html",
                 defaults: new { controller = "Home", action = "StronyStatyczne" });

            routes.MapRoute(
                name: "StronyKategori",
                url: "kategoria/{nazwa}.html",
                defaults: new { controller = "Zarzadzanie", action = "StronyKategori" });

            routes.MapRoute(
                 name: "StronaStartowa",
                 url: "Start/index.html",
                 defaults: new { controller = "Zarzadzanie", action = "Index" }
                 );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
