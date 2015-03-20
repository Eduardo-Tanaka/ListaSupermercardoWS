using ListaSupermercado2.DataAccess;
using ListaSupermercado2.Models;
using ListaSupermercado2.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ListaSupermercado2.UnitsOfWork
{
    public class UnitOfWork : IDisposable
    {
        private ListaSupermercadoContext _context = new ListaSupermercadoContext();
        private IGenericRepository<Conta> _contaRepository;
        private IGenericRepository<Produto> _produtoRepository;
        private IGenericRepository<Lista> _listaRepository;

        public IGenericRepository<Lista> ListaRepository
        {
            get
            {
                if (_listaRepository == null)
                {
                    _listaRepository = new GenericRepository<Lista>(_context);
                }
                return _listaRepository;
            }
        }

        public IGenericRepository<Produto> ProdutoRepository
        {
            get
            {
                if (_produtoRepository == null)
                {
                    _produtoRepository = new GenericRepository<Produto>(_context);
                }
                return _produtoRepository;
            }
        }

        public IGenericRepository<Conta> ContaRepository
        {
            get
            {
                if (_contaRepository == null)
                {
                    _contaRepository = new GenericRepository<Conta>(_context);
                }
                return _contaRepository;
            }
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        private bool disposed = false;
        public void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}