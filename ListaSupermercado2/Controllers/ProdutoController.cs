using ListaSupermercado2.Models;
using ListaSupermercado2.UnitsOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ListaSupermercado2.Controllers
{
    public class ProdutoController : Controller
    {
        private UnitOfWork _unit = new UnitOfWork();

        [HttpGet]
        public ActionResult Cadastrar()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Cadastrar(Produto produto)
        {
            _unit.ProdutoRepository.Add(produto);
            _unit.Save();
            return View();
        }

        public ActionResult Listar()
        {
            return View(_unit.ProdutoRepository.List());
        }

        public ActionResult Deletar(int id)
        {
            _unit.ListaRepository.Delete(id);
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