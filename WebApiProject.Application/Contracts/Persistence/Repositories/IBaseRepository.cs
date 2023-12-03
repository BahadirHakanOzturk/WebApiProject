using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using WebApiProject.Domain.Common;

namespace WebApiProject.Application.Contracts.Persistence.Repositories;

public interface IBaseRepository<T> where T : BaseEntity, new()
{
    Task<bool> AddAsync(T entity, CancellationToken token);
    Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>> expression, CancellationToken token);
    Task<T> GetAsync(Expression<Func<T, bool>> expression, CancellationToken token);
}
