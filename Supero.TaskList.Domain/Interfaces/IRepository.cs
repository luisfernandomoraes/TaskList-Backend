using System;
using System.Linq;

namespace Supero.TaskList.Domain.Interfaces
{
    public interface IRepository<TEntity> : IDisposable where TEntity : class
    {
        void Add(TEntity entity);
        TEntity GetById(long id);
        IQueryable<TEntity> GetAll();
        void Update(TEntity entity);
        void Remove(long id);
        int SaveChanges();
    }
}