using ListaSupermercado2.Models;
using ListaSupermercado2.UnitsOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

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
            if (conta.Senha != password2)
            {
                ModelState.AddModelError("Senha", "Senhas Não Conferem");
                return View();
            }
            if (_unit.ContaRepository.SearchFor(c => c.Usuario == conta.Usuario).Count != 0)
            {
                ModelState.AddModelError("Usuario", "Usuário já existe");
            }
            if (ModelState.IsValid)
            {
                _unit.ContaRepository.Add(conta);
                _unit.Save();
                TempData["msg"] = "Usuário Cadastrado!";
                return View();
            }
            else
            {
                return View();
            }
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
        public ActionResult Logar(Conta conta, string returnUrl)
        {
            var user = _unit.ContaRepository.Logar(conta.Usuario, conta.Senha);
            if (user != null)
            {
                FormsAuthentication.SetAuthCookie(user.Usuario, false);
                if (String.IsNullOrEmpty(returnUrl))
                {
                    return RedirectToAction("Index", "Conta");
                }
                else
                {
                    return Redirect(returnUrl);
                }
            }
            else
            {
                TempData["msg"] = "Usuário ou senha Inválidos";
                return View();
            }
        }

        public ActionResult Deletar(int id)
        {
            _unit.ContaRepository.Delete(id);
            _unit.Save();
            return RedirectToAction("Listar");
        }

        [HttpGet]
        public ActionResult Editar(int id)
        {
            var conta = _unit.ContaRepository.SearchById(id);
            return View("Editar", conta);
        }

        [HttpPost]
        public ActionResult Editar(Conta conta)
        {
            _unit.ContaRepository.Update(conta);
            _unit.Save();
            return RedirectToAction("Listar");
        }

        public ActionResult Deslogar()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Logar", "Conta");
        }

        protected override void Dispose(bool disposing)
        {
            _unit.Dispose();
            base.Dispose(disposing);
        }
    }
}