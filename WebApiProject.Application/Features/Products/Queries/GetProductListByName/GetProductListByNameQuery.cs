using MediatR;
using WebApiProject.Application.Features.Products.ViewModels;

namespace WebApiProject.Application.Features.Products.Queries.GetProductListByName;

public class GetProductListByNameQuery : IRequest<IEnumerable<ProductVM>>
{
    public string Name { get; set; } = null!;
}
