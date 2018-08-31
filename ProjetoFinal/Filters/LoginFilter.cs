using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace ProjetoFinal.Filters
{
    public class LoginFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            object userLogado = filterContext.HttpContext.Session["UsuarioLogado"];
            if(userLogado == null)
            {
                filterContext.Result = new RedirectToRouteResult(
                            new RouteValueDictionary(
                               new { action = "Index", controller = "Login" }));
            }
        }
    }
}