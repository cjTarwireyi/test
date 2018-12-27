using System.Collections.Generic;
using System.Threading.Tasks;

namespace ObtainLeads.Business
{
    public interface IBaseLogic<T>
    {
        Task<IEnumerable<T>> Get();
        Task<T> Find(int id);
        Task Add(T model);
        Task Update(T model);
        Task Delete(int id);
    }
}
