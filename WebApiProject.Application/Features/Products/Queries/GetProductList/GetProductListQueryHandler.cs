using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiProject.Application.Contracts.Persistence.Repositories;
using WebApiProject.Application.Features.Products.ViewModels;

namespace WebApiProject.Application.Features.Products.Queries.GetProductList;

public class GetProductListQueryHandler : IRequestHandler<GetProductListQuery, IEnumerable<ProductVM>>
{
	private readonly IProductRepository repository;
	private readonly IMapper mapper;

	public GetProductListQueryHandler(IProductRepository repository, IMapper mapper)
	{
		this.repository = repository ?? throw new ArgumentNullException(nameof(repository));
		this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
	}

	public async Task<IEnumerable<ProductVM>> Handle(GetProductListQuery request, CancellationToken cancellationToken)
		=> mapper.Map<IEnumerable<ProductVM>>(await repository.GetAllAsync(f => f != null, cancellationToken));
}
