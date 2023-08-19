using System;
using System.Collections.Generic;
using System.Text;

namespace SortAlgorithm
{
    public class CountingSort
    {
        public static void Sort(int[] array)
        {
            var count = array.Length;
            var counters = new int[count];
            var tempArray = new int[count];
            for (int i = 0; i < count; i++)
            {
                counters[array[i]]++;
            }

            for (int i = 1; i < count; i++)
            {
                counters[i] += counters[i - 1];
            }

            for (int i = 0; i < count; i++)
            {
                tempArray[counters[array[i]] - 1] = array[i];
                counters[array[i]]--;
            }

            Array.Copy(tempArray, 0, array, 0, count);
        }
    }
}
