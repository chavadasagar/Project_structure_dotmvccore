using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Data.UoW
{
    public interface IRepository<T> where T : class
    {
        public IEnumerable<T> GetAll();
        public T GetById(object id);
        public void Insert(T obj);
        public void Update(T obj);
        public void Delete(object id);
        public void Save();
    }
}
