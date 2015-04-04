using ListaSupermercado2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListaSupermercado2.Repositories
{
    public interface IContaRepository : IGenericRepository<Conta>
    {
        Conta Logar(string user, string senha);
        Conta SearchByName(string usuario);
    }
}
