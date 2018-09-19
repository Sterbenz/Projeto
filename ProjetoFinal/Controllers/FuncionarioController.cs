using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProjetoFinal.Models;
using ProjetoFinal.DAO;
using ProjetoFinal.Filters;

namespace ProjetoFinal.Models
{
    [LoginFilter]
    public class FuncionarioController : Controller
    {
        // GET: Funcionarios
        public ActionResult Index()
        {
            IList<Pessoa> pessoas = new List<Pessoa>();

            PessoasDAO dao = new PessoasDAO();
            foreach (Pessoa pessoa in dao.Lista())
            {
                if (pessoa.TipoPessoaId != 1)
                    pessoas.Add(pessoa);
            }
            ViewBag.Funcionarios = pessoas;

            return View();
        }

        public ActionResult Form()
        {
            TipoPessoasDAO dao = new TipoPessoasDAO();
            ViewBag.TipoPessoas = dao.Lista();

            return View();
        }

        [HttpPost]
        public ActionResult Adiciona(Pessoa funcionario)
        {
            if (ModelState.IsValid)
            {
                PessoasDAO funcDAO = new PessoasDAO();
                UsuariosDAO userDAO = new UsuariosDAO();
                funcDAO.Adiciona(funcionario);

                Usuario user = new Usuario()
                {
                    User = funcionario.Email,
                    Senha = funcionario.Cpf,
                    PessoaId = funcionario.Id,
                };
                
                userDAO.Adiciona(user);
                RegistrarLog(funcionario, "Registrou");

                return RedirectToAction("Index", "Funcionario");
            }
            else
            {
                TipoPessoasDAO dao = new TipoPessoasDAO();
                ViewBag.TipoPessoas = dao.Lista();

                return View("Form");
            }
        }

        public ActionResult Editar(int id)
        {
            PessoasDAO dao = new PessoasDAO();
            Pessoa funcionario = dao.BuscaPorId(id);
            TipoPessoasDAO tipoPessoasDao = new TipoPessoasDAO();
            ViewBag.TipoPessoas = tipoPessoasDao.Lista();
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
                RegistrarLog(p, "Editou");

                return RedirectToAction("Index", "Funcionario");
            }
            else
            {
                return RedirectToAction("Editar", "Funcionarios", new { id });
            }
        }

        public ActionResult Remover(int id)
        {
            PessoasDAO pessoaDAO = new PessoasDAO();
            Pessoa funcionario = pessoaDAO.BuscaPorId(id);
            pessoaDAO.Remover(funcionario);
            RegistrarLog(funcionario, "Deletou");
            return Json(funcionario.Id);
        }

        public void RegistrarLog(Pessoa funcionario, string modificacao)
        {
            Pessoa user = (Pessoa) Session["UsuarioLogado"];
            LogPessoasDAO dao = new LogPessoasDAO();
            LogPessoa log = new LogPessoa()
            {
                PessoaId = user.Id,
                PessoaNome = user.Nome,
                PessoaModificadaId = funcionario.Id,
                PessoaModificadaNome = funcionario.Nome,
                DataModificacao = DateTime.Now,
                Descricao = "Funcionario " + user.Nome + " " + modificacao +" o(a) funcionario(a) " + funcionario.Nome
            };
            dao.Adiciona(log);
        }

        public ActionResult ConfiguracaoUsuario(int id, string usuario, string senha)
        {
            UsuariosDAO dao = new UsuariosDAO();
            Usuario user = dao.BuscaPorId(id);
            user.User = usuario;
            user.Senha = senha;
            dao.Atualiza(user);

            return Json(user);
        }
    }
}