using ListaSupermercado2.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ListaSupermercado2.DataAccess
{
    public class ListaSupermercadoContext : DbContext
    {
        public DbSet<Conta> Contas { get; set; }
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Lista> Listas { get; set; }
    }
}