using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace Sales_Management.Filter
{
    public class ProductActionFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (filterContext.Result != null) return;

            var UserType = filterContext.HttpContext.Session.GetInt32("UserType");
            if (UserType != 2)
            {
                filterContext.Result = new RedirectResult("~/Home/Login");
            }

        }
    }
}
