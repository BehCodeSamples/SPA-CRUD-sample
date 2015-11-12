using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace WebApplication1
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
              name: "client",
              //GetView - префикс, который позволяет нам идентифицировать запросы от Angular роутера
              //далее урл парсится на contr и act (передаем в них имя папки и имя вьюхи)
              //и с этим параметрами вызывается экшен GetClientView из MVC контроллера Home
              url: "GetView/{contr}/{act}/{id}",
              defaults: new { controller = "Home", action = "GetClientView", act = UrlParameter.Optional , id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );

          
        }
    }
}
