using AutoMapper;
using MediatR;
using WebApiProject.Application.Contracts.Persistence.Repositories;
using WebApiProject.Application.Features.Products.ViewModels;

namespace WebApiProject.Application.Features.Products.Queries.GetProductListByName;

public class GetProductListByNameQueryHandler : IRequestHandler<GetProductListByNameQuery, IEnumerable<ProductVM>>
{
	private readonly IProductRepository repository;
	private readonly IMapper mapper;

    public GetProductListByNameQueryHandler(IProductRepository repository, IMapper mapper)
    {
        this.repository = repository ?? throw new ArgumentNullException(nameof(repository));
		this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }

    public async Task<IEnumerable<ProductVM>> Handle(GetProductListByNameQuery request, CancellationToken cancellationToken)
	{
		var data = await repository.GetAllByNameAsync(request.Name, cancellationToken);
		return mapper.Map<IEnumerable<ProductVM>>(data);
	}
}
