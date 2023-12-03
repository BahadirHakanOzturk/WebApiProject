using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApiProject.Application.Features.Products.ProductCreate;
using WebApiProject.Application.Features.Products.Queries.GetProductList;
using WebApiProject.Application.Features.Products.Queries.GetProductListByName;

namespace WebApiProject.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public class ProductController : ControllerBase
{
	private readonly IMediator mediator;
    public ProductController(IMediator mediator)
    {
        this.mediator = mediator;
    }

    [HttpPost("[action]")]
    public async Task<ActionResult<bool>> CreateAsync([FromBody] ProductCreateCommand command)
    {
		var result = await mediator.Send(command);
		return Ok(result);

		//try
		//{
		//	var result = await mediator.Send(command);
		//	return Ok(result);
		//}
		//catch(Application.Exceptions.ValidationException ve)
		//{
		//	return BadRequest(ve.Errors);
		//}
		//catch (Exception)
		//{
		//	throw;
		//}        
	}

	[HttpPost("[action]")]
	public async Task<ActionResult<bool>> GetListByNameAsync([FromBody] GetProductListByNameQuery query)
	{
		var result = await mediator.Send(query);
		return Ok(result);
	}

	[HttpGet("[action]")]
	public async Task<ActionResult<bool>> GetListAsync()
	{
		var result = await mediator.Send(new GetProductListQuery());
		return Ok(result);
	}
}
