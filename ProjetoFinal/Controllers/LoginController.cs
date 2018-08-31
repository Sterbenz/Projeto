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

        public ActionResult Validar(String usuario, String senha)
        {

            UsuariosDAO dao = new UsuariosDAO();
            Usuario user = new Usuario();
            ViewBag.Usuarios = dao.Lista();

            foreach (var login in ViewBag.Usuarios)
            {               
                if (login.User == usuario && login.Senha == senha)
                {
                    Session["UsuarioLogado"] = login;
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