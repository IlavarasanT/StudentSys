using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace StudentMarkSys.Utility
{
    public class MyutilityClass : AuthorizeAttribute
    {
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            if (filterContext.HttpContext.Session["EmailId"] == null || string.IsNullOrWhiteSpace(filterContext.HttpContext.Session["EmailId"].ToString()))
            {
                filterContext.HttpContext.Session.Abandon();
                filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new
                {
                    controller = "Login",
                    action = "Loginval",
                }));
            }
        }
    }
}