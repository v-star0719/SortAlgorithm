using System;
using System.Collections.Generic;
using System.Text;

namespace SortAlgorithm
{
    class SortBase
    {
        public virtual void Sort(int[] array, int start, int end)
        {
        }

        //插入后，pos位置的元素后移
        public static void Insert(int[] array, int start, int end, int v, int pos)
        {
            for (int i = end; i >= start && i >= v; i--)
            {
                
            }
        }

        public static void Swap(int[] array, int i, int j)
        {
            var n = array[i];
            array[i] = array[j];
            array[j] = n;
        }
    }
}
