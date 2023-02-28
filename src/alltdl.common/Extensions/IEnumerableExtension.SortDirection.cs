/***
   Copyright (C) 2021. LewisFam. All Rights Reserved.
   Version: 1.1.1
***/

namespace alltdl.Extensions
{
    public static partial class IEnumerableExtension
    {
        public enum SortDirection
        {
            Ascending,

            Descending
        }

        /// <summary>Orders the by.</summary>
        /// <param name="enumerable">   The enumerable.</param>
        /// <param name="property">     The property.</param>
        /// <param name="sortDirection">The sort direction.</param>
        /// <returns>A list of TS.</returns>
        public static IEnumerable<T> OrderBy<T>(this IEnumerable<T> enumerable, string property, SortDirection sortDirection = SortDirection.Ascending)
        {
            return sortDirection == SortDirection.Ascending ? enumerable.OrderBy(x => GetProperty(x, property)) : enumerable.OrderByDescending(x => GetProperty(x, property));
        }

        /// <summary>Gets the property.</summary>
        /// <param name="o">           The object.</param>
        /// <param name="propertyName">The property name.</param>
        /// <returns>An object property.</returns>
        private static object GetProperty(object o, string propertyName)
        {
            return o.GetType().GetProperty(propertyName)?.GetValue(o, null);
        }
    }
}