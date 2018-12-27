using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace myHotel.Filter
{
    
     public class AuthorizeAdmin : System.Web.Mvc.ActionFilterAttribute, System.Web.Mvc.IActionFilter
    {

        public override void OnActionExecuting(System.Web.Mvc.ActionExecutingContext filterContext)
        {
            var name = HttpContext.Current.Session["UserName"].ToString();
            if (name == null)
            {
                filterContext.Result = new System.Web.Mvc.RedirectToRouteResult(new System.Web.Routing.RouteValueDictionary
                {
                    {"Controller", "Home"},
                    {"Action", "Login"}
                });
            }
            //  var name = HttpContext.Current.Session["UserName"].ToString();
            else if (name == "Admin" && name != null)
            {
                base.OnActionExecuting(filterContext);
            }
        }
    }
}
