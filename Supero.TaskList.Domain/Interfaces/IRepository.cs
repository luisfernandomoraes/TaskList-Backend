using System;
using System.Linq;
using System.Linq.Expressions;

namespace Supero.TaskList.Domain.Interfaces
{
    public interface IRepository<TEntity> : IDisposable where TEntity : class
    {
        void Add(TEntity entity);
        TEntity GetById(long id);
        IQueryable<TEntity> GetAll();
        IQueryable<TEntity> Get(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] includeProperties);
        void Update(TEntity entity);
        void Remove(long id);
        int SaveChanges();
    }
}