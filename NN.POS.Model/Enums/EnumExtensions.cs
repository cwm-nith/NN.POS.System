using System.Reflection;
using System.Runtime.Serialization;

namespace NN.POS.Model.Enums;

public static class EnumExtensions
{
    /// <summary>
    /// Get attribute of current enum value
    /// </summary>
    /// <param name="value"></param>
    /// <typeparam name="TAttribute"></typeparam>
    /// <returns></returns>
    public static TAttribute? GetAttribute<TAttribute>(this Enum value)
        where TAttribute : Attribute
    {
        var type = value.GetType();
        var name = Enum.GetName(type, value)!;
        return type.GetField(name)!.GetCustomAttribute<TAttribute>(inherit: true);
    }

    /// <summary>
    /// Convert enum value to enum string base on EnumMemberAttribute if specified
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public static string ToEnumString(this Enum value)
    {
        var attribute = value.GetAttribute<EnumMemberAttribute>();
        return attribute == null ? value.ToString() : attribute.Value!;
    }

    /// <summary>
    /// Convert string to enum base on EnumMemberAttribute
    /// </summary>
    /// <param name="value"></param>
    /// <param name="useDefaultValue">Fallback to default if no value is matched</param>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public static T? ToEnum<T>(this string value, bool useDefaultValue = false) where T : Enum
    {
        var enumType = typeof(T);

        foreach (var name in Enum.GetNames(enumType))
        {
            var fieldInfo = enumType.GetField(name)!;

            if (fieldInfo.GetCustomAttribute(typeof(EnumMemberAttribute), inherit: true) is not EnumMemberAttribute
                enumMemberAttribute)
            {
                continue;
            }

            if (string.Equals(enumMemberAttribute.Value, value, StringComparison.CurrentCultureIgnoreCase))
            {
                return (T)Enum.Parse(enumType, name);
            }
        }

        if (useDefaultValue)
        {
            return default;
        }

        throw new ArgumentException($"Can not convert value '{value}' to EnumType {nameof(enumType)}");
    }
}