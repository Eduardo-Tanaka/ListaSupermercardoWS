using ListaSupermercado2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ListaSupermercado2.Controllers
{
    public class ListaController : Controller
    {
        [HttpGet]
        public ActionResult Cadastrar()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Cadastrar(Lista lista)
        {
            return View();
        }
    }
}