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

            if (AutenticaUsuario(usuario, senha))
            {

                return RedirectToAction("Index", "Home");
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }
        
        public ActionResult UsuarioExiste(string usuario, string senha)
        {
            // 0 - usuario não encontrado //1 - usuario encontrado e senha errada // 2 - login completo
            int seq = 0;
            bool username = false;
            bool pass = false;
            UsuariosDAO dao = new UsuariosDAO();
            Usuario user = new Usuario();
            PessoasDAO pessDAO = new PessoasDAO();
            ViewBag.Usuarios = dao.Lista();

            foreach (var login in ViewBag.Usuarios)
            {
                if (login.User == usuario)
                {
                    username = true;
                }
            }
            foreach (var login in ViewBag.Usuarios)
            {
                if (login.Senha == senha)
                {
                    pass = true;
                }
            }

            if (username == true)
            {
                if (pass == true)
                {
                    seq = 2;
                    return Json(seq);
                }
                else if(pass == false)
                {
                    seq = 1;
                    return Json(seq);
                }
            }
            else
            {
                seq = 0;
                return Json(seq);
            }

            return Json(seq);
        }

        private bool AutenticaUsuario(String usuario, String senha)
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
                                   "    Sua senha é: " + user.Senha ;

                                  // cria uma mensagem        // De                        // Para           // Assunto               // Mensagem
            MailMessage mensagemEmail = new MailMessage("testeenviaemail.proj@gmail.com", emailDestinatario, "Seu login do sistema", enviaMensagem);

            using (var smtp = new SmtpClient("smtp.gmail.com"))
            {
                smtp.EnableSsl = true; // GMail requer SSL
                smtp.Port = 587;       // porta para SSL
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network; // modo de envio
                smtp.UseDefaultCredentials = false; // Utilizar credenciais especificas

                // seu usuário e senha para autenticação
                smtp.Credentials = new NetworkCredential("testeenviaemail.proj@gmail.com", "suportprojtest");

                // envia o e-mail
                smtp.Send(mensagemEmail);
            }

            return Json("success");
        }

        public ActionResult Sair()
        {
            Session["UsuarioLogado"] = null;
            return RedirectToAction("Index","Login");
        }

        public ActionResult _12120827966usuariopadraosistemacontrole89116664()
        {
            TipoPessoasDAO dao = new TipoPessoasDAO();
            TipoPessoa a = new TipoPessoa()
            {
                Nome = "Cliente"
            };
            TipoPessoa b = new TipoPessoa()
            {
                Nome = "Funcionario(a)"
            };
            TipoPessoa c = new TipoPessoa()
            {
                Nome = "Gerente"
            };
            TipoPessoa d = new TipoPessoa()
            {
                Nome = "Dono(a)"
            };
            dao.Adiciona(a);
            dao.Adiciona(b);
            dao.Adiciona(c);
            dao.Adiciona(d);

            PessoasDAO funcDAO = new PessoasDAO();
            UsuariosDAO userDAO = new UsuariosDAO();

            Pessoa funcionario = new Pessoa()
            {
                Nome = "Vinicius",
                Cpf = "12120827966",
                Email = "viniciusdeandrade04@gmail.com",
                Telefone = "47997003217",
                DataDeNascimento = DateTime.Now,
                TipoPessoaId = 4

            };
            funcDAO.Adiciona(funcionario);

            Usuario user = new Usuario()
            {
                User = "q2",
                Senha = "123",
                PessoaId = funcionario.Id,
            };

            userDAO.Adiciona(user);

            return RedirectToAction("Index", "Login");
        }

    }
}