using Application.Common.Helpers;

namespace Application.Common.Extensions;


public static class IQueryableExtensions
{
    public static async Task<PaginatedApiResult<T>> ToPaginatedResultAsync<T>(this IQueryable<T> query, int? pageIndex, int? pageSize, CancellationToken cancellationToken = default)
    {
        var totalCount = query.Count();

        (pageSize, pageIndex) = SanitizePaginationValues(pageIndex, pageSize);

        var items = query.Paginate(pageIndex, pageSize).ToArray();

        return PaginatedApiResult<T>.Success(items, totalCount, pageIndex.Value, pageSize.Value);
    }

    private static (int pageSize, int pageIndex) SanitizePaginationValues(int? pageIndex, int? pageSize)
    {
        pageSize = pageSize is null or < 1 ? 5 : pageSize;
        pageIndex = pageIndex is null or < 1 ? 1 : pageIndex;

        return (pageSize.Value, pageIndex.Value);
    }

    public static IQueryable<T> Paginate<T>(this IQueryable<T> query, int? pageIndex, int? pageSize)
    {
        (pageSize, pageIndex) = SanitizePaginationValues(pageIndex, pageSize);

        return query
            .Skip((pageIndex.Value - 1) * pageSize!.Value)
            .Take(pageSize.Value);
    }
}
