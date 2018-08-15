﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProjetoFinal.DAO;
using ProjetoFinal.Models;

namespace ProjetoFinal.Controllers
{
    public class ProdutosController : Controller
    {
        // GET: Produtos
        public ActionResult Index()
        {
            ProdutosDAO dao = new ProdutosDAO();
            IList<Produto> produtos = dao.Lista();
            ViewBag.Produtos = produtos;

            return View();
        }

        public ActionResult Form()
        {
            FamiliaProdutoDAO dao = new FamiliaProdutoDAO();
            IList<FamiliaProduto> familias = dao.Lista();
            ViewBag.Familias = familias;
            return View();
        }

        [HttpPost]
        public ActionResult Adiciona(Produto produto)
        {
            ProdutosDAO dao = new ProdutosDAO();
            dao.Adiciona(produto);

            return View("Index");
        }
    }
}