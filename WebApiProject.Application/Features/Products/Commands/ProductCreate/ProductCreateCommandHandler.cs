using AutoMapper;
using MediatR;
using WebApiProject.Application.Contracts.Persistence.Repositories;
using WebApiProject.Domain;

namespace WebApiProject.Application.Features.Products.ProductCreate;

public class ProductCreateCommandHandler : IRequestHandler<ProductCreateCommand, bool>
{
	private readonly IProductRepository repository;
	private readonly IMapper mapper;

    public ProductCreateCommandHandler(IProductRepository repository, IMapper mapper)
    {
        this.repository = repository;
		this.mapper = mapper;
    }

    public async Task<bool> Handle(ProductCreateCommand request, CancellationToken cancellationToken)
	{
		var newEntity = mapper.Map<Product>(request);
		return await repository.AddAsync(newEntity, cancellationToken);
	}
}
