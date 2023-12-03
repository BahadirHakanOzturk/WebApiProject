using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using WebApiProject.Application.Behaviours;

namespace WebApiProject.Application;

public static class ApplicationServiceRegistration
{
	public static IServiceCollection AddApplicationService(this IServiceCollection services)
	{
		services.AddAutoMapper(Assembly.GetExecutingAssembly());
		services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
		services.AddMediatR(opt => opt.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));

		//services.AddTransient(typeof(IPipelineBehavior<,>), typeof(UnhandledExceptionBehaviour<,>));
		services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));

		return services;
	}
}
