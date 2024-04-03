using Budget.MODEL;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Budget.API.Helpers
{
    public class LanguageAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (filterContext.HttpContext.Session != null)
            {
                var toto = filterContext.HttpContext.User.FindFirst(ClaimTypes.Locality)?.Value;
                //var user = filterContext.HttpContext.Session["toto"];
                //if (user != null && string.IsNullOrEmpty(user.FirstName))
                //    //filterContext.Result = new RedirectResult("/home/firstname");
                //else
                //{
                //    //what ever you want, or nothing at all
                //}
            }
        }
    }
}
