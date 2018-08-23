using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProjetoFinal.DAO;
using ProjetoFinal.Models;

namespace ProjetoFinal.Controllers
{
    public class ClienteController : Controller
    {
        public ActionResult Index()
        {
            ClientesDAO dao = new ClientesDAO();
            ViewBag.Clientes = dao.Lista();

            return View();
        }

        public ActionResult Form()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Adiciona(Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                ClientesDAO dao = new ClientesDAO();                
                dao.Adiciona(cliente);

                return RedirectToAction("Index", "Cliente");
            }
            else
            {
                return View("Form");
            }
        }

        public ActionResult Editar(int id)
        {
            ClientesDAO dao = new ClientesDAO();
            Cliente cliente = dao.BuscaPorId(id);
            ViewBag.Produto = cliente;

            return View();
        }

        public ActionResult Edita(int id, Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                ClientesDAO dao = new ClientesDAO();
                Cliente c = dao.BuscaPorId(id);
                c.Nome = cliente.Nome;
                c.CPF = cliente.CPF;
                c.DataDeNascimento = cliente.DataDeNascimento;
                c.Telefone = cliente.Telefone;                
                dao.Atualiza(c);

                return RedirectToAction("Index", "Cliente");
            }
            else
            {
                return RedirectToAction("Editar", "Cliente", new { id });
            }
        }

        public ActionResult Remover(int id)
        {
            ClientesDAO dao = new ClientesDAO();
            Cliente cliente = dao.BuscaPorId(id);
            dao.Remover(cliente);

            return RedirectToAction("Index", "Cliente");
        }
    }
}