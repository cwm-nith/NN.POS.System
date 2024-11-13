using System.Text.RegularExpressions;

namespace NN.POS.Web.RegexExpression;

public static partial class RegexExpressionHelper
{
    public static Regex NumberOnlyRegex()
    {
        return new Regex("/^[0-9]*$/g", RegexOptions.Compiled);
    }
    public static Regex ContainOnlyOneDotRegex()
    {
        return new Regex(@"/(\..*){2,}/g", RegexOptions.Compiled);
    }
}
