using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MFPE_CustomerApi.Provider
{
    public interface IProvider<T>
    {
        bool Add(T item);
       
        T Get(int id);
        IEnumerable<T> GetAll();
    }
}
