using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiProject.Domain;

namespace WebApiProject.Application.Contracts.Persistence.Repositories;

public interface IProductRepository : IBaseRepository<Product>
{
	Task<IEnumerable<Product>> GetAllByNameAsync(string name, CancellationToken token);
}
