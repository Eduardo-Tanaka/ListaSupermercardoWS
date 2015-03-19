﻿using ListaSupermercado2.Models;
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
        public ActionResult Cadastrar(Conta conta, string password2)
        {
            _unit.ContaRepository.Add(conta);
            _unit.Save();
            return RedirectToAction("Listar", "Conta");
        }

        public ActionResult Listar()
        {
            return View(_unit.ContaRepository.List());
        }

        [HttpGet]
        public ActionResult Logar()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Logar(Conta conta)
        {
            return RedirectToAction("Index", "Conta");
        }

        protected override void Dispose(bool disposing)
        {
            _unit.Dispose();
            base.Dispose(disposing);
        }
    }
}