using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace ExamOnline
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.MapRoute(
               name: "CreateQuestion",
               url: "questions/Create",
               defaults: new { controller = "QuestionViewModels", action = "Create" }
           );
            routes.MapRoute(
               name: "Question",
               url: "questions/{action}",
               defaults: new { controller = "QuestionViewModels", action = "Create" }
           );
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
