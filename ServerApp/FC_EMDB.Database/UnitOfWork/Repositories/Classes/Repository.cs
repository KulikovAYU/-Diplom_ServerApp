using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace FC_EMDB.Database.UnitOfWork
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly Microsoft.EntityFrameworkCore.DbContext m_context;
        protected readonly IQueryable<TEntity> m_entities;

        public Repository(Microsoft.EntityFrameworkCore.DbContext context)
        {
            m_context = context;
            m_entities = m_context.Set<TEntity>();
        }
        public TEntity Get(int Id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TEntity> GetAll()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public TEntity SingleOrDefault(Expression<Func<TEntity, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public void Add(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public void AddRange(IEnumerable<TEntity> entities)
        {
            throw new NotImplementedException();
        }

        public void Remove(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public void RemoveRange(IEnumerable<TEntity> entities)
        {
            throw new NotImplementedException();
        }
    }
}
