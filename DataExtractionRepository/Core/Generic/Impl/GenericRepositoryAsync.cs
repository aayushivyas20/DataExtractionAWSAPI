using DataExtractionAWSData.Context;
using DataExtractionRepository.Core.Generic.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataExtractionRepository.Core.Generic.Impl
{
    public class GenericRepositoryAsync<T> : IGenericRepositoryAsync<T> where T : class
    {
        private readonly DataExtractionDbContext _dbContext;

        public GenericRepositoryAsync(DataExtractionDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        //public virtual async Task<T> GetByIdAsync(int id)
        //{
        //    return await _dbContext.Set<T>().FindAsync(id);
        //}

        //public virtual async Task<T> GetByStringIdByAsync(string id)
        //{
        //    return await _dbContext.Set<T>().FindAsync(id);
        //}

        public async Task<IReadOnlyList<T>> GetPagedReponseAsync(int pageNumber, int pageSize)
        {
            return await _dbContext
                .Set<T>()
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<T> AddAsync(T entity)
        {
            await _dbContext.Set<T>().AddAsync(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }

        public async Task UpdateAsync(T entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(T entity)
        {
            _dbContext.Set<T>().Remove(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<IReadOnlyList<T>> GetAllAsync()
        {
            return await _dbContext
                 .Set<T>()
                 .ToListAsync();
        }
    }
}
