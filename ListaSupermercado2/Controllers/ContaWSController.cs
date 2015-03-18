using ListaSupermercado2.Models;
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
    public class ContaWSController : ApiController
    {
        private UnitOfWork _unit = new UnitOfWork();

        public IEnumerable<Conta> Get()
        {
            return _unit.ContaRepository.List();
        }

        public Conta Get(int id)
        {
            return _unit.ContaRepository.SearchById(id);
        }

        public IHttpActionResult Post(Conta conta)
        {

            if (ModelState.IsValid)
            {
                _unit.ContaRepository.Add(conta);
                _unit.Save();
                var uri = Url.Link("DefaultApi", new { id = conta.ContaId });
                return Created<Conta>(new Uri(uri), conta);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        public IHttpActionResult Put(int id, Conta conta)
        {
            if (ModelState.IsValid)
            {
                conta.ContaId = id;
                _unit.ContaRepository.Update(conta);
                _unit.Save();
                return Ok(conta);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        public void Delete(int id)
        {
            _unit.ContaRepository.Delete(id);
            _unit.Save();
        }

    }
}
