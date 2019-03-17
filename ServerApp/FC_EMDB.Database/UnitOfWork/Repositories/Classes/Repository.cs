using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using FC_EMDB.Database.UnitOfWork.Interfaces;
using Microsoft.EntityFrameworkCore;

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
            return m_context?.Set<TEntity>().Find(Id);
        }

        public async Task<TEntity> GetAsync(int Id)
        {
            return await m_context.Set<TEntity>().FindAsync(Id);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return m_entities?.ToList();
        }

        public async Task<ICollection<TEntity>> GetAllAsync()
        {
            return await m_context.Set<TEntity>().ToListAsync();
        }

        public IEnumerable<TEntity> FindAll(Expression<Func<TEntity, bool>> predicate)
        {
            return m_context?.Set<TEntity>().Where(predicate).ToList();
        }

        public async Task<IEnumerable<TEntity>> FindAllAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await m_context.Set<TEntity>().Where(predicate).ToListAsync();
        }

        public TEntity Find(Expression<Func<TEntity, bool>> predicate)
        {
            return m_context?.Set<TEntity>().SingleOrDefault(predicate);
        }

        public async Task<TEntity> FindAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await m_context.Set<TEntity>().Where(predicate).SingleOrDefaultAsync();
        }

        public TEntity SingleOrDefault(Expression<Func<TEntity, bool>> predicate)
        {
            return m_entities.SingleOrDefault(predicate);
        }

        public TEntity Add(TEntity entity)
        {
            if (entity == null) return null;
            m_context?.Set<TEntity>().Add(entity);
            m_context?.SaveChanges();
            return entity;
        }

        public async Task<TEntity> AddAsync(TEntity entity)
        {
            m_context.Set<TEntity>().Add(entity);
            await m_context.SaveChangesAsync();
            return entity;
        }

        public TEntity Update(TEntity entity)
        {
            if (entity == null)
            {
                return null;
            }

            m_context.Set<TEntity>().Attach(entity);
            m_context.Entry(entity).State = EntityState.Modified;
            m_context.SaveChanges();
            return entity;
        }

        public async Task<TEntity> UpdateAsync(TEntity entity)
        {
            if (entity == null)
            {
                return null;
            }

            m_context.Set<TEntity>().Attach(entity);
            m_context.Entry(entity).State = EntityState.Modified;
            await m_context.SaveChangesAsync();
            return entity;
        }

        public IEnumerable<TEntity> AddRange(IEnumerable<TEntity> entities)
        {
            if (entities == null) return null;
            var addRange = entities as TEntity[] ?? entities.ToArray();
            m_context.Set<TEntity>().AddRange(addRange);
            foreach (var curr in addRange)
            {
                m_context.Entry(curr).State = EntityState.Added;
            }
          
            m_context.SaveChanges();
            return addRange;
        }

        public void Remove(TEntity entity)
        {
            m_context.Set<TEntity>().Remove(entity);
            m_context.SaveChanges();
        }

        public async Task<int> RemoveAsync(TEntity entity)
        {
            m_context.Set<TEntity>().Remove(entity);
            return await m_context.SaveChangesAsync();
        }

        public void RemoveRange(IEnumerable<TEntity> entities)
        {
            if (entities == null) return;
            m_context.Set<TEntity>().RemoveRange(entities);
        }

        public async Task<int> RemoveRangeAsync(IEnumerable<TEntity> entities)
        {
            if (entities == null) return -1;
            m_context.Set<TEntity>().RemoveRange(entities);
            return await m_context.SaveChangesAsync();
        }
    }
}
