using MediatR;
using Microsoft.Extensions.Logging;

namespace WebApiProject.Application.Behaviours;

public class UnhandledExceptionBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>
{
	private readonly ILogger<TRequest> logger;

    public UnhandledExceptionBehaviour(ILogger<TRequest> logger)
		=> this.logger = logger ?? throw new ArgumentNullException(nameof(logger));

	public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
	{
		try
		{
			return await next();
		}
		catch (Exception ex)
		{

			logger.LogError(ex, $"Application Request Unhandled Exception: {nameof(request)} {request}");
			throw;
		}
	}
}
