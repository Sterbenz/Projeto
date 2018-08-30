using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProjetoFinal.Models;
using ProjetoFinal.DAO;

namespace ProjetoFinal.Models
{
    public class FuncionarioController : Controller
    {
        // GET: Funcionarios
        public ActionResult Index()
        {
            IList<Pessoa> pessoas = new List<Pessoa>();

            PessoasDAO dao = new PessoasDAO();
            foreach (Pessoa pessoa in dao.Lista())
            {
                if (pessoa.TipoPessoa.Nome == "Funcionario")
                    pessoas.Add(pessoa);
            }
            ViewBag.Funcionarios = pessoas;

            return View();
        }

        public ActionResult Form()
        {
            TipoPessoasDAO dao = new TipoPessoasDAO();
            ViewBag.Cargos = dao.Lista();

            return View();
        }

        [HttpPost]
        public ActionResult Adiciona(Pessoa funcionario)
        {
            if (ModelState.IsValid)
            {
                PessoasDAO funcDAO = new PessoasDAO();
                UsuariosDAO userDAO = new UsuariosDAO();
                Usuario user = new Usuario()
                {
                    User = funcionario.Nome + funcionario.DataDeNascimento.Year,
                    Senha = funcionario.Cpf,
                    PessoaId = funcionario.Id,
                    TipoPessoaId = funcionario.TipoPessoaId
                   
                };

                funcDAO.Adiciona(funcionario);
                userDAO.Adiciona(user);

                return RedirectToAction("Index", "Funcionario");
            }
            else
            {
                TipoPessoasDAO dao = new TipoPessoasDAO();
                ViewBag.Cargos = dao.Lista();

                return View("Form");
            }
        }

        public ActionResult Editar(int id)
        {
            UsuariosDAO dao = new UsuariosDAO();
            Usuario funcionario = dao.BuscaPorId(id);
            TipoPessoasDAO cargoDao = new TipoPessoasDAO();
            ViewBag.Cargos = cargoDao.Lista();
            ViewBag.Funcionarios = funcionario;

            return View();
        }

        public ActionResult Edita(int id, Pessoa funcionario)
        {
            if (ModelState.IsValid)
            {
                PessoasDAO dao = new PessoasDAO();
                Pessoa p = dao.BuscaPorId(id);
                p.Nome = funcionario.Nome;
                p.Cpf = funcionario.Cpf;
                p.DataDeNascimento = funcionario.DataDeNascimento;
                p.Email = funcionario.Email;
                p.Telefone = funcionario.Telefone;
                p.TipoPessoaId = funcionario.TipoPessoaId;
                dao.Atualiza(p);

                return RedirectToAction("Index", "Funcionarios");
            }
            else
            {
                return RedirectToAction("Editar", "Funcionarios", new { id });
            }
        }

        public ActionResult Remover(int id)
        {
            UsuariosDAO dao = new UsuariosDAO();
            Usuario funcionario = dao.BuscaPorId(id);
            dao.Remover(funcionario);

            return RedirectToAction("Index", "Funcionarios");
        }
    }
}