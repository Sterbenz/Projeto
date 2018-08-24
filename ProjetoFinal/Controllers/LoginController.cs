using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProjetoFinal.DAO;
using ProjetoFinal.Models;

namespace ProjetoFinal.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Validar(string usuario, string senha)
        {
            FuncionariosDAO dao = new FuncionariosDAO();
            ViewBag.Funcionarios = dao.Lista();            

            foreach(var funcionario in ViewBag.Funcionarios)
            {
                if (funcionario.Login.Usuario == usuario && funcionario.Login.Senha == senha)
                {
                    return RedirectToAction("Index","Home");
                }
                else
                {
                    return RedirectToAction("Index","Login");
                }

            }

            return View();
        }
    }
}