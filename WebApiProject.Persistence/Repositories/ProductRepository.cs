using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiProject.Application.Contracts.Persistence.Repositories;
using WebApiProject.Domain;

namespace WebApiProject.Persistence.Repositories;

public class ProductRepository : BaseRepository<Product>, IProductRepository
{
	public ProductRepository(WebApiProjectDataContext context) : base(context)
	{
	}

	public async Task<IEnumerable<Product>> GetAllByNameAsync(string name, CancellationToken token)
		=> await base.GetAllAsync(g => g.Name.Contains(name), token);
}
