using System;
using System.Reflection;
using PacketDotNet;

namespace CodeStrikeBot
{
    public static class Extensions
    {
        public static string ToString<T>(this ID id)
        {
            return ToString(id, typeof(T));
        }

        public static string ToString(this ID id, Type type)
        {
            foreach (var field in type.GetFields(BindingFlags.GetField | BindingFlags.Public | BindingFlags.Static))
            {
                if ((field.FieldType == typeof(ID)) && id.Equals(field.GetValue(null)))
                {
                    return string.Format("{0}.{1}", type.ToString().Replace('+', '.'), field.Name);
                }
            }

            foreach (var nestedType in type.GetNestedTypes())
            {
                string asNestedType = ToString(id, nestedType);
                if (asNestedType != null)
                {
                    return asNestedType;
                }
            }

            return null;
        }

        public static bool Within(this System.Drawing.Color color, int r, int g, int b, int threshold)
        {
            return Math.Abs(color.R - r) <= threshold && Math.Abs(color.G - g) <= threshold && Math.Abs(color.B - b) <= threshold;
        }

        public static bool Equals(this System.Drawing.Color color, int r, int g, int b)
        {
 	         return color.Within(r, g, b, 0);
        }
    }
}
