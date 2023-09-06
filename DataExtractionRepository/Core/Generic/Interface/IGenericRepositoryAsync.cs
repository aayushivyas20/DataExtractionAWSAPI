using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataExtractionRepository.Core.Generic.Interface
{
    public interface IGenericRepositoryAsync<T> where T : class
    {
        //Task<T> GetByIdAsync(int id);
        //Task<T> GetByStringIdByAsync(string id);
        Task<IReadOnlyList<T>> GetAllAsync();
        Task<IReadOnlyList<T>> GetPagedReponseAsync(int pageNumber, int pageSize);
        Task<T> AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);
    }
}
