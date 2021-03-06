﻿using ListaSupermercado2.Models;
using ListaSupermercado2.UnitsOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace ListaSupermercado2.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class LogarWSController : ApiController
    {
        private UnitOfWork _unit = new UnitOfWork();

        public Conta Post(Conta conta)
        {
            var user = _unit.ContaRepository.Logar(conta.Usuario, conta.Senha);
            if (user == null)
            {
                Conta c = new Conta();
                c.Usuario = "Invalido";
                return c;
            }
            else
            {
                return user;
            }
        }

        // lista de produtos do usuario com determinado id
        public IEnumerable<Lista> Get(int id)
        {
            return _unit.ListaRepository.SearchFor(p => p.ContaId == id);
        }
    }
}
