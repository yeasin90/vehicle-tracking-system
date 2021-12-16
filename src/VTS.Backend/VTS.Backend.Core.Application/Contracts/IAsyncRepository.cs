using System.Collections.Generic;
using System.Threading.Tasks;

namespace VTS.Backend.Core.Application.Contracts
{
    public interface IAsyncRepository<T> where T : class
    {
        Task<T> GetByIdAsync(long id);
        Task<IReadOnlyList<T>> ListAllAsync();
        Task<T> AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);
        Task<IReadOnlyList<T>> GetPagedReponseAsync(int page, int size);
    }
}
