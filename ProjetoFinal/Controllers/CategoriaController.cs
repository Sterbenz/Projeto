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
                RegistrarLog(familia, "REGISTROU ");
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
            ViewBag.Familias = familia;

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
                RegistrarLog(familia, "EDITOU");

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
            RegistrarLog(familia, "DELETOU");
            dao.Remover(familia);

            return Json(id);
        }

        public void RegistrarLog(FamiliaProduto familia, string modificacao)
        {
            Pessoa user = (Pessoa)Session["UsuarioLogado"];
            LogFamiliasDAO dao = new LogFamiliasDAO();
            LogFamilia log = new LogFamilia()
            {
                PessoaId = user.Id,
                PessoaNome = user.Nome,
                FamiliaId = familia.Id,
                FamiliaNome = familia.Nome,
                Descricao = "Funcionario " + user.Nome +" "+ modificacao + " a familia " + familia.Nome,
                DataModificacao = DateTime.Now
            };
            dao.Adiciona(log);
        }
    }
}