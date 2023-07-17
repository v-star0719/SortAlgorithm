using System;
using System.Collections.Generic;
using System.Text;

namespace SortAlgorithm
{
    public class HeapSort
    {
        private static readonly HeapMax heap = new HeapMax(null, 0);
        //0号元素会跳过
        public static void Sort(int[] array)
        {
            heap.Reset(array, array.Length - 1);
            heap.Build();
            while (heap.Size >= 2)
            {
                heap.Shrink();
            }
            heap.Reset(null, 0);
        }
    }
}
