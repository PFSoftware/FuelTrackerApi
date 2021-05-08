using System.Collections.Generic;

namespace FuelTrackerApi
{
    public static class Extensions
    {
        /// <summary>Replaces an item in a List.</summary>
        /// <typeparam name="T">Type of object being replaced</typeparam>
        /// <param name="list">List</param>
        /// <param name="original">Original item</param>
        /// <param name="replacement">Replacement item</param>
        public static void Replace<T>(this IList<T> list, T original, T replacement)
        {
            int index = list.IndexOf(original);
            if (index >= 0)
                list[index] = replacement;
        }
    }
}