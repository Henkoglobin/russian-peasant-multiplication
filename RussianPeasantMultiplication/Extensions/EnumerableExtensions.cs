using System;
using System.Collections.Generic;

namespace RussianPeasantMultiplication.Extensions {
    public static class EnumerableExtensions {
        public static string JoinToString(this IEnumerable<string> source, string separator = null)
            => String.Join(separator ?? "", source);

        public static string JoinToString(this IEnumerable<char> source, string separator = null)
            => String.Join(separator ?? "", source);
    }
}
