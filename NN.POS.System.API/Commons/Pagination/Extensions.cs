using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace NN.POS.System.API.Commons.Pagination;

public static class Extensions
{
    public static async Task<PagedResult<T>> PaginateAsync<T>(this IQueryable<T> collection, IPagedQuery query,
        CancellationToken cancellation = default)
        => await collection.PaginateAsync(
            query is { Page: var page } ? page : 1,
            query is { Results: var result } ? result : 0, 
            cancellation);


    public static async Task<PagedResult<T>> PaginateAsync<T>(this IQueryable<T> collection,
        int page = 1, int resultsPerPage = 10, CancellationToken cancellation = default)
    {
        if (page <= 0)
        {
            page = 1;
        }
        if (resultsPerPage <= 0)
        {
            resultsPerPage = 10;
        }
        var isEmpty = !await collection.AnyAsync(cancellation);
        if (isEmpty)
        {
            return PagedResult.Empty<T>();
        }
        var totalResults = await collection.CountAsync(cancellation);
        var totalPages = (int)Math.Ceiling((decimal)totalResults / resultsPerPage);
        var data = await collection.Limit(page, resultsPerPage).ToListAsync(cancellation);

        return PagedResult.Create(data, page, resultsPerPage, totalPages, totalResults);
    }
    public static async Task<PagedResult<T>> PaginateAsync<T>(this IQueryable<T> collection,
        Expression<Func<T, bool>> condition, int resultsPerPage = 10, CancellationToken cancellation = default)
    {
        int page = 1;
        if (resultsPerPage <= 0)
        {
            resultsPerPage = 10;
        }
        var isEmpty = !await collection.AnyAsync(cancellation);
        if (isEmpty)
        {
            return PagedResult.Empty<T>();
        }
        var totalResults = await collection.CountAsync(cancellation);
        var totalPages = (int)Math.Ceiling((decimal)totalResults / resultsPerPage);
        var data = await collection.Where(condition).Limit(page, resultsPerPage).ToListAsync(cancellation);

        return PagedResult.Create(data, page, resultsPerPage, totalPages, totalResults);
    }
    public static IQueryable<T> Limit<T>(this IQueryable<T> collection, IPagedQuery query)
        => collection.Limit(query.Page, query.Results);

    public static IQueryable<T> Limit<T>(this IQueryable<T> collection,
        int page = 1, int resultsPerPage = 10)
    {
        if (page <= 0)
        {
            page = 1;
        }
        if (resultsPerPage <= 0)
        {
            resultsPerPage = 10;
        }
        var skip = (page - 1) * resultsPerPage;

        var data = collection.Skip(skip)
            .Take(resultsPerPage);

        return data;
    }
}