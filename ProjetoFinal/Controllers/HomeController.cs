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
            ProdutosDAO produtosDAO = new ProdutosDAO();
            ViewBag.ProdutosBaixa = produtosDAO.ListaProdutosEmBaixa();
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

        public ActionResult MaisVendidosDoMes()
        {
            VendasDAO vendasDAO = new VendasDAO();
            ProdutosPedidosDAO ppDAO = new ProdutosPedidosDAO();
            IList<Venda> vendas = vendasDAO.ListaMaisVendidos();
            IList<PedidoProdutos> pp = ppDAO.ListaProdutosDosPedidos(vendas);


            return Json(pp);
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

        public ActionResult _12120827966produtospadroessistemacontrole89116664()
        {

            ProdutosDAO dao = new ProdutosDAO();
            FamiliaProdutoDAO fDAO = new FamiliaProdutoDAO();
            FamiliaProduto f1 = new FamiliaProduto() { Nome = "Escolar", Descricao = "Materiais relacionados a escola" };
            FamiliaProduto f2 = new FamiliaProduto() { Nome = "Informatica", Descricao = "Produtos relacionados a tecnologia" };
            fDAO.Adiciona(f1);
            fDAO.Adiciona(f2);
            Produto p1 = new Produto() { Nome = "Caderno", PrecoPorUnidade = 10.75, Complemento = "Caderno preto de capa dura", FamiliaProdutoId = f1.Id };
            Produto p2 = new Produto() { Nome = "Caneta", PrecoPorUnidade = 1.75, Complemento = "Caneta transparente de tinta preta", FamiliaProdutoId = f1.Id };
            Produto p3 = new Produto() { Nome = "Lapis", PrecoPorUnidade = 0.75, Complemento = "Lapis normal", FamiliaProdutoId = f1.Id };

            Produto p4 = new Produto() { Nome = "Mouse", PrecoPorUnidade = 22.75, Complemento = "Mouse com leds verdes", FamiliaProdutoId = f2.Id };
            Produto p5 = new Produto() { Nome = "Teclado", PrecoPorUnidade = 26.75, Complemento = "Teclado TOP", FamiliaProdutoId = f2.Id };
            Produto p6 = new Produto() { Nome = "Fones", PrecoPorUnidade = 17.75, Complemento = "Fones de ouvido brancos", FamiliaProdutoId = f2.Id };

            dao.Adiciona(p1);
            dao.Adiciona(p2);
            dao.Adiciona(p3);
            dao.Adiciona(p4);
            dao.Adiciona(p5);
            dao.Adiciona(p6);

            return RedirectToAction("Index", "Home");
        }
    }
}