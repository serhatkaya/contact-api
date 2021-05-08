using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Domain.General;
using Infrastructure;
using Infrastructure.Extensions;
using Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Contactbook.Infrastructure.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        internal ContactContext Context;
        internal DbSet<TEntity> dbSet;

        public Repository(ContactContext context)
        {
            this.Context = context;
            dbSet = context.Set<TEntity>();
        }

        public async Task<ApiResponse<List<TEntity>>> GetAsync(Paging pagination,
            Expression<Func<TEntity, bool>> filter = null,
            params Expression<Func<TEntity, object>>[] includeProperties)
        {
            IQueryable<TEntity> query = dbSet.AsQueryable().AsNoTracking();

            if (filter != null)
                query = query.Where(filter);

            if (includeProperties != null)
                foreach (var includeProperty in includeProperties)
                    query = query.Include(includeProperty);

            return new ApiResponse<List<TEntity>>
            {
                Result = await query
                .Sort(pagination.Column, pagination.SortBy)
                .Skip((pagination.Index - 1) * pagination.Size)
                .Take(pagination.Size)
                .ToDynamicListAsync<TEntity>(),
                Total = query.Count(),
                Message = "Success"
            };
        }

        public virtual async Task<ApiResponse<TEntity>> GetById(string id)
        {
            return new ApiResponse<TEntity>
            {
                Result = await dbSet.FindAsync(id),
                Message = "Success"
            };
        }

        public async Task<ApiResponse<TEntity>> GetByIdAsync(string id)
        {
            return new ApiResponse<TEntity>
            {
                Result = await Context.Set<TEntity>().FindAsync(id),
                Message = "Success"
            };
        }

        public async Task<ApiResponse<TEntity>> AddAsync(TEntity entity)
        {
            Context.Set<TEntity>().Add(entity);
            await Context.SaveChangesAsync();
            return new ApiResponse<TEntity>
            {
                Result = entity,
                Message = "Success"
            };
        }

        public virtual void Delete(object id)
        {
            TEntity entity = dbSet.Find(id);
            entity.GetType().GetProperty("Deleted").SetValue(entity, true);
            entity.GetType().GetProperty("UpdatedDate").SetValue(entity, DateTime.UtcNow);
            entity.GetType().GetProperty("DeletedDate").SetValue(entity, DateTime.UtcNow);
            Context.SaveChanges();
        }

        public async Task<bool> DeleteAsync(object id)
        {
            try
            {
                TEntity entity = dbSet.Find(id);
                entity.GetType().GetProperty("Deleted").SetValue(entity, true);
                entity.GetType().GetProperty("UpdatedDate").SetValue(entity, DateTime.UtcNow);
                entity.GetType().GetProperty("DeletedDate").SetValue(entity, DateTime.UtcNow);
                await Context.SaveChangesAsync();
                return true;
            }
            catch
            {

                return false;
            }
        }

        public async Task<ApiResponse<TEntity>> UpdateAsync(TEntity entity, string id)
        {
            var exist = await Context.Set<TEntity>().FindAsync(id);
            Context.Entry(exist).CurrentValues.SetValues(entity);
            foreach (var property in Context.Entry(entity).Properties)
                if (property.CurrentValue == null)
                    Context.Entry(exist).Property(property.Metadata.Name).IsModified = false;
            await Context.SaveChangesAsync();

            return new ApiResponse<TEntity>
            {
                Result = entity,
                Message = "Success",
            };
        }
    }
}