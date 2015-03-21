using ListaSupermercado2.Models;
using ListaSupermercado2.UnitsOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ListaSupermercado2.Controllers
{
    public class ListaController : Controller
    {
        private UnitOfWork _unit = new UnitOfWork();

        [HttpGet]
        public ActionResult Cadastrar()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Cadastrar(Lista lista)
        {
            _unit.ListaRepository.Add(lista);
            _unit.Save();
            return View();
        }

        public ActionResult Listar()
        {
            return View(_unit.ListaRepository.List());
        }
    }
}