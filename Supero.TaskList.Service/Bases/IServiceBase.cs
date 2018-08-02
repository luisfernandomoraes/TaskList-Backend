using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Supero.TaskList.Domain.Base;

namespace Supero.TaskList.Service.Bases
{
    public interface IServiceBase<TEntity> where TEntity : Entity
    {
        void Create(TEntity entity);
        TEntity Read(long id);
        IEnumerable<TEntity> Read(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] includeProperties);
        IEnumerable<TEntity> ReadAll();
        void Update(TEntity entity);
        void Delete(long id);
    }
}
