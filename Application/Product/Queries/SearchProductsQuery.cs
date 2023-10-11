using Application.Common.Exceptions;
using Application.Common.Extensions;
using Application.Common.Helpers;
using Application.Interfaces;
using Microsoft.Extensions.Logging;
using System.Data;
using System.Net;

namespace Application.Product.Queries
{
    public sealed record SearchProductsQuery(SearchProductsDTO ProductSearch, int PageIndex, int PageSize) : IPaginatedApiRequest<Domain.Entities.Product>;
    public sealed class SearchProductsQueryHandler : IPaginatedApiRequestHandler<SearchProductsQuery, Domain.Entities.Product>
    {
        private readonly IProductRepository _productRepository;
        private readonly ILogger<SearchProductsQueryHandler> _logger;
        public SearchProductsQueryHandler
            (
            IProductRepository productRepository,
            ILogger<SearchProductsQueryHandler> logger
            )
        {
            _productRepository = productRepository;
            _logger = logger;

        }

        public async Task<PaginatedApiResult<Domain.Entities.Product>> Handle(SearchProductsQuery request, CancellationToken cancellationToken)
        {
            // Get all products from the repository
            var products = await _productRepository.GetAllProducts();

            // Filter by name (partial match)
            if (!string.IsNullOrEmpty(request.ProductSearch.Name))
            {
                products = await CheckProductName(products, request.ProductSearch.Name);
                _logger.LogInformation("Products filtered by name");
            }

            // Filter by category
            if (!string.IsNullOrEmpty(request.ProductSearch.Category))
            {
                products = await CheckCategory(products, request.ProductSearch.Category);
                _logger.LogInformation("Products filtered by category");
            }

            // Filter by price range
            if (request.ProductSearch.MinPrice > 0 && request.ProductSearch.MaxPrice > 0 && request.ProductSearch.MinPrice > request.ProductSearch.MaxPrice)
            {
                // Handle the case where MaxPrice is less than MinPrice 
                _logger.LogError("Max Price lower than Min Price");
                throw new ApiException(HttpStatusCode.BadRequest, "MaxPrice cannot be less than MinPrice");
            }
            if (request.ProductSearch.MinPrice > 0)
            {
                products = products.Where(p => p.Price >= request.ProductSearch.MinPrice);
                _logger.LogInformation("Products filtered by Min Price");
            }

            if (request.ProductSearch.MaxPrice > 0)
            {
                products = products.Where(p => p.Price <= request.ProductSearch.MaxPrice);
                _logger.LogInformation("Products filtered by Max Price");
            }

            // Sort the products based on price
            if (request.ProductSearch.SortOrder == Enums.SortOrder.asc)
            {
                products = products.OrderBy(p => p.Price);
                _logger.LogInformation("Products sorted by ascending price");
            }
            else if (request.ProductSearch.SortOrder == Enums.SortOrder.desc)
            {
                products = products.OrderByDescending(p => p.Price);
                _logger.LogInformation("Products sorted by descending price");
            }

            // Paginate the results
            var result = await PaginatedResponse(products, request.PageIndex, request.PageSize, cancellationToken);

            return result;
        }

        private async Task<IQueryable<Domain.Entities.Product>> CheckProductName(IQueryable<Domain.Entities.Product> source, string name)
        {
            var existingProducts = source.Where(x => x.Name.ToLower().Contains(name.ToLower()));

            if (existingProducts.Count() > 0)
            {
                return existingProducts;
            }
            else
            {
                _logger.LogError($"Product {name} was not found");
                throw new ApiException(HttpStatusCode.NotFound, $"Product {name} was not found");
            }
        }


        private async Task<IQueryable<Domain.Entities.Product>> CheckCategory(IQueryable<Domain.Entities.Product> source, string category)
        {
            var existingProducts = source.Where(x => x.Category.ToLower().Contains(category.ToLower()));
            if (existingProducts.Count() > 0)
            {
                return existingProducts;
            }
            else
            {
                _logger.LogError($" {category} - category was not found");
                throw new ApiException(HttpStatusCode.NotFound, $" {category} - category was not found");
            }
        }

        private async Task<PaginatedApiResult<Domain.Entities.Product>> PaginatedResponse(IQueryable<Domain.Entities.Product> source, int pageIndex, int pageSize, CancellationToken cancellationToken)
        {
            return await source
                .ToPaginatedResultAsync(pageIndex, pageSize);
        }
    }
}
