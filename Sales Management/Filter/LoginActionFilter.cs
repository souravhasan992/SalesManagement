using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace Sales_Management.Filter
{
    public class LoginActionFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (filterContext.Result != null) return;


            string UserName = filterContext.HttpContext.Session.GetString("UserName");
            if (string.IsNullOrEmpty(UserName))
            {
                filterContext.Result = new RedirectResult("~/Home/Login");
            }

        }
    }
}
