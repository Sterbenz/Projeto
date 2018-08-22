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
            if (ModelState.IsValid)
            {
                FamiliaProdutoDAO dao = new FamiliaProdutoDAO();
                dao.Adiciona(familia);

                return RedirectToAction("Index", "Categoria");
            }
            else
            {
                return View("Form");
            }
        }

        public ActionResult Editar(int id)
        {
            FamiliaProdutoDAO dao = new FamiliaProdutoDAO();
            FamiliaProduto familia = dao.BuscaPorId(id);           
            ViewBag.Familia = familia;

            return View();
        }

        public ActionResult Edita(int id, FamiliaProduto familia)
        {
            if (ModelState.IsValid)
            {
                FamiliaProdutoDAO dao = new FamiliaProdutoDAO();
                FamiliaProduto f = dao.BuscaPorId(id);
                f.Nome = familia.Nome;                
                f.Descricao = familia.Descricao;                
                dao.Atualiza(f);

                return RedirectToAction("Index", "Categoria");
            }
            else
            {
                return RedirectToAction("Editar", "Categoria", new { id });
            }
        }

        public ActionResult Remover(int id)
        {
            FamiliaProdutoDAO dao = new FamiliaProdutoDAO();
            FamiliaProduto familia = dao.BuscaPorId(id);
            dao.Remover(familia);

            return RedirectToAction("Index", "Categoria");
        }
    }
}