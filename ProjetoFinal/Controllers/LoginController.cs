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
            
            
            

            foreach (var login in ViewBag.Logins)
            {               
                if (login.Usuario == usuario && login.Senha == senha)
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