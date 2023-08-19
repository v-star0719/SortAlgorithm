using System;
using System.Collections.Generic;
using System.Text;

namespace SortAlgorithm
{
    public class BucketSort
    {
        static readonly List<List<int>> buckets = new List<List<int>>();
        public static void Sort(int[] array, double max)
        {
            var count = array.Length;
            foreach (var bucket in buckets)
            {
                bucket.Clear();
            }
            for (int i = buckets.Count; i < count; i++)
            {
                buckets.Add(new List<int>());
            }

            for (int i = 0; i < count; i++)
            {
                var index = (int)(array[i] / max * count);
                buckets[index].Add(array[i]);
            }

            for (int i = 0; i < count; i++)
            {
                InsertionSort.Sort(buckets[i]);
            }

            int k = 0;
            for (int i = 0; i < count; i++)
            {
                foreach (var n in buckets[i])
                {
                    array[k++] = n;
                }
            }
        }
    }
}
