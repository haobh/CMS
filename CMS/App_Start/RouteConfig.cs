using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace CMS
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
               name: "Home",
               url: "Admin/Home/Index",
               defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
           );
            //Route User Index
            routes.MapRoute(
               name: "User Index",
               url: "Admin/User/Index",
               defaults: new { controller = "User", action = "Index", id = UrlParameter.Optional }
           );
            //Route User Create
            routes.MapRoute(
               name: "User Create",
               url: "Admin/User/Create",
               defaults: new { controller = "User", action = "Create", id = UrlParameter.Optional }
           );
            //Route User Edit
            routes.MapRoute(
               name: "User Edit",
               url: "Admin/User/Edit",
               defaults: new { controller = "User", action = "Edit", id = UrlParameter.Optional }
           );
            //Route User Delete
            routes.MapRoute(
               name: "User Delete",
               url: "Admin/User/Delete",
               defaults: new { controller = "User", action = "Delete", id = UrlParameter.Optional }
           );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
