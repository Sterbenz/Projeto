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
                return Content("Fornecedor adicionado com sucesso!");
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
            dao.Remover(fornecedor);

            return Json(id);
        }

        public ActionResult AdicionaPedido()
        {
            FornecedoresDAO dao = new FornecedoresDAO();
            ProdutosDAO prodDAO = new ProdutosDAO();
            ViewBag.Fonecedores = dao.Lista();
            ViewBag.Produtos = prodDAO.Lista();
            return View();
        }
    }
}