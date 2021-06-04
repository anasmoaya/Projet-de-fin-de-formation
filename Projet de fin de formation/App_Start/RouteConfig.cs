using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Projet_de_fin_de_formation
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Login",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Login", action="Login",  id = UrlParameter.Optional }
                );

            routes.MapRoute(
                name: "ClientLogin",
                url: "{controller}/{action}",
                defaults: new { controller = "ClientUser", action = "Index"}
                );
        }
    }
}
