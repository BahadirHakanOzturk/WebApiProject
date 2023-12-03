using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApiProject.Application.Features.Products.ProductCreate;

public class ProductCreateCommandValidator : AbstractValidator<ProductCreateCommand>
{
	public ProductCreateCommandValidator()
	{
		RuleFor(r => r.Name)
			.NotEmpty().WithMessage("Name is required")
			.NotNull()
			.MinimumLength(3)
			.MaximumLength(64).WithMessage("Name must not exceed 64 characters");

		RuleFor(r => r.Price)
			.GreaterThan(0);
	}
}
