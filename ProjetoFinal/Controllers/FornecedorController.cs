using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjetoFinal.Controllers
{
    public class FornecedorController : Controller
    {
        // GET: Fornecedor
        public ActionResult Index()
        {
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