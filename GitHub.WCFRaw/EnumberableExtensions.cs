using System.Collections.Generic;
using System.Linq;

namespace GitHub.WCFRaw
{
    /// <summary>
    /// IEnumerable Extensions
    /// </summary>
    public static class EnumberableExtensions
    {
        /// <summary>
        /// Test if null or empty
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <returns></returns>
        public static bool IsEmpty<T>(this IEnumerable<T> source)
        {
            if (source == null) return true;
            return !source.Any();
        }
    }
}
