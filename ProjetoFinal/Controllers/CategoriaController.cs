using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProjetoFinal.DAO;
using ProjetoFinal.Models;


namespace ProjetoFinal.Controllers
{
    public class CategoriaController : Controller
    {
        // GET: Categoria
        public ActionResult Index()
        {
            FamiliaProdutoDAO dao = new FamiliaProdutoDAO();
            IList<FamiliaProduto> familias = dao.Lista();
            ViewBag.Familias = familias;

            return View();
        }

        public ActionResult Form()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Adiciona(FamiliaProduto familia)
        {
            FamiliaProdutoDAO dao = new FamiliaProdutoDAO();
            dao.Adiciona(familia);

            return View("Index");
        }
    }
}