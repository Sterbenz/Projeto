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
                         
            if (UsuarioExiste(usuario,senha))
            {                    
                
                return RedirectToAction("Index","Home");
            }
            else
            {
                return RedirectToAction("Index","Login");
            }
        }

        private bool UsuarioExiste(String usuario, String senha)
        {

            UsuariosDAO dao = new UsuariosDAO();
            Usuario user = new Usuario();
            PessoasDAO pessDAO = new PessoasDAO();
            ViewBag.Usuarios = dao.Lista();

            foreach (var login in ViewBag.Usuarios)
            {
                if (login.User == usuario && login.Senha == senha)
                { 

                    Pessoa pessoa = pessDAO.BuscaPorId(login.PessoaId);
                    Session["UsuarioLogado"] = pessoa;
                    return true;
                }
            }
            return false;
        }

        public ActionResult Sair()
        {
            Session["UsuarioLogado"] = null;
            return RedirectToAction("Index","Login");
        }

    }
}