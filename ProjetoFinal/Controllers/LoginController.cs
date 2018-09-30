using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.Mvc;
using ProjetoFinal.DAO;
using ProjetoFinal.Models;
using System.Configuration;
using System.Net.Mail;
using System.Net;

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

            if (UsuarioExiste(usuario, senha))
            {

                return RedirectToAction("Index", "Home");
            }
            else
            {
                return RedirectToAction("Index", "Login");
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

        public ActionResult Verifica_Email(string email)
        {
            int achou = 0;
            PessoasDAO pessDAO = new PessoasDAO();
            Pessoa emailAchado = pessDAO.BuscaPorEmail(email);

            if(emailAchado != null)
            {
                 achou = 1;
            }
            return Json(achou);
        }

        public ActionResult Esqueci_Senha(string emailDestinatario)
        {
            PessoasDAO pessDAO = new PessoasDAO();
            Pessoa emailAchado = pessDAO.BuscaPorEmail(emailDestinatario);
            UsuariosDAO usuariosDAO = new UsuariosDAO();
            Usuario user = usuariosDAO.BuscaPorIdFuncionario(emailAchado.Id);

            string enviaMensagem = "Seu usuario é: " + user.User +
                                   "Sua senha é: " + user.Senha ;

            // cria uma mensagem
            MailMessage mensagemEmail = new MailMessage("boolzrandom@gmail.com", emailDestinatario, "Seu login do sistema", enviaMensagem);

            SmtpClient client = new SmtpClient("smtp.gmail.com", 465);
            client.EnableSsl = true;

            NetworkCredential cred = new NetworkCredential("boolzrandom@gmail.com", "V1n1c1us12!@");
            client.Credentials = cred;

            // inclui as credenciais
            client.UseDefaultCredentials = false;

            // envia a mensagem
            client.Send(mensagemEmail);

            return Json("success");
        }

        public ActionResult Sair()
        {
            Session["UsuarioLogado"] = null;
            return RedirectToAction("Index","Login");
        }

    }
}