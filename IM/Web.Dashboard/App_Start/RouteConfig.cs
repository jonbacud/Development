using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Routing;
using Microsoft.AspNet.FriendlyUrls;

namespace Web.Dashboard
{
    public static class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
           routes.EnableFriendlyUrls();
           //item entry map route
           routes.MapPageRoute("item-entry", 
                                "item/{mode}/{id}", 
                                "~/ItemEntry.aspx");
           //department entry map route
           routes.MapPageRoute("department-entry",
                              "department/{mode}/{id}",
                              "~/DepartmentEntry.aspx");
        }
    }
}
