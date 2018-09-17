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
    public class ClienteController : Controller
    {
        public ActionResult Index()
        {
            IList<Pessoa> pessoas = new List<Pessoa>();

            PessoasDAO dao = new PessoasDAO();
            foreach (Pessoa pessoa in dao.Lista())
            {
                if (pessoa.TipoPessoaId == 1)
                    pessoas.Add(pessoa);
            }
            ViewBag.Clientes = pessoas;

            return View();
        }

        public ActionResult Form()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Adiciona(Pessoa cliente)
        {
            if (ModelState.IsValid)
            {
                PessoasDAO dao = new PessoasDAO();
                cliente.TipoPessoaId = 1;
                dao.Adiciona(cliente);

                return RedirectToAction("Index", "Cliente");
            }
            else
            {
                return View("Form");
            }
        }

        public ActionResult Editar(int id)
        {
            PessoasDAO dao = new PessoasDAO();
            Pessoa cliente = dao.BuscaPorId(id);
            ViewBag.Clientes = cliente;

            return View();
        }

        public ActionResult Edita(int id, Pessoa cliente)
        {
            if (ModelState.IsValid)
            {
                PessoasDAO dao = new PessoasDAO();
                Pessoa c = dao.BuscaPorId(id);
                c.Nome = cliente.Nome;
                c.Cpf = cliente.Cpf;
                c.DataDeNascimento = cliente.DataDeNascimento;
                c.Email = cliente.Email;
                c.Telefone = cliente.Telefone;                
                dao.Atualiza(c);

                return RedirectToAction("Index", "Cliente");
            }
            else
            {
                return RedirectToAction("Editar", "Cliente", new { id });
            }
        }

        public ActionResult Remover(int id)
        {
            PessoasDAO dao = new PessoasDAO();
            Pessoa cliente = dao.BuscaPorId(id);
            dao.Remover(cliente);

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
                Descricao = "Funcionario" + user.Nome + modificacao + "a fornecedora" + fornecedor.DenominacaoSocial
            };
        }
    }
}