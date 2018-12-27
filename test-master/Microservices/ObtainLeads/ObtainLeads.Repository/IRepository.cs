using System.Collections.Generic;
using System.Threading.Tasks;

namespace ObtainLeads.Repository
{
    public interface IRepository<T>
    {
        Task<IEnumerable<T>> Get();
        Task<T> Find(int id);
        Task<bool> Exist(int id);
        Task Add(T entity);
        void Update(T entity);
        Task Delete(int id);
        Task SaveAsync();
    }
}
