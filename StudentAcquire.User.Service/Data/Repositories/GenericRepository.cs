using Microsoft.EntityFrameworkCore;
using StudentAcquire.User.Service.Data.Repositories.Interfaces;
using StudentAcquire.User.Service.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace StudentAcquire.User.Service.Data.Repositories
{
    public class UserRepository<TEntity> : GenericRepository<TEntity, UserServiceContext>
        where TEntity : class
    {
        public UserRepository(UserServiceContext context) : base(context)
        {
        }
    }

    public class GenericRepository<TEntity, TContext> : IGenericRepository<TEntity>
        where TEntity : class
        where TContext : DbContext
    {
        protected TContext _dbContext;
        protected DbSet<TEntity> _dbSet;

        public GenericRepository(TContext context)
        {
            this._dbContext = context;
            this._dbSet = context.Set<TEntity>();
        }

        #region C

        public virtual TEntity Add(TEntity entity)
        {
            var newEntity = _dbSet.Add(entity);
            _dbContext.SaveChanges();

            return newEntity.Entity;
        }

        public virtual async Task<TEntity> AddAsync(TEntity entity)
        {
            var newEntity = _dbSet.Add(entity);
            await _dbContext.SaveChangesAsync();

            return newEntity.Entity;
        }


        public virtual IEnumerable<TEntity> AddRange(IEnumerable<TEntity> entities)
        {
            var newEntities = _dbSet.AddRangeAsync(entities);
            _dbContext.SaveChangesAsync();

            return (IEnumerable<TEntity>)newEntities;
        }

        public virtual async Task<IEnumerable<TEntity>> AddRangeAsync(IEnumerable<TEntity> entities)
        {
            var newEntities = _dbSet.AddRangeAsync(entities);
            await _dbContext.SaveChangesAsync();

            return (IEnumerable<TEntity>)newEntities;
        }

        #endregion

        #region R

        public virtual IQueryable<TEntity> GetAll(params Expression<Func<TEntity, object>>[] includeExpressions)
        {
            if (includeExpressions.Any())
            {
                var query = Aggregate(includeExpressions);
                return query.AsQueryable();
            }

            return _dbSet.AsQueryable();
        }

        public virtual IQueryable<TEntity> GetAllBy(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] includeExpressions)
        {
            if (includeExpressions.Any())
            {
                var query = Aggregate(includeExpressions);
                return query.Where<TEntity>(predicate).AsQueryable<TEntity>();
            }
            return _dbSet.Where(predicate);
        }

        public virtual TEntity GetById(object id)
        {
            return _dbSet.Find(id);
        }

        public virtual async Task<TEntity> GetByIdAsync(object id)
        {
            return await _dbSet.FindAsync(id);
        }


        public virtual TEntity GetById(Expression<Func<TEntity, bool>> idExpression, params Expression<Func<TEntity, object>>[] includeExpressions)
        {
            if (includeExpressions.Any())
            {
                var set = includeExpressions.Aggregate<Expression<Func<TEntity, object>>, IQueryable<TEntity>>
                         (_dbSet, (current, expression) => current.Include(expression));

                return set.SingleOrDefault(idExpression);
            }

            return _dbSet.SingleOrDefault(idExpression);
        }

        public virtual async Task<TEntity> GetByIdAsync(Expression<Func<TEntity, bool>> idExpression, params Expression<Func<TEntity, object>>[] includeExpressions)
        {
            if (includeExpressions.Any())
            {
                var set = includeExpressions.Aggregate<Expression<Func<TEntity, object>>, IQueryable<TEntity>>
                         (_dbSet, (current, expression) => current.Include(expression));

                return await set.SingleOrDefaultAsync(idExpression);
            }

            return await _dbSet.SingleOrDefaultAsync(idExpression);
        }



        public virtual TEntity GetBy(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] includeExpressions)
        {
            if (includeExpressions.Any())
            {
                var set = includeExpressions.Aggregate<Expression<Func<TEntity, object>>, IQueryable<TEntity>>
                         (_dbSet, (current, expression) => current.Include(expression));

                return set.FirstOrDefault(predicate);
            }

            return _dbSet.FirstOrDefault(predicate);
        }

        public virtual async Task<TEntity> GetByAsync(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] includeExpressions)
        {
            if (includeExpressions.Any())
            {
                var set = includeExpressions.Aggregate<Expression<Func<TEntity, object>>, IQueryable<TEntity>>
                         (_dbSet, (current, expression) => current.Include(expression));

                return await set.FirstOrDefaultAsync(predicate);
            }

            return await _dbSet.FirstOrDefaultAsync(predicate);
        }

        #endregion

        #region U

        public virtual int Update(TEntity entityToUpdate)
        {
            _dbSet.Attach(entityToUpdate);
            _dbContext.Entry(entityToUpdate).State = EntityState.Modified;
            return _dbContext.SaveChanges();
        }

        public virtual async Task<int> UpdateAsync(TEntity entityToUpdate)
        {
            _dbSet.Attach(entityToUpdate);
            _dbContext.Entry(entityToUpdate).State = EntityState.Modified;
            return await _dbContext.SaveChangesAsync();
        }

        public virtual int AddOrUpdate(TEntity[] entities)
        {
            _dbSet.UpdateRange(entities);
            return _dbContext.SaveChanges();
        }

        public virtual async Task<int> AddOrUpdateAsync(TEntity[] entities)
        {
            _dbSet.UpdateRange(entities);
            return await _dbContext.SaveChangesAsync();
        }

        #endregion

        #region D

        public virtual int Delete(object id)
        {
            TEntity entityToDelete = _dbSet.Find(id);
            return Delete(entityToDelete);
        }

        public virtual async Task<int> DeleteAsync(object id)
        {
            TEntity entityToDelete = await _dbSet.FindAsync(id);
            return await DeleteAsync(entityToDelete);
        }

        public virtual int Delete(Expression<Func<TEntity, bool>> predicate)
        {
            var objects = GetAllBy(predicate);
            foreach (var obj in objects)
                _dbSet.Remove(obj);
            return _dbContext.SaveChanges();
        }

        public virtual async Task<int> DeleteAsync(Expression<Func<TEntity, bool>> predicate)
        {
            var objects = GetAllBy(predicate);
            foreach (var obj in objects)
                _dbSet.Remove(obj);
            return await _dbContext.SaveChangesAsync();
        }

        public virtual int Delete(TEntity entityToDelete)
        {
            if (_dbContext.Entry(entityToDelete).State == EntityState.Detached)
            {
                _dbSet.Attach(entityToDelete);
            }
            _dbSet.Remove(entityToDelete);
            return _dbContext.SaveChanges();
        }

        public virtual async Task<int> DeleteAsync(TEntity entityToDelete)
        {
            if (_dbContext.Entry(entityToDelete).State == EntityState.Detached)
            {
                _dbSet.Attach(entityToDelete);
            }
            _dbSet.Remove(entityToDelete);
            return await _dbContext.SaveChangesAsync();
        }

        #endregion

        private IQueryable<TEntity> Aggregate(Expression<Func<TEntity, object>>[] includeExpressions) => includeExpressions.Aggregate<Expression<Func<TEntity, object>>, IQueryable<TEntity>>
                         (_dbSet, (current, expression) => current.Include(expression));
    }
}
