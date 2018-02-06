using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Graph.Util.Extensions
{
    public static class StringExtensions
    {
        public static bool CheckRegularExpression(this string text, string expression)
        {
            return Regex.IsMatch(text, expression, RegexOptions.IgnoreCase | RegexOptions.IgnorePatternWhitespace);
        }
    }
}
