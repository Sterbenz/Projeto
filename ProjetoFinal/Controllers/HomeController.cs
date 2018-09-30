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
            AcompanhamentoFornecedoresDAO dao = new AcompanhamentoFornecedoresDAO();
            FornecedoresDAO fornDAO = new FornecedoresDAO();
            ViewBag.Acompanhamentos = dao.ListaPendentes();
            ViewBag.Fornecedores = fornDAO.Lista();
            return View();
        }

        public ActionResult BuscaProduto(int id)
        {
            ProdutosDAO dao = new ProdutosDAO();
            Produto produto = dao.BuscaPorId(id);
            return Json(produto);
        }

        public ActionResult BuscaCliente(int id)
        {
            PessoasDAO dao = new PessoasDAO();
            Pessoa cliente = dao.BuscaPorId(id);
            return Json(cliente);
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

        [HandleError(View = "Error")]
        public ActionResult Errors()
        {
            return View();
        }


        public void Testes()
        {
            //PedidosDAO da = new PedidosDAO();
            ////////var p1 = new Produto() { Nome = "Suco de Laranja",  PrecoPorUnidade = 4.50 , Quantidade = 10, FamiliaProdutoId = 1};
            ////////var p2 = new Produto() { Nome = "Café", PrecoPorUnidade = 10.50, Quantidade = 10, FamiliaProdutoId = 1 };
            ////////var p3 = new Produto() { Nome = "Macarrão", PrecoPorUnidade = 13.50, Quantidade = 10, FamiliaProdutoId = 1 };
            //ProdutosDAO prods = new ProdutosDAO();
            //Produto p1 = prods.BuscaPorId(12002);
            //var pedido = new Pedido();
            //pedido.ValorTotal = 200;

            //pedido.IncluiProduto(p1);
            //////pedido.IncluiProduto(p2);
            //////pedido.IncluiProduto(p3);

            //da.Adiciona(pedido);
        }
    }
}