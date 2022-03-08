using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Filters;

namespace WebApplication16.Helper
{
    public class CustomAuthenticationAttribute : ActionFilterAttribute, IAuthenticationFilter
    {

        public void OnAuthentication(AuthenticationContext filterContext)
        {
            var action = filterContext.ActionDescriptor;
            var controller = action.ControllerDescriptor;

            if (action.IsDefined(typeof(AllowAnonymousAttribute), true))
            {
                return;
            }
            if (controller.IsDefined(typeof(AllowAnonymousAttribute), true))
            {
                return;
            }
            SystemInfoForSession SessionData = SessionHelper.GetSession();
            if (SessionData == null)
            {
                filterContext.Result = new HttpUnauthorizedResult();
            }

        }

        public void OnAuthenticationChallenge(AuthenticationChallengeContext filterContext)
        {
            if (filterContext.Result is null || filterContext.Result is HttpUnauthorizedResult)
            {
                filterContext.Result = new RedirectToRouteResult("Default", new System.Web.Routing.RouteValueDictionary
                {
                    { "controller", "Account" },
                    { "action", "Login" },
                    { "returnUrl", filterContext.HttpContext.Request.RawUrl }
                });
            }
        }
    }
}