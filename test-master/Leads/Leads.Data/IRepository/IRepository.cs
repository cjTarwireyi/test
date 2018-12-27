using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leads.Data.IRepository
{
    public interface IRepository<T>
    {
        Task<IEnumerable<T>> Get();
        Task<T> Get(int id);
        Task Add(T model);
        Task Update(int id);
        Task Delete(T model);
        Task Save();
    }
}
