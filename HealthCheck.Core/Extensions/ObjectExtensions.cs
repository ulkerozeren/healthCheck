using System.ComponentModel.DataAnnotations;
using System.Reflection;
using System.Text.Json;

namespace HealthCheck.Core.Extensions
{
    public static class ObjectExtensions
    {
        public static bool IsNumericAndGreaterThenZero(this object value)
        {
            try
            {
                return Convert.ToDouble(value) > 0;
            }
            catch
            {
                return false;
            }
        }

        public static bool IsNumericAndGreaterOrEqualZero(this object value)
        {
            try
            {
                return Convert.ToDouble(value) >= 0;
            }
            catch
            {
                return false;
            }
        }

        public static bool IsDatetimeTrueFormat(this object value)
        {
            return DateTime.TryParse(value.ToString(), out _);
        }

        public static bool IsNumeric(this object value)
        {
            try
            {
                return value is sbyte or byte or short or ushort or int or uint or long or ulong or float or double or decimal;
            }
            catch
            {
                return false;
            }
        }

        public static int GetMaxLength<T>(this T obj, string propertyName) where T : class
        {
            var attribute = (StringLengthAttribute)obj?.GetType().GetProperty(propertyName)
                .GetCustomAttribute(typeof(StringLengthAttribute), false);

            if (attribute != null)
                return attribute.MaximumLength;

            return -1;
        }

        public static bool IsRequired<T>(this T obj, string propertyName) where T : class
        {
            var attribute = (StringLengthAttribute)obj?.GetType().GetProperty(propertyName, BindingFlags.Public | BindingFlags.Instance)
                .GetCustomAttribute(typeof(RequiredAttribute), false);

            return attribute != null;
        }

        public static string ToJson(this object value)
        {
            return JsonSerializer.Serialize(value);
        }

        public static string ToNullString(this object obj)
        {
            return obj == null ? "" : obj.ToString();
        }

        public static int ToInt(this object obj, int def = 0)
        {
            if (obj.ToNullString().Length == 0)
            {
                return def;
            }
            int.TryParse(obj.ToNullString(), out var result);
            return result;
        }

        public static int? ToIntNullable(this object obj)
        {
            if (obj.ToNullString().Length == 0)
            {
                return null;
            }
            int.TryParse(obj.ToNullString(), out var res);
            return res;
        }

    }
}
