using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

using System.Web.Compilation;
using System.Web.UI;

namespace ReportsWithMVC
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.Add("ReportRoute", new Route("report/{ReportName}", new ReportRouteHandler()));


            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }

    internal class ReportRouteHandler : IRouteHandler
    {
        public IHttpHandler GetHttpHandler(RequestContext requestContext)
        {
            string ReportName = requestContext.RouteData.Values["ReportName"].ToString();

            SSRS.ReportWebForm rwf = BuildManager.CreateInstanceFromVirtualPath(
                                                "~/SSRS/ReportWebForm.aspx",
                                                typeof(Page)
                                        ) as SSRS.ReportWebForm;
            rwf.ReportServerURL = "http://142.55.32.96/reportserver";

            Dictionary<string, string> ReportList = new Dictionary<string, string>();
            ReportList.Add("customers", "/Winter2018/DylanMcCowan/CustomerContactList");
            ReportList.Add("orders", "/Winter2018/DylanMcCowan/OrderAmount");
            ReportList.Add("sales", "/Winter2018/DylanMcCowan/SalesByTerritory");
            ReportList.Add("products", "/Winter2018/DylanMcCowan/ProductsFilteredByCategoryName");

            rwf.ReportPath = ReportList[ReportName.ToLower()];

            return rwf;
        }
    }
}
