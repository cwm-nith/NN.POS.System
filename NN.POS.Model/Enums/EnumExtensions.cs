namespace NN.POS.Model.Enums;

public static class EnumExtensions
{
    public static string ToEnumString(this Enum value)
    {
        return value.ToString();
    }

    public static T ToEnum<T>(this string value, bool ignoreCase)
    {
        return (T)Enum.Parse(typeof(T), value, ignoreCase);
    }
}