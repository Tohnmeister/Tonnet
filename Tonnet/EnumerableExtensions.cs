namespace Tonnet
{
    public static class EnumerableExtensions
    {
        /// <summary>
        /// This function helps with using possibly null enumerable collections
        /// in Linq statements by returning an empty enumerable if the source is
        /// null.
        /// </summary>
        /// <typeparam name="T">The type of elements in the collection.</typeparam>
        /// <param name="source">The enumerable collection to check.</param>
        /// <returns>The source enumerable if it is not null, or an empty enumerable if it is.</returns>
        public static IEnumerable<T> EmptyIfNull<T>(this IEnumerable<T>? source)
        {
            if (source == null) return [];

            return source;
        }
    }
}
