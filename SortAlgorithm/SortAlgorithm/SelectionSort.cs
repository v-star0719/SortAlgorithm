using System;
using System.Collections.Generic;
using System.Text;

namespace SortAlgorithm
{
    public class SelectionSort
    {
        public static void Sort(int[] array)
        {
            var count = array.Length;
            for (int i = 1; i < count; i++)
            {
                var min = i - 1;
                for (int j = min; j < count; j++)
                {
                    if (array[min] > array[j])
                    {
                        min = j;
                    }
                }

                if (min != i - 1)
                {
                    ArrayUtils.Swap(array, min, i - 1);
                }
            }
        }
    }
}
