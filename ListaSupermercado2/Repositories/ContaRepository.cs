using ListaSupermercado2.DataAccess;
using ListaSupermercado2.Models;
using ListaSupermercado2.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ListaSupermercado2.Repositories
{
    public class ContaRepository : GenericRepository<Conta>, IContaRepository
    {
        public ContaRepository(ListaSupermercadoContext context) : base(context) { }
        public Conta Logar(string user, string senha)
        {
            senha = CriptografiaUtils.CriptografarSHA256(senha);
            return _dbSet.Where(c => c.Usuario == user && c.Senha == senha).FirstOrDefault();
        }

        public override void Add(Conta entity)
        {
            entity.Senha = CriptografiaUtils.CriptografarSHA256(entity.Senha);
            base.Add(entity);
        }

        public Conta SearchByName(string usuario)
        {
            return _dbSet.Where(c => c.Usuario == usuario).FirstOrDefault();
        }
    }
}