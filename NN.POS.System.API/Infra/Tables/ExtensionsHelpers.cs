using Microsoft.EntityFrameworkCore;
using NN.POS.System.API.Core;
using NN.POS.System.API.Core.Exceptions;

namespace NN.POS.System.API.Infra.Tables;

public static class ExtensionsHelpers
{
    public static IServiceCollection AddSqlServerDatabase<TContext>(this IServiceCollection services) where TContext : DbContext
    {
        var dataBaseOption = services.GetOptions<Database>("AppSetting:Database");
        services.AddSingleton(dataBaseOption);
        services.AddDbContext<TContext>(option =>
            option.UseSqlServer(dataBaseOption.ConnectionString, opt => opt
                    .EnableRetryOnFailure(5, TimeSpan.FromSeconds(10), null)
                    .CommandTimeout((int)TimeSpan.FromMinutes(5).TotalSeconds))
                .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking)
                .EnableSensitiveDataLogging(false)
        );
        return services;
    }

    public static Guid ToGuid(this string? id)
    {
        var re = Guid.TryParse(id, out var guid);
        if (!re)
            throw new InvalidGuidException(id ?? "empty");
        return guid;
    }
    public static Guid? ToGuidNullable(this string? id)
    {
        if (id == null) return null;
        var re = Guid.TryParse(id, out var guid);
        if (!re)
            return null;
        return guid;
    }
    public static IEnumerable<TResult> FullJoinDistinct<TLeft, TRight, TKey, TResult>(
        this IEnumerable<TLeft> leftItems,
        IEnumerable<TRight> rightItems,
        Func<TLeft, TKey> leftKeySelector,
        Func<TRight, TKey> rightKeySelector,
        Func<TLeft, TRight, TResult> resultSelector
    )
    {

        var leftJoin =
            from left in leftItems
            join right in rightItems
                on leftKeySelector(left) equals rightKeySelector(right) into temp
            from right in temp.DefaultIfEmpty()
            select resultSelector(left, right);

        var rightJoin =
            from right in rightItems
            join left in leftItems
                on rightKeySelector(right) equals leftKeySelector(left) into temp
            from left in temp.DefaultIfEmpty()
            select resultSelector(left, right);

        return leftJoin.Union(rightJoin);
    }

    public static string Underscore(this string value)
        => string.Concat(value.Select((x, i) => i > 0 && char.IsUpper(x) ? "_" + x.ToString() : x.ToString()));

    public static string? Right(this string str, int count)
    {
        return str.Length < count ? null : str.Substring(str.Length - count, count);
    }
    public static string? Left(this string str, int count)
    {
        return str.Length < count ? null : str[..count];
    }
    public static TModel GetOptions<TModel>(this IServiceCollection services, string section) where TModel : new()
    {
        using var serviceProvider = services.BuildServiceProvider();
        var configuration = serviceProvider.GetService<IConfiguration>()!;
        return configuration.GetOptions<TModel>(section);
    }
    public static TModel GetOptions<TModel>(this IConfiguration configuration, string section) where TModel : new()
    {
        var model = new TModel();
        configuration?.GetSection(section).Bind(model);

        return model;
    }
}