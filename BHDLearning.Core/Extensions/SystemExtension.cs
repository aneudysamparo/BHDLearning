using System;
using System.Collections.Generic;
using System.Text;

namespace System
{
    public static class SystemExtension
    {
        public static string Format(this string format, params object[] parameters)
        {
            return string.Format(format, parameters);
        }

        public static bool IsNullOrEmpty(this string value)
        {
            return string.IsNullOrEmpty(value);
        }

        public static bool IsNullOrWhiteSpace(this string value)
        {
            return string.IsNullOrWhiteSpace(value);
        }
    }
}
