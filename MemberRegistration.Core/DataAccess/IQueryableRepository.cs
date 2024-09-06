using MemberRegistration.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemberRegistration.Core.DataAccess
{
    public interface IQueryableRepository<out T> where T : class, IEntity, new()
    {
        IQueryable<T> Table { get; }
    }
}
