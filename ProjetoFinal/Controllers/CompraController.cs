﻿using ProjetoFinal.DAO;
using ProjetoFinal.Filters;
using ProjetoFinal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjetoFinal.Controllers
{
    [LoginFilter]
    public class CompraController : Controller
    {
        // GET: Compra
        public ActionResult Index()
        {
            PessoasDAO dao = new PessoasDAO();
            ProdutosDAO prodDAO = new ProdutosDAO();
            ViewBag.Clientes = dao.ListaClientes();
            ViewBag.Produtos = prodDAO.Lista();

            return View();
        }
        public ActionResult RealizaVenda(int id, Produto[] model, double valorTotal)
        {
            string clienteNome;
            Pessoa funcionario = (Pessoa)Session["UsuarioLogado"];
            PessoasDAO pesDAO = new PessoasDAO();
            ProdutosDAO pDAO = new ProdutosDAO();
            PedidosDAO dao = new PedidosDAO();
            Pessoa cliente = pesDAO.BuscaPorId(id);

            if (id == 00)
            {
                clienteNome = "não registrado";
            }
            else
            {
                clienteNome = cliente.Nome;
            }

            Pedido pedido = new Pedido
            {
                ValorTotal = valorTotal,
                Tipo = "Venda"
            };

            foreach (Produto produto in model)
            {
                Produto produtoAdd = pDAO.BuscaPorId(produto.Id);
                Produto produtoEstoque = pDAO.BuscaPorId(produto.Id);
                produtoEstoque.Quantidade -= produto.Quantidade;
                produtoAdd.PrecoPorUnidade = produto.PrecoPorUnidade;
                produtoAdd.Quantidade = produto.Quantidade;
                pedido.IncluiProduto(produtoAdd);
                pDAO.Atualiza(produtoEstoque);
            }

            dao.Adiciona(pedido);

            VendasDAO vendaDAO = new VendasDAO();
            Venda venda = new Venda()
            {
                ClienteId = id,
                FuncionarioId = funcionario.Id,
                PedidoId = pedido.Id,
                ValorTotal = valorTotal,
            };


            vendaDAO.Adiciona(venda);

            RegistrarLog(venda, "realizou uma venda para o cliente ", valorTotal, clienteNome, cliente );

            return Json("success");
        }

        public void RegistrarLog(Venda venda, string modificacao, double valorTotal, string cliente, Pessoa clienteDados)
        {
            Pessoa user = (Pessoa)Session["UsuarioLogado"];
            LogVendasDAO dao = new LogVendasDAO();
            LogVenda log = new LogVenda()
            {
                PessoaId = user.Id,
                PessoaNome = user.Nome,
                VendaId = venda.Id,
                ClienteNome = cliente,
                ClienteId = clienteDados.Id,
                DataDaVenda = DateTime.Now,
                Descricao = "Funcionario " + user.Nome + " " + modificacao + cliente + " de R$" + valorTotal
            };
            dao.Adiciona(log);
        }

    }
    
}