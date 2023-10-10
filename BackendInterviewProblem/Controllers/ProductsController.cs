using BackendInterviewProblem.Controllers.Common;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Domain.Entities;
using Application.Common.Helpers;
using Application.Product.Queries;
using Swashbuckle.AspNetCore.Annotations;

[ApiController]
public class ProductsController : BaseApiController
{

    [HttpGet]
    [SwaggerOperation(
    Summary = "Get products by name, category , minprice, maxprice and sorts based on price",
    Description = "Retrieve a list of products by specifying query.")]
    public async Task<ActionResult<PaginatedApiResult<Product>>> GetProducts([FromQuery] SearchProductsDTO searchProducts, [FromQuery] PaginationQuery paginationQuery)
    {
        return await Mediator.Send(new SearchProductsQuery(searchProducts, paginationQuery.PageIndex, paginationQuery.PageSize));
    }
}