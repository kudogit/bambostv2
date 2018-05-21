using Bamboo.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Linq.Expressions;
using Bamboo.Data.EF.Extensions;

namespace Bamboo.Data.EF.Repositories
{
    public class Repository<CustomDbContext, TEntity> : IRepository<TEntity> where TEntity : BaseEntity 
        where CustomDbContext : Microsoft.EntityFrameworkCore.DbContext
    {

        private readonly CustomDbContext _dbContext;
        private readonly DbSet<TEntity> _dbSet;

        public Repository(CustomDbContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = _dbContext.Set<TEntity>();
        }

        public DbSet<TEntity> DbSet => _dbSet ?? _dbContext.Set<TEntity>();

        public TEntity Add(TEntity entity)
        {

            entity.CreatedDateTime = DateTimeOffset.UtcNow;
            return DbSet.Add(entity).Entity;
        }

        public void Delete(TEntity entity, bool isPhysicalDelete = false)
        {
            try
            {
                TryAttach(entity);
                if(!isPhysicalDelete)
                {
                    entity.DeletedDateTime = DateTimeOffset.UtcNow;
                    _dbContext.Entry(entity).Property(x => x.DeletedDateTime).IsModified = true;
                }
                else
                {
                    DbSet.Remove(entity);
                }
            }
            catch(Exception err)
            {
                throw;
            }
        }

        public void DeleteWhere(Expression<Func<TEntity, bool>> predicate, bool isPhysicalDelete = false)
        {
            var entities = Get(predicate).AsEnumerable();

            foreach (var entity in entities)
            {
                Delete(entity, isPhysicalDelete);
            }
        }

        public IQueryable<TEntity> Get(Expression<Func<TEntity, bool>> predicate = null, params Expression<Func<TEntity, object>>[] includeProperties)
        {
            var query = DbSet.AsNoTracking();

            includeProperties = includeProperties?.Distinct().ToArray();

            if (includeProperties?.Any() == true)
            {
                foreach (var includeProperty in includeProperties)
                    query = query.Include(includeProperty);
            }

            return (predicate == null ? query : query.Where(predicate)).WhereNotDeleted();
        }

        public TEntity GetById(int id)
        {
            return Get(x => x.Id == id).SingleOrDefault();
        }

        public TEntity GetSingle(Expression<Func<TEntity, bool>> predicate = null, bool isIncludeDeleted = false, params Expression<Func<TEntity, object>>[] includeProperties)
        {
            return Get(predicate, includeProperties).FirstOrDefault();
        }

        public IQueryable<TEntity> Include(params Expression<Func<TEntity, object>>[] includeProperties)
        {
            var query = DbSet.AsNoTracking();
            foreach (var includeProperty in includeProperties)
                query = query.Include(includeProperty);
            return query.WhereNotDeleted();
        }

        public int SaveChanges()
        {
            return _dbContext.SaveChanges();
        }

        public int SaveChanges(bool acceptAllChangesOnSuccess)
        {
            return _dbContext.SaveChanges(acceptAllChangesOnSuccess);
        }

        public void Update(TEntity entity, params Expression<Func<TEntity, object>>[] changedProperties)
        {
            TryAttach(entity);

            changedProperties = changedProperties?.Distinct().ToArray();
            entity.LastUpdatedDateTime = DateTimeOffset.UtcNow;

            if (changedProperties?.Any() == true)
            {
                foreach (var property in changedProperties)
                {
                    _dbContext.Entry(entity).Property(property).IsModified = true;
                }
            }
            else
                _dbContext.Entry(entity).State = EntityState.Modified;
        }

        public void Update(TEntity entity)
        {
            TryAttach(entity);
            entity.LastUpdatedDateTime = DateTimeOffset.UtcNow;
            _dbContext.Entry(entity).State = EntityState.Modified;
        }

        public virtual bool TryAttach(TEntity entity)
        {
            try
            {
                if (_dbContext.Entry(entity).State == EntityState.Detached)
                    DbSet.Attach(entity);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
