using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProjetoFinal.Models;
using ProjetoFinal.DAO;

namespace ProjetoFinal.Controllers
{
    public class FornecedorController : Controller
    {
        // GET: Fornecedor
        public ActionResult Index()
        {
            FornecedoresDAO dao = new FornecedoresDAO();
            ViewBag.Fonecedores = dao.Lista();
            return View();
        }

        public ActionResult Form()
        {

            return View();
        }

        public ActionResult AdicionaPedido()
        {
            return View();
        }
    }
}