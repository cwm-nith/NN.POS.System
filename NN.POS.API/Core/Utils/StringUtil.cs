using System.Text;

namespace NN.POS.API.Core.Utils;

public static class StringUtil
{
    public static string GetRandomString(int stringLength = 10, string? prefix = null)
    {
        var sb = new StringBuilder();
        var prefixLength = 0;
        if (prefix is not null)
        {
            sb.Append(prefix);
            prefixLength = prefix.Length;
        }

        for (var i = 1; i <= stringLength; i++)
        {
            sb.Append(Guid.NewGuid().ToString("N"));
        }

        return sb.ToString(0, stringLength + prefixLength).ToUpper();
    }
}