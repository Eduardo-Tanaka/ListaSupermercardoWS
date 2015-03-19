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
    public class ProdutoWSController : ApiController
    {
        private UnitOfWork _unit = new UnitOfWork();

        public IEnumerable<Produto> Get()
        {
            return _unit.ProdutoRepository.List();
        }

        public Produto Get(int id)
        {
            return _unit.ProdutoRepository.SearchById(id);
        }

        public IHttpActionResult Post(Produto produto)
        {

            if (ModelState.IsValid)
            {
                _unit.ProdutoRepository.Add(produto);
                _unit.Save();
                var uri = Url.Link("DefaultApi", new { id = produto.ProdutoId });
                return Created<Produto>(new Uri(uri), produto);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

    }
}
