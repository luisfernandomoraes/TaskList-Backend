
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Supero.TaskList.Domain.Interfaces;

namespace Supero.TaskList.Data.Repository
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private readonly AppContext _context;
        private readonly DbSet<TEntity> _dbSet;

        public Repository(AppContext context)
        {
            this._context = context ?? throw new ArgumentNullException(nameof(context));
            _dbSet = this._context.Set<TEntity>();
        }

        public virtual void Add(TEntity obj)
        {
            _dbSet.Add(obj);
            SaveChanges();
        }

        public virtual TEntity GetById(long id)
        {
            return _dbSet.Find(id);
        }

        public virtual IQueryable<TEntity> GetAll()
        {
            return _dbSet;
        }

        public IQueryable<TEntity> Get(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] includeProperties)
        {
            IQueryable<TEntity> query = _dbSet;

            if (includeProperties != null)
                query = includeProperties.Aggregate(query, (current, include) => current.Include(include));

            if (predicate != null)
                query = query.Where(predicate);

            return query;
        }

        public virtual void Update(TEntity obj)
        {
            _dbSet.Update(obj);
            SaveChanges();
        }

        public virtual void Remove(long id)
        {
            _dbSet.Remove(_dbSet.Find(id));
            SaveChanges();
        }

        public int SaveChanges()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
