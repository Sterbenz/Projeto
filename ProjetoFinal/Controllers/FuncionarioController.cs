﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProjetoFinal.Models;
using ProjetoFinal.DAO;
using ProjetoFinal.Filters;

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

            return RedirectToAction("Index", "Funcionario");
        }
    }
}