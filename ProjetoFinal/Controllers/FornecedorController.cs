using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProjetoFinal.Models;
using ProjetoFinal.DAO;
using System.ComponentModel.DataAnnotations;
using ProjetoFinal.Filters;

namespace ProjetoFinal.Controllers
{
    [LoginFilter]
    public class FornecedorController : Controller
    {
        // GET: Fornecedor
        public ActionResult Index()
        {
            FornecedoresDAO dao = new FornecedoresDAO();
            ViewBag.Fornecedores = dao.Lista();
            return View();
        }

        public ActionResult Form()
        {
            return View();
        }

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

        public ActionResult Editar(int id)
        {
            FornecedoresDAO dao = new FornecedoresDAO();
            Fornecedor fornecedor = dao.BuscaPorId(id);           
            ViewBag.Fornecedores = fornecedor;
            return View();
        }

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

        public ActionResult Remover(int id)
        {
            FornecedoresDAO dao = new FornecedoresDAO();
            Fornecedor fornecedor = dao.BuscaPorId(id);
            RegistrarLog(fornecedor, "DELETOU");
            dao.Remover(fornecedor);

            return Json(id);
        }

        public ActionResult ViewPedidos(int id)
        {
            FornecedoresDAO dao = new FornecedoresDAO();
            ProdutosDAO prodDAO = new ProdutosDAO();
            Fornecedor fornecedor = dao.BuscaPorId(id);
            ViewBag.Fornecedor = fornecedor;
            ViewBag.Produtos = prodDAO.Lista();
            return View();
        }

        //id = FornecedorId
        public ActionResult RealizaPedido(int id,List<Produto> produtos, double valorTotal)
        {
            FornecedoresDAO fDAO = new FornecedoresDAO();
            Fornecedor fornecedor = fDAO.BuscaPorId(id);
            ProdutosDAO pDAO = new ProdutosDAO();
            PedidosDAO dao = new PedidosDAO();
            Pedido pedido = new Pedido
            {
                ValorTotal = valorTotal
            };

            foreach (Produto produto in produtos)
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
            
            RegistrarLog(fornecedor, "registrou pedido n");

            return View("Index");
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
                Descricao = "Funcionario " + user.Nome +" "+ modificacao + "a fornecedora " + fornecedor.DenominacaoSocial
            };
            dao.Adiciona(log);
        }
    }
}