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
    public class ListaWSController : ApiController
    {
        private UnitOfWork _unit = new UnitOfWork();

        public IEnumerable<Lista> Get()
        {
            return _unit.ListaRepository.List();
        }

        public Lista Get(int id)
        {
            return _unit.ListaRepository.SearchById(id);
        }

        public IHttpActionResult Post(Lista lista)
        {
            if (ModelState.IsValid)
            {
                _unit.ListaRepository.Add(lista);
                _unit.Save();
                var uri = Url.Link("DefaultApi", new { id = lista.ListaId });
                return Created<Lista>(new Uri(uri), lista);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        public IHttpActionResult Put(int id, Lista lista)
        {
            if (ModelState.IsValid)
            {
                lista.ListaId = id;
                _unit.ListaRepository.Update(lista);
                _unit.Save();
                return Ok(lista);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        public void Delete(int id)
        {
            _unit.ListaRepository.Delete(id);
            _unit.Save();
        }

    }
}
