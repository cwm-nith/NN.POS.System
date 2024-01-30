using System.Text.RegularExpressions;

namespace NN.POS.Web.RegexExpression;

public static partial class RegexExpressionHelper
{
    [GeneratedRegex("/^[0-9]*$/g")]
    public static partial Regex NumberOnlyRegex();

    [GeneratedRegex(@"/(\..*){2,}/g")]
    public static partial Regex ContainOnlyOneDotRegex();
}
