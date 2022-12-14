using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParentsApi.Provider
{
    public interface IProvider<T>
    {
        bool Add(T model);
        T Get(int id);
        IEnumerable<T> GetAll();
    }
}
