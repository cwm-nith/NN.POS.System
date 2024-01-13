namespace NN.POS.API.Core.Utils;

public static class NumberUtil
{
    public static int ToInt(this object? input)
    {
        return int.TryParse(input?.ToString(), out var id) ? id : 0;
    }

    public static decimal ToDecimal(this object? input)
    {
        return decimal.TryParse(input?.ToString(), out var id) ? id : 0;
    }
}