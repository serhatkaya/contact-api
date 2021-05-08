using Domain.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Infrastructure.Interfaces
{
    public interface IRepository<TEntity> where TEntity : class
    {
        void Delete(object id);
        Task<ApiResponse<List<TEntity>>> GetAsync(Paging pagination,
            Expression<Func<TEntity, bool>> filter = null,
           params Expression<Func<TEntity, object>>[] includeProperties);
        Task<ApiResponse<TEntity>> GetById(string id);
        Task<ApiResponse<TEntity>> GetByIdAsync(string id);
        Task<ApiResponse<TEntity>> AddAsync(TEntity entity);
        Task<ApiResponse<TEntity>> UpdateAsync(TEntity entity, string id);
        Task<bool> DeleteAsync(object id);
    }
}
