using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace IPSAlyzer_v1
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
               name: "NoController",
               url: "{action}",
               defaults: new { controller = "Products", action = "Index"}
           );
          
/*
            routes.MapRoute(
               name: "Lang Action",
               url: "{lang}/{action}",
               defaults: new { controller = "Products", action = "Index", lang = UrlParameter.Optional },
               constraints: new { lang = "^en$|^zh$" }
           );
*/
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}",
                defaults: new { controller = "Products", action = "Index" }
            );


            
        }
    }
}
