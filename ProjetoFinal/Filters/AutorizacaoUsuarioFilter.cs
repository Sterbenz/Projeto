using ProjetoFinal.DAO;
using ProjetoFinal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace ProjetoFinal.Filters
{
   
    public class AutorizacaoUsuarioFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            Pessoa user = (Pessoa) filterContext.HttpContext.Session["UsuarioLogado"];

            if (user == null)
            {
                filterContext.Result = new RedirectToRouteResult(
                            new RouteValueDictionary(
                               new { action = "Index", controller = "Login" }));
            }
            else
            {
                TipoPessoasDAO dao = new TipoPessoasDAO();
                TipoPessoa cargo = dao.BuscaPorId(user.TipoPessoaId);


                if (cargo.Nome == "Funcionario")
                {
                    filterContext.Result = new RedirectToRouteResult(
                                new RouteValueDictionary(
                                   new { action = "Errors", controller = "Home" }));
                }
            }
        }
    }
}