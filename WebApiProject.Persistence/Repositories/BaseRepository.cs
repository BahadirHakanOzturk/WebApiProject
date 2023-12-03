using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using WebApiProject.Application.Contracts.Persistence.Repositories;
using WebApiProject.Domain.Common;

namespace WebApiProject.Persistence.Repositories;

public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity, new()
{
	protected readonly WebApiProjectDataContext context;
	public BaseRepository(WebApiProjectDataContext context)
		=> this.context = context ?? throw new ArgumentNullException(nameof(context));

	public async Task<bool> AddAsync(T entity, CancellationToken token)
	{
		await context.Set<T>().AddAsync(entity, token);
		await context.SaveChangesAsync();
		return true;
	}

	public async Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>> expression, CancellationToken token)
		=> await context.Set<T>().Where(expression).ToListAsync(token);

	public async Task<T> GetAsync(Expression<Func<T, bool>> expression, CancellationToken token)
		=> await context.Set<T>().FirstOrDefaultAsync(expression, token) ?? throw new Exception($"{nameof(T)} Data Not Found!");
}
