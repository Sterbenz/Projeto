﻿using System;
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
    public class ProdutoController : Controller
    {
        
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
            ViewBag.Familias = dao.Lista();             
            return View();
        }

        [HttpPost]
        public ActionResult Adiciona(Produto produto)
        {
            if (ModelState.IsValid)
            {   
                ProdutosDAO dao = new ProdutosDAO();
                dao.Adiciona(produto);
                return RedirectToAction("Index","Produto");
            }
            else
            {
                FamiliaProdutoDAO familiaDao = new FamiliaProdutoDAO();
                ViewBag.Familias = familiaDao.Lista();                
                return View("Form");
            }
        }

        public ActionResult Editar(int id)
        {
            ProdutosDAO dao = new ProdutosDAO();
            Produto produto = dao.BuscaPorId(id);
            FamiliaProdutoDAO familiaDao = new FamiliaProdutoDAO();
            ViewBag.Familias = familiaDao.Lista();    
            ViewBag.Produtos = produto;
            return View();
        }

        public ActionResult Edita(int id, Produto produto)
        {
            if (ModelState.IsValid)
            {            
                ProdutosDAO dao = new ProdutosDAO();
                Produto p = dao.BuscaPorId(id);
                p.Nome = produto.Nome;
                p.PrecoPorUnidade = produto.PrecoPorUnidade;
                p.Quantidade = produto.Quantidade;
                p.Complemento = produto.Complemento;
                p.FamiliaProdutoId = produto.FamiliaProdutoId;
                dao.Atualiza(p);
                return RedirectToAction("Index", "Produto");
            }
            else
            {
                return RedirectToAction("Editar","Produto",new { id });
            }
        }

        public ActionResult Remover(int id)
        {
            ProdutosDAO dao = new ProdutosDAO();
            Produto produto = dao.BuscaPorId(id);
            dao.Remover(produto);

            return Json(id);
        }
    }
}