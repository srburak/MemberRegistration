using MemberRegistration.Core.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemberRegistration.Core.DataAccess.EntityFramework
{
    public class EfQueryableRepository<T> : IQueryableRepository<T> where T : class, IEntity, new()
    {
        private DbContext _context;
        private DbSet<T> _entities;

        public EfQueryableRepository(DbContext context, DbSet<T> entities)
        {
            _context = context;
            _entities = entities;
        }

        public IQueryable<T> Table => this.Entities;

        protected virtual IDbSet<T> Entities => _entities ?? (_entities = _context.Set<T>());
    }
}
