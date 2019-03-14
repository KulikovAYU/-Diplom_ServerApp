using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace FC_EMDB.Database.UnitOfWork.Interfaces
{    
    /// <summary>
    /// Представляет базовый интерфейс паттерна репозиторий для работы с Entities
    /// </summary>
    public interface IRepository<TEntity> where TEntity : class
    {
        TEntity Get(int Id);
        Task<TEntity> GetAsync(int Id);

        IEnumerable<TEntity> GetAll();

        Task<ICollection<TEntity>> GetAllAsync();
       

        IEnumerable<TEntity> FindAll(Expression<Func<TEntity, bool>> predicate);
        Task<IEnumerable<TEntity>> FindAllAsync(Expression<Func<TEntity, bool>> predicate);

        TEntity Find(Expression<Func<TEntity, bool>> predicate);
        Task<TEntity> FindAsync(Expression<Func<TEntity, bool>> predicate);

        TEntity SingleOrDefault(Expression<Func<TEntity, bool>> predicate);

        TEntity Add(TEntity entity);
        Task<TEntity> AddAsync(TEntity entity);

        TEntity Update(TEntity entity);
        Task<TEntity> UpdateAsync(TEntity entity);

        IEnumerable<TEntity> AddRange(IEnumerable<TEntity> entities);

        void Remove(TEntity entity);
        Task<int> RemoveAsync(TEntity entity);

        void RemoveRange(IEnumerable<TEntity> entities);
        Task<int> RemoveRangeAsync(IEnumerable<TEntity> entities);

    }
}
