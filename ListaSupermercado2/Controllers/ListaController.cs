using ListaSupermercado2.Models;
using ListaSupermercado2.UnitsOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ListaSupermercado2.Controllers
{
    [Authorize]
    public class ListaController : Controller
    {
        private UnitOfWork _unit = new UnitOfWork();

        [HttpGet]
        public ActionResult Cadastrar()
        {
            Conta conta = _unit.ContaRepository.SearchByName(User.Identity.Name);
            ViewBag.ContaId = conta.ContaId; 
            return View();
        }

        [HttpPost]
        public ActionResult Cadastrar(Lista lista, int ContaId)
        {
            lista.ContaId = ContaId;
            _unit.ListaRepository.Add(lista);
            _unit.Save();
            return View();
        }

        public ActionResult Listar()
        {
            Conta conta = _unit.ContaRepository.SearchByName(User.Identity.Name);
            return View(_unit.ListaRepository.SearchFor(p => p.ContaId == conta.ContaId));
        }

        public ActionResult Deletar(int id)
        {
            _unit.ListaRepository.Delete(id);
            _unit.Save();
            return RedirectToAction("Listar");
        }

        [HttpGet]
        public ActionResult Editar(int id)
        {
            Conta conta = _unit.ContaRepository.SearchByName(User.Identity.Name);
            ViewBag.ContaId = conta.ContaId;
            var lista = _unit.ListaRepository.SearchById(id);
            return View("Editar", lista);
        }

        [HttpPost]
        public ActionResult Editar(Lista lista)
        {
            _unit.ListaRepository.Update(lista);
            _unit.Save();
            return RedirectToAction("Listar");
        }

        protected override void Dispose(bool disposing)
        {
            _unit.Dispose();
            base.Dispose(disposing);
        }
    }
}