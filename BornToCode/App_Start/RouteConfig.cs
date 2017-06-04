using System.Web.Mvc;
using System.Web.Routing;

namespace BornToCode
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute("Default", "",
                new { controller = "Home", action = "AllArticles", id = UrlParameter.Optional }
            );

            //routes.MapRoute("Default", "{controller}/{action}/{id}",
            //    new { controller = "Home", action = "AllArticlesIndex", id = "" }
            //);
        }
    }
}
