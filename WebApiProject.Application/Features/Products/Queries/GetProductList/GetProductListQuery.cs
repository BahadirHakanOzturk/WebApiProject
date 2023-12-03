using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiProject.Application.Features.Products.ViewModels;

namespace WebApiProject.Application.Features.Products.Queries.GetProductList;

public class GetProductListQuery : IRequest<IEnumerable<ProductVM>>
{
}
