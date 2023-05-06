using Microsoft.EntityFrameworkCore;
using Project.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Data.UoW
{
    public class Repository<T> : IRepository<T> where T : class
    {
        public testcontext _context;
        public DbSet<T> table;
        public Repository()
        {
            this._context = new testcontext();
            table = _context.Set<T>();
        }
        public Repository(testcontext _context)
        {
            this._context = _context;
            table = _context.Set<T>();
        }
        public IEnumerable<T> GetAll()
        {
            return table.ToList();
        }
        public T GetById(object id)
        {
            return table.Find(id);
        }
        public void Insert(T obj)
        {
            table.Add(obj);
        }
        public void Update(T obj)
        {
            table.Attach(obj);
            _context.Entry(obj).State = (Microsoft.EntityFrameworkCore.EntityState)EntityState.Modified;
        }
        public void Delete(object id)
        {
            T existing = table.Find(id);
            table.Remove(existing);
        }
        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
