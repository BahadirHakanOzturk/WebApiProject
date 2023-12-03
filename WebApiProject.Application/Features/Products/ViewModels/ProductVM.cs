using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApiProject.Application.Features.Products.ViewModels;

public class ProductVM
{
    public Guid Id { get; set; }
	public string Name { get; set; } = default!;
	public double Price { get; set; }
}
