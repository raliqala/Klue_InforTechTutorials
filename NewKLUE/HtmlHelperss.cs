using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NewKLUE
{
    public class HtmlHelperss
    {

    }
    public static class HtmlRequestHelper
    {
        public static string Id(this HtmlHelperss htmlHelper)
        {
            var routeValues = HttpContext.Current.Request.RequestContext.RouteData.Values;

            if (routeValues.ContainsKey("id"))
                return (string)routeValues["id"];
            else if (HttpContext.Current.Request.QueryString.AllKeys.Contains("id"))
                return HttpContext.Current.Request.QueryString["id"];

            return string.Empty;
        }

        public static string Controller(this HtmlHelperss htmlHelper)
        {
            var routeValues = HttpContext.Current.Request.RequestContext.RouteData.Values;

            if (routeValues.ContainsKey("controller"))
                return (string)routeValues["controller"];

            return string.Empty;
        }

        public static string Action(this HtmlHelperss htmlHelper)
        {
            var routeValues = HttpContext.Current.Request.RequestContext.RouteData.Values;

            if (routeValues.ContainsKey("action"))
                return (string)routeValues["action"];

            return string.Empty;
        }

        public static string Area(this HtmlHelperss htmlHelper)
        {
            var dataTokens = HttpContext.Current.Request.RequestContext.RouteData.DataTokens;

            if (dataTokens.ContainsKey("area"))
                return (string)dataTokens["area"];

            return string.Empty;
        }
    }
}