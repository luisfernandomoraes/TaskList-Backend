using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Supero.TaskList.Domain.Base;
using Supero.TaskList.Domain.Interfaces;

namespace Supero.TaskList.Service.Bases
{
    public class ServiceBase<TEntity> : IServiceBase<TEntity> where TEntity : Entity
    {
        protected readonly IRepository<TEntity> Repository;
        public ServiceBase(IRepository<TEntity> repository)
        {
            Repository = repository;
        }

        public void Create(TEntity entity)
        {
            Repository.Add(entity);
        }

        public void Delete(long id)
        {
            Repository.Remove(id);
        }

        public TEntity Read(long id)
        {
           return Repository.GetById(id);
        }

        public IEnumerable<TEntity> Read(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] includeProperties)
        {
            return Repository.Get(predicate, includeProperties);
        }

        public IEnumerable<TEntity> ReadAll()
        {
            return Repository.GetAll();
        }

        public void Update(TEntity entity)
        {
            Repository.Update(entity);
        }
    }
}
