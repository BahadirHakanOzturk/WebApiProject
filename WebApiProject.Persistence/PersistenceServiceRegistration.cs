using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiProject.Application.Contracts.Persistence.Repositories;
using WebApiProject.Persistence.Repositories;

namespace WebApiProject.Persistence;

public static class PersistenceServiceRegistration
{
	public static IServiceCollection AddPersistenceService(this IServiceCollection services, IConfiguration configuration)
	{
		services.AddDbContext<WebApiProjectDataContext>(
			opt => opt.UseSqlServer(configuration.GetConnectionString("WebApiProject"))
			.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking));

		services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
		services.AddScoped<IProductRepository, ProductRepository>();

		return services;
	}
}
