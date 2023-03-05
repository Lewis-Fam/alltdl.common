﻿namespace alltdl.Extensions;

public static partial class IEnumerableExtension
{
    public static IEnumerable<T> GetRandomElements<T>(this IEnumerable<T> items, int elementsCount)
    {
        return items.OrderBy(x => Guid.NewGuid()).Take(elementsCount).ToList();
    }

    public static IEnumerable<IEnumerable<T>> Batch<T>(this IEnumerable<T> items,
        int maxItems)
    {
        return items.Select((item, inx) => new { item, inx })
            .GroupBy(x => x.inx / maxItems)
            .Select(g => g.Select(x => x.item));
    }
}