using System.Text.RegularExpressions;

namespace FN.Common.Core
{
    public static class RegularExpression
    {
        public static readonly Regex OnlyDigits = new Regex(@"^\d+$");
    }
}
