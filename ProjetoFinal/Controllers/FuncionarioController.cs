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
            FuncionariosDAO dao = new FuncionariosDAO();
            ViewBag.Funcionarios = dao.Lista();

            return View();            
        }

        public ActionResult Form()
        {
            CargosDAO dao = new CargosDAO();
            ViewBag.Cargos = dao.Lista();

            return View();
        }

        [HttpPost]
        public ActionResult Adiciona(Funcionario funcionario)
        {
            if (ModelState.IsValid)
            {
                FuncionariosDAO dao = new FuncionariosDAO();
                funcionario.Login = new LoginFuncionarios()
                {
                    Usuario = funcionario.Nome+funcionario.DataDeNascimento.Year,
                    Senha = funcionario.CPF
                };
                dao.Adiciona(funcionario);

                return RedirectToAction("Index", "Funcionario");
            }
            else
            {
                CargosDAO dao = new CargosDAO();
                ViewBag.Cargo = dao.Lista();

                return View("Form");
            }
        }

        public ActionResult Editar(int id)
        {
            FuncionariosDAO dao = new FuncionariosDAO();
            Funcionario funcionario = dao.BuscaPorId(id);
            CargosDAO cargoDao = new CargosDAO();
            ViewBag.Cargos = cargoDao.Lista();
            ViewBag.Funcionarios = funcionario;

            return View();
        }

        public ActionResult Edita(int id, Funcionario funcionario)
        {
            if (ModelState.IsValid)
            {
                FuncionariosDAO dao = new FuncionariosDAO();
                Funcionario p = dao.BuscaPorId(id);
                p.Nome = funcionario.Nome;
                p.CPF = funcionario.CPF;
                p.DataDeNascimento = funcionario.DataDeNascimento;
                p.Telefone = funcionario.Telefone;
                p.CargoID = funcionario.CargoID;
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
            FuncionariosDAO dao = new FuncionariosDAO();
            Funcionario funcionario = dao.BuscaPorId(id);
            dao.Remover(funcionario);

            return RedirectToAction("Index", "Funcionarios");
        }
    }
}