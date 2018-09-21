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

        [AutorizacaoUsuarioFilter]
        public ActionResult Logs()
        {
            LogFornecedoresDAO forDAO = new LogFornecedoresDAO();
            LogPessoasDAO pesDAO = new LogPessoasDAO();
            LogFamiliasDAO famDAO = new LogFamiliasDAO();
            LogProdutosDAO proDAO = new LogProdutosDAO();           
            
            ViewBag.LogPessoas = pesDAO.Lista();
            ViewBag.LogFornecedores = forDAO.Lista();
            ViewBag.LogFamilias = famDAO.Lista();
            ViewBag.LogProdutos = proDAO.Lista();

            return View();
        }

        public ActionResult Errors()
        {

            throw new DivideByZeroException();
        }
    }
}