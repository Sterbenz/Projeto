using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProjetoFinal.DAO;
using ProjetoFinal.Filters;
using ProjetoFinal.Models;

namespace ProjetoFinal.Controllers
{
    [LoginFilter]
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult BuscaProduto(int id)
        {
            ProdutosDAO dao = new ProdutosDAO();
            Produto produto = new Produto();
            return Json(produto);
        }
    }
}