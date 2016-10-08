﻿using System.Web.Mvc;
using System.Web.Routing;

namespace TPDDSGrupo44
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");



            routes.MapRoute(
                "AccionList",
                "Home/Acciones/List/{AccionID}",
                new { controller = "Home", action = "AccionList", AccionID = "" }
                );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
