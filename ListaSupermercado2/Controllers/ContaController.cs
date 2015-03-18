using ListaSupermercado2.Models;
using ListaSupermercado2.UnitsOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ListaSupermercado2.Controllers
{
    public class ContaController : Controller
    {
        private UnitOfWork _unit = new UnitOfWork();

        // GET: Conta
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Cadastrar()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Cadastrar(Conta conta)
        {
            _unit.ContaRepository.Add(conta);
            _unit.Save();
            return View();
        }

        public ActionResult Listar()
        {
            return View(_unit.ContaRepository.List());
        }
    }
}