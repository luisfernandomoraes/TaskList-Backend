using System;
using Supero.TaskList.Domain.Interfaces;
using AppContext = Supero.TaskList.Data.AppContext;

namespace Supero.TaskList.Data
{
    public class UnitOfWork: IUnitOfWork
    {
        private readonly AppContext _context;
        public UnitOfWork(AppContext context)
        {
            this._context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public bool Commit()
        {
            return _context.SaveChanges() > 0;
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
