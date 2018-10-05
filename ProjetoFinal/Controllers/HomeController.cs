using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProjetoFinal.DAO;
using ProjetoFinal.Filters;
using ProjetoFinal.Models;
using System.Web.Script.Serialization;
using System.Globalization;

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

            var user = (Pessoa)Session["UsuarioLogado"];
            var Tipodao = new TipoPessoasDAO();
            var cargo = Tipodao.BuscaPorId(user.TipoPessoaId);

            if (cargo.Nome == "Funcionario" || cargo.Nome == "Funcionario(a)")
            {
                return View("Index_Funcionario");
            }
            else if (cargo.Nome == "Gerente" || cargo.Nome == "Dono(a)" || cargo.Nome == "Dono")
            {
                return View("Index");
            }

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
            LogVendasDAO venDAO = new LogVendasDAO();       
            LogComprasDAO comDAO = new LogComprasDAO();       
            
            
            ViewBag.LogPessoas = pesDAO.Lista();
            ViewBag.LogFornecedores = forDAO.Lista();
            ViewBag.LogFamilias = famDAO.Lista();
            ViewBag.LogProdutos = proDAO.Lista();
            ViewBag.LogVendas = venDAO.Lista();
            ViewBag.LogCompras = comDAO.Lista();

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
            ProdutosDAO produtosDAO = new ProdutosDAO();
            ProdutosPedidosDAO ppDAO = new ProdutosPedidosDAO();
            IList<Venda> vendas = vendasDAO.ListaMaisVendidos();
            IList<PedidoProdutos> pp = ppDAO.ListaProdutosDosPedidos(vendas);

            var junta = pp.GroupBy(p => p.ProdutoId)
                .Select(x => new PedidoProdutos
                {
                    ProdutoNome = x.First().ProdutoNome,
                    Quantidade = x.Sum(q => q.Quantidade),
                });

            IEnumerable<PedidoProdutos> maisVendidos = junta.OrderByDescending(p => p.Quantidade);
            IList<PedidoProdutos> ppCrescent = maisVendidos.Take(5).ToList();

            var result = ppCrescent.Select( item => new{ Nome = item.ProdutoNome, Quantidade = item.Quantidade });

            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GanhosEGastos()
        {
            CultureInfo culture = new CultureInfo("pt-BR");
            DateTimeFormatInfo dtfi = culture.DateTimeFormat;
            VendasDAO vendasDAO = new VendasDAO();
            AcompanhamentoFornecedoresDAO acDAO = new AcompanhamentoFornecedoresDAO();
            IList<Venda> vendas = vendasDAO.ListaGanhos();
            IList<AcompanhamentoFornecedores> acompanhamentos = acDAO.ListaGastos();

            var juntaGanhos = vendas.GroupBy(v => v.DataDaVenda.Month)
                .Select(x => new Venda
                {
                    DataDaVenda = x.First().DataDaVenda,
                    ValorTotal = x.Sum(vt => vt.ValorTotal),
                });

            var juntaGastos = acompanhamentos.GroupBy(v => v.DataEmissao.Month)
                .Select(x => new AcompanhamentoFornecedores
                {
                    DataEmissao = x.First().DataEmissao,
                    ValorTotal = x.Sum(vt => vt.ValorTotal),
                });

            IEnumerable<Venda> Ganhos = juntaGanhos.OrderBy(p => p.DataDaVenda);
            IEnumerable<AcompanhamentoFornecedores> Gastos = juntaGastos.OrderBy(p => p.DataEmissao);
            IList<Venda> ganhosCrescent = Ganhos.ToList();
            IList<AcompanhamentoFornecedores> gastosCrescent = Gastos.ToList();

            var resultGanhos = ganhosCrescent.Select(item => new { Data = culture.TextInfo.ToTitleCase(dtfi.GetMonthName(item.DataDaVenda.Month)), ValorTotal = item.ValorTotal });
            var resultGastos = gastosCrescent.Select(item => new { Data = culture.TextInfo.ToTitleCase(dtfi.GetMonthName(item.DataEmissao.Month)), ValorTotal = item.ValorTotal });
            var result = new { Ganhos = resultGanhos, Gastos = resultGastos};

            return Json(result, JsonRequestBehavior.AllowGet);
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
            Produto p1 = new Produto() { Nome = "Caderno", PrecoPorUnidade = 10.75, Complemento = "Caderno preto de capa dura", FamiliaProdutoId = f1.Id, Quantidade = 20 };
            Produto p2 = new Produto() { Nome = "Caneta", PrecoPorUnidade = 1.75, Complemento = "Caneta transparente de tinta preta", FamiliaProdutoId = f1.Id, Quantidade = 20 };
            Produto p3 = new Produto() { Nome = "Lapis", PrecoPorUnidade = 0.75, Complemento = "Lapis normal", FamiliaProdutoId = f1.Id, Quantidade = 20 };

            Produto p4 = new Produto() { Nome = "Mouse", PrecoPorUnidade = 22.75, Complemento = "Mouse com leds verdes", FamiliaProdutoId = f2.Id, Quantidade = 20 };
            Produto p5 = new Produto() { Nome = "Teclado", PrecoPorUnidade = 26.75, Complemento = "Teclado TOP", FamiliaProdutoId = f2.Id, Quantidade = 20 };
            Produto p6 = new Produto() { Nome = "Fones", PrecoPorUnidade = 17.75, Complemento = "Fones de ouvido brancos", FamiliaProdutoId = f2.Id, Quantidade = 20 };

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