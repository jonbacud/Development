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

           //supplier entry map route
           routes.MapPageRoute("supplier-entry",
                              "supplier/{mode}/{id}",
                              "~/SupplierEntry.aspx");

           //category entry map route
           routes.MapPageRoute("category-entry",
                              "category/{mode}/{id}",
                              "~/CategoryEntry.aspx");

           //receiving entry map route
           routes.MapPageRoute("receiving-entry",
                              "receiving/{mode}/{id}",
                              "~/ReceivingEntry.aspx");

           //receiving view entry map route
           routes.MapPageRoute("receiving-details",
                              "receiving-details/{mode}/{id}",
                              "~/ReceivingDetails.aspx");

           //receiving detail entry map route
           routes.MapPageRoute("receiving-detail",
                              "receiving-detail/{mode}/{id}",
                              "~/ReceivingDetailEntry.aspx");

            routes.MapPageRoute("requisition-entry",
                              "requisition/{mode}/{id}",
                              "~/RequisitionEntry.aspx");

            routes.MapPageRoute("requisition-detail",
                              "requisition-detail/{mode}/{id}",
                              "~/RequisitionDetailEntry.aspx");
            //issuance entry map route
            routes.MapPageRoute("issuance-entry",
                            "issuance/{mode}/{id}",
                            "~/ItemIssuanceEntry.aspx");

        }
    }
}
