using System;
using System.Collections.Generic;
using System.Linq;

namespace alltdl.Extensions
{
    /// <summary>
    /// IEnumerable extension.
    /// </summary>
    public static partial class IEnumerableExtension
    {
        /// <summary>
        /// Splits an IEnumerable into batches.
        /// </summary>
        /// <param name="items">The items.</param>
        /// <param name="batchSize">The batch size.</param>
        /// <returns>IEnumerable to batch</returns>
        public static IEnumerable<IEnumerable<T>> Batch<T>(this IEnumerable<T> items,
            int batchSize)
        {
            return items.Select((item, inx) => new { item, inx })
                .GroupBy(x => x.inx / batchSize)
                .Select(g => g.Select(x => x.item));
        }

        /// <summary>
        /// Get random elements from IEnumerable
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="items"></param>
        /// <param name="elementsCount"></param>
        /// <returns></returns>
        public static IEnumerable<T> GetRandomElements<T>(this IEnumerable<T> items, int elementsCount)
        {
            return items.OrderBy(x => Guid.NewGuid()).Take(elementsCount).ToList();
        }
    }
}