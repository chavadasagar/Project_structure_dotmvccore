using Project.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Data.UoW
{
    public class UnitOfWork:IUnitOfWork
    {
        private readonly testcontext _context;
        private Dictionary<Type, object> _repositories;

        public UnitOfWork(testcontext context)
        {
            _context = context;
            _repositories = new Dictionary<Type, object>();
        }

        public IRepository<T> Repository<T>() where T : class
        {
            if (_repositories.ContainsKey(typeof(T)))
            {
                return _repositories[typeof(T)] as IRepository<T>;
            }

            var repository = new Repository<T>(_context);
            _repositories.Add(typeof(T), repository);
            return repository;
        }
        
        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
