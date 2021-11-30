using System;
using System.Collections.Generic;

namespace Holidayview.Infrastructure.Repositories
{
    public static class EachStatic
    {
        public static void Each<T>(this IEnumerable<T> enumerable, Action<T> action) { foreach (T item in enumerable) { action(item); } }
    }
}