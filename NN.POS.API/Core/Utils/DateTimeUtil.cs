using System.Globalization;

namespace NN.POS.API.Core.Utils;

public static class DateTimeUtil
{
    public static DateTime ToDateTime(this object? dateString)
    {
        return DateTime.TryParse(dateString?.ToString(), CultureInfo.InvariantCulture, out var result) 
            ? result : new DateTime(DateTime.UtcNow.Millisecond, DateTimeKind.Utc);
    }
}