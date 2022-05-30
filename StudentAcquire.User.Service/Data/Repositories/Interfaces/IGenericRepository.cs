using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace StudentAcquire.User.Service.Data.Repositories.Interfaces
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        //CRUD methods

        //C
        TEntity Add(TEntity entity);
        Task<TEntity> AddAsync(TEntity entity);
        IEnumerable<TEntity> AddRange(IEnumerable<TEntity> entities);
        Task<IEnumerable<TEntity>> AddRangeAsync(IEnumerable<TEntity> entities);

        //R
        IQueryable<TEntity> GetAll(params Expression<Func<TEntity, object>>[] includeExpressions);

        IQueryable<TEntity> GetAllBy(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] includeExpressions);

        TEntity GetById(object id);
        Task<TEntity> GetByIdAsync(object id);

        TEntity GetById(Expression<Func<TEntity, bool>> idExpression, params Expression<Func<TEntity, object>>[] includeExpressions);
        Task<TEntity> GetByIdAsync(Expression<Func<TEntity, bool>> idExpression, params Expression<Func<TEntity, object>>[] includeExpressions);

        TEntity GetBy(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] includeExpressions);
        Task<TEntity> GetByAsync(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] includeExpressions);

        //U
        int Update(TEntity entityToUpdate);
        Task<int> UpdateAsync(TEntity entityToUpdate);

        int AddOrUpdate(TEntity[] entities);
        Task<int> AddOrUpdateAsync(TEntity[] entities);

        //D
        int Delete(object id);
        Task<int> DeleteAsync(object id);
        int Delete(Expression<Func<TEntity, bool>> predicate);
        Task<int> DeleteAsync(Expression<Func<TEntity, bool>> predicate);
        int Delete(TEntity entityToDelete);
        Task<int> DeleteAsync(TEntity entityToDelete);


    }
}
