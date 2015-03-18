using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ListaSupermercado2.Controllers
{
    public class ContaController : Controller
    {
        // GET: Conta
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Cadastrar()
        {
            return View();
        }
    }
}