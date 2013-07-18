using System;
using System.Text;

namespace ACBrFramework
{
    public static class ACBrFrameworkExtensions
    {
        public static Encoding DefaultEncoding = Encoding.UTF8;
 
        public static string ToUTF8(this string value)
        {
            if (string.IsNullOrEmpty(value)) return value;
            return Encoding.Default.GetString(DefaultEncoding.GetBytes(value));
        }

        public static string[] ToUTF8(this string[] value)
        {
            if (value == null || value.Length == 0) return value;

            string[] array = new string[value.Length];

            for (int i = 0; i < value.Length; i++)
            {
                array[i] = ToUTF8(value[i]);
            }

            return array;
        }

        public static string FromUTF8(this string value)
        {
            if (value == null) return null;
            if (value.Length == 0) return string.Empty;

            return DefaultEncoding.GetString(Encoding.Default.GetBytes(value));
        }

        public static string FromUTF8(this StringBuilder value)
        {
            if (value == null) return null;
            if (value.Length == 0) return string.Empty;

            return DefaultEncoding.GetString(Encoding.Default.GetBytes(value.ToString()));
        }
    }
}
