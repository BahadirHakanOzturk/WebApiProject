using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApiProject.Application.Features.Products.ProductCreate;

public class ProductCreateCommand : IRequest<bool>
{
	public string Name { get; set; } = default!;
	public double Price { get; set; }
}
