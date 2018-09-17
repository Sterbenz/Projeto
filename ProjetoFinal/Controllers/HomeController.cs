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
            Produto produto = dao.BuscaPorId(id);
            return Json(produto);
        }

        public ActionResult Logs()
        {
            FornecedoresDAO forDAO = new FornecedoresDAO();
            PessoasDAO pesDAO = new PessoasDAO();
            FamiliaProdutoDAO famDAO = new FamiliaProdutoDAO();
            ProdutosDAO proDAO = new ProdutosDAO();           
            
            ViewBag.LogPessoas = pesDAO.Lista();
            ViewBag.LogFornecedores = forDAO.Lista();
            ViewBag.LogFamilias = famDAO.Lista();
            ViewBag.LogProdutos = proDAO.Lista();

            return View();
        }
    }
}