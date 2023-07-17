using System;
using System.Collections.Generic;
using System.Text;

namespace SortAlgorithm
{
    class ArrayUtils
    {
        public static void Swap(int[] array, int i, int j)
        {
            var n = array[i];
            array[i] = array[j];
            array[j] = n;
        }
    }
}
