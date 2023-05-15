using AM.ApplicationCore.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DbContext _context;
        private readonly Type _repositoryType;
        private bool disposedValue;
        public UnitOfWork(DbContext context, Type type)
        {
            _context = context;
            _repositoryType = type;
        }
        public IGenericRepository<T> Repository<T>() where T : class
        {
            return (IGenericRepository<T>)Activator.CreateInstance(_repositoryType
                .MakeGenericType(typeof(T)), _context);

        }
        public int Save()
        {
            return _context.SaveChanges();
        }
        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
                disposedValue = true;
            }
        }
        ~UnitOfWork()
        {
            Dispose(false);
        }
        public void Dispose()
        {
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}
