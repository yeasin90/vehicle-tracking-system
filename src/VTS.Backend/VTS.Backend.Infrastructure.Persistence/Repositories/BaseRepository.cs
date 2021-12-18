using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using VTS.Backend.Core.Application.Contracts;

namespace VTS.Backend.Infrastructure.Persistence.Repositories
{
    public class BaseRepository<TEntity> : IAsyncRepository<TEntity> where TEntity : class
    {
        protected VtsDbContext _dbContext;
        protected DbSet<TEntity> DbSet;

        public BaseRepository(VtsDbContext dbContext)
        {
            _dbContext = dbContext;
            DbSet = _dbContext.Set<TEntity>();
        }

        public virtual void Delete(object id)
        {
            var entityToDelete = DbSet.Find(id);
            Delete(entityToDelete);
        }

        public virtual void Delete(TEntity entity)
        {
            if (_dbContext.Entry(entity).State == EntityState.Detached)
            {
                DbSet.Attach(entity);
            }
            DbSet.Remove(entity);
        }

        public virtual void DeleteAll(Expression<Func<TEntity, bool>> predicate)
        {
            var entityListToDelete = DbSet.Where(predicate);
            foreach (var entityToDelete in entityListToDelete)
            {
                Delete(entityToDelete);
            }
        }

        public virtual void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public virtual async Task<TEntity> Find(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] includeProperties)
        {
            IQueryable<TEntity> query = DbSet;

            if (includeProperties != null && includeProperties.Length > 0)
            {
                foreach (Expression<Func<TEntity, object>> include in includeProperties)
                    query = query.Include(include);
            }

            return await DbSet.Where(predicate).FirstOrDefaultAsync();
        }

        public virtual IQueryable<TEntity> FindAll(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] includeProperties)
        {
            IQueryable<TEntity> query = DbSet;

            if (includeProperties != null && includeProperties.Length > 0)
            {
                foreach (Expression<Func<TEntity, object>> include in includeProperties)
                    query = query.Include(include);
            }

            return query.Where(predicate);
        }

        public virtual async Task<TEntity> FindById(object id)
        {
            return await DbSet.FindAsync(id);
        }

        public virtual async Task<TEntity> Insert(TEntity entity)
        {
            DbSet.Add(entity);
            await Save();
            return entity;
        }

        public virtual async Task Save()
        {
            using (var transaction = _dbContext.Database.BeginTransaction())
            {
                try
                {
                    await _dbContext.SaveChangesAsync();
                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                }
            }
        }

        public virtual void Update(TEntity entity)
        {
            DbSet.Attach(entity);
            _dbContext.Entry(entity).State = EntityState.Modified;
        }

        private void Dispose(bool disposing)
        {
            if (disposing)
            {
                _dbContext.Dispose();
                _dbContext = null;
            }
        }
    }
}
