using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Bragi.DataLayer.Utils
{
   public static class StringUtils
    {
        public static string ToUpperOrEmpty(this string input)
        {
            if (string.IsNullOrEmpty(input)) return string.Empty;
            return input.ToUpper();
        }
        public static T ToUpper<T>(this T value) where T : class
        {
            var t = value.GetType();
            var properties = t.GetProperties(BindingFlags.Instance | BindingFlags.Public).Where(c => c.PropertyType == typeof(string));
            foreach (var propertyInfo in properties)
            {
                var newValue = (string)propertyInfo.GetValue(value);
                if (!string.IsNullOrEmpty(newValue))
                {
                    newValue = newValue.ToUpper();
                }
                propertyInfo.SetValue(value, newValue);
            }

            return value;
        }
    }
}
