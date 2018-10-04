using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProjetoFinal.Models;
using ProjetoFinal.DAO;
using System.ComponentModel.DataAnnotations;
using ProjetoFinal.Filters;
using System.Web.Script.Serialization;
using System.Globalization;

namespace ProjetoFinal.Controllers
{
    
    [AutorizacaoUsuarioFilter]
    public class FornecedorController : Controller
    {
        [LoginFilter]
        public ActionResult Index()
        {
            FornecedoresDAO dao = new FornecedoresDAO();
            ViewBag.Fornecedores = dao.Lista();
            return View();
        }
        [LoginFilter]
        public ActionResult Form()
        {
            return View();
        }
        [LoginFilter]
        public ActionResult Adiciona(Fornecedor fornecedor)
        {
            if (ModelState.IsValid)
            {
                FornecedoresDAO dao = new FornecedoresDAO();
                dao.Adiciona(fornecedor);
                RegistrarLog(fornecedor, "REGISTROU");

                return RedirectToAction("Index","Fornecedor");
            }
            else
            {                
                return View("Form", "Fornecedor");
            }
        }
        [LoginFilter]
        public ActionResult Editar(int id)
        {
            FornecedoresDAO dao = new FornecedoresDAO();
            Fornecedor fornecedor = dao.BuscaPorId(id);           
            ViewBag.Fornecedores = fornecedor;
            return View();
        }
        [LoginFilter]
        public ActionResult Edita(int id, Fornecedor fornecedor)
        {
            if (ModelState.IsValid)
            {
                FornecedoresDAO dao = new FornecedoresDAO();
                Fornecedor p = dao.BuscaPorId(id);
                p.DenominacaoSocial = fornecedor.DenominacaoSocial;
                p.CNPJ = fornecedor.CNPJ;
                p.Endereco = fornecedor.Endereco;
                p.UF = fornecedor.UF;
                p.Cidade = fornecedor.Cidade;
                p.Bairro = fornecedor.Bairro;
                p.CEP = fornecedor.CEP;
                p.Email = fornecedor.Email;
                p.Telefone = fornecedor.Telefone;
                p.PrazoMedioEntrega = fornecedor.PrazoMedioEntrega;
                dao.Atualiza(p);
                RegistrarLog(p, "EDITOU");
                return RedirectToAction("Index", "Fornecedor");
            }
            else
            {
                return RedirectToAction("Editar", "Fornecedor", new { id });
            }
        }

        [LoginFilter]
        public ActionResult Remover(int id)
        {
            FornecedoresDAO dao = new FornecedoresDAO();
            Fornecedor fornecedor = dao.BuscaPorId(id);
            RegistrarLog(fornecedor, "DELETOU");
            dao.Remover(fornecedor);

            return Json(id);
        }

        [LoginFilter]
        public ActionResult ViewPedidos(int id)
        {
            FornecedoresDAO dao = new FornecedoresDAO();
            ProdutosDAO prodDAO = new ProdutosDAO();
            Fornecedor fornecedor = dao.BuscaPorId(id);
            ViewBag.Fornecedor = fornecedor;
            ViewBag.Produtos = prodDAO.Lista();
            return View();
        }

        public ActionResult VisualizaPedido(int id)
        {
            AcompanhamentoFornecedoresDAO acDAO = new AcompanhamentoFornecedoresDAO();
            PedidosDAO pedidosDAO = new PedidosDAO();
            ProdutosPedidosDAO ppDAO = new ProdutosPedidosDAO();

            IList<AcompanhamentoFornecedores> ac = new List<AcompanhamentoFornecedores>();
            IList<Pedido> p = new List<Pedido>();
            

            AcompanhamentoFornecedores acompanhamento = acDAO.BuscaPorId(id);
            ac.Add(acompanhamento);
            Pedido pedido = pedidosDAO.BuscaPorId(acompanhamento.PedidoId);
            p.Add(pedido);
            
            IList<PedidoProdutos> pp = ppDAO.ListaProdutosDoPedido(acompanhamento.PedidoId);


            
            var resultAcompanhamento = ac.Select(item => new { Data = item.DataEmissao,PedidoId = item.PedidoId ,Status = item.Entregue, Fornecedor = item.FornecedorId, ValorTotal = item.ValorTotal });
            var resultPedido = pp.Select(item => new { ProdutoId = item.ProdutoId, ProdutoNome = item.ProdutoNome, Quantidade = item.Quantidade});
            var result = new { Acompanhamento = resultAcompanhamento, PP = resultPedido };

            return Json(result);
        }

        [LoginFilter]
        public ActionResult RealizaPedido(int id,Produto[] model, double valorTotal)
        {

            FornecedoresDAO fDAO = new FornecedoresDAO();
            Fornecedor fornecedor = fDAO.BuscaPorId(id);
            ProdutosDAO pDAO = new ProdutosDAO();
            PedidosDAO dao = new PedidosDAO();
            Pedido pedido = new Pedido
            {
                ValorTotal = valorTotal,
                Tipo = "Compra"
            };

            foreach (Produto produto in model)
            {
                Produto produtoAdd = pDAO.BuscaPorId(produto.Id);
                produtoAdd.PrecoPorUnidade = produto.PrecoPorUnidade;
                produtoAdd.Quantidade = produto.Quantidade;
                pedido.IncluiProduto(produtoAdd);
            }
            
            dao.Adiciona(pedido);

            AcompanhamentoFornecedoresDAO acDAO = new AcompanhamentoFornecedoresDAO();
            AcompanhamentoFornecedores acompanhamento = new AcompanhamentoFornecedores()
            {
                DataEmissao = DateTime.Now,
                DataEntrega = DateTime.Now.AddDays(fornecedor.PrazoMedioEntrega),
                Entregue = false,
                FornecedorId = fornecedor.Id,
                PedidoId = pedido.Id,
                ValorTotal = valorTotal,
            };


            acDAO.Adiciona(acompanhamento);

            RegistrarLogCompras(fornecedor, "registrou pedido ", valorTotal);

            return Json("success");
        }

        public ActionResult Acompanhamentos()
        {
            AcompanhamentoFornecedoresDAO dao = new AcompanhamentoFornecedoresDAO();
            FornecedoresDAO fornDAO = new FornecedoresDAO();
            ViewBag.Acompanhamentos = dao.Lista();
            ViewBag.Fornecedores = fornDAO.Lista();

            return View();
        }

        public ActionResult ConfirmarEntrega(int id)
        {
            AcompanhamentoFornecedoresDAO acompDAO = new AcompanhamentoFornecedoresDAO();
            AcompanhamentoFornecedores acompanhamento = acompDAO.BuscaPorId(id);
            ProdutosPedidosDAO ppDAO = new ProdutosPedidosDAO();
            IList<PedidoProdutos> PdP = ppDAO.ListaProdutosDoPedido(acompanhamento.PedidoId);
            ProdutosDAO produtoDAO = new ProdutosDAO();
            
            foreach(PedidoProdutos produtoInPedido in PdP)
            {
                Produto produto = produtoDAO.BuscaPorId(produtoInPedido.ProdutoId);
                produto.Quantidade += produtoInPedido.Quantidade;
                produtoDAO.Atualiza(produto);
            }
            
            acompanhamento.Entregue = true;
            acompDAO.Atualiza(acompanhamento);
            return Json(id);
        }

        public void RegistrarLog(Fornecedor fornecedor, string modificacao)
        {
            Pessoa user = (Pessoa)Session["UsuarioLogado"];
            LogFornecedoresDAO dao = new LogFornecedoresDAO();
            LogFornecedor log = new LogFornecedor()
            {
                PessoaId = user.Id,
                PessoaNome = user.Nome,
                FornecedorId = fornecedor.Id,
                FornecedorNome = fornecedor.DenominacaoSocial,
                DataModificacao = DateTime.Now,
                Descricao = "Funcionario " + user.Nome + " " + modificacao + "a fornecedora " + fornecedor.DenominacaoSocial
            };
            dao.Adiciona(log);
        }

        public void RegistrarLogCompras(Fornecedor fornecedor, string modificacao, double valorTotal)
        {
            Pessoa user = (Pessoa)Session["UsuarioLogado"];
            LogComprasDAO dao = new LogComprasDAO();
            var valorFormatado = string.Format(CultureInfo.GetCultureInfo("pt-BR"), "{0:C}", valorTotal);
            LogCompra log = new LogCompra()
            {
                PessoaId = user.Id,
                PessoaNome = user.Nome,
                FornecedorId = fornecedor.Id,
                FornecedorNome = fornecedor.DenominacaoSocial,
                DataDaVenda = DateTime.Now,
                Descricao = "Funcionario " + user.Nome + " " + modificacao + "na fornecedora " + fornecedor.DenominacaoSocial + " de valor total: "+ valorFormatado
            };
            dao.Adiciona(log);
        }
    }
}