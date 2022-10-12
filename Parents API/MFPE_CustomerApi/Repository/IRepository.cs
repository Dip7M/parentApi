using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParentsApi.Repository
{
    public interface IRepository<T>
    {
        bool Add(T item);
        T Get(int id);
        IEnumerable<T> GetAll();
        
    }
}
