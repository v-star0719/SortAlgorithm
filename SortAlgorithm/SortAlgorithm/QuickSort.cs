using System;
using System.Collections.Generic;
using System.Text;

namespace SortAlgorithm
{
    public class QuickSort
    {
        public static void Sort(int[] array)
        {
            SortInner(array, 0, array.Length - 1);
        }

        private static void SortInner(int[] array, int start, int end)
        {
            if (start < end)
            {
                var c = Partition(array, start, end);
                SortInner(array, start, c - 1);
                SortInner(array, c + 1, end);
            }
        }

        public static int Partition(int[] array, int start, int end)
        {
            var c = new Random((int)(DateTime.Now.Ticks / 1000000)).Next(start, end);
            ArrayUtils.Swap(array, c, end);

            //中间值放到最后
            var n = array[end];
            int i = start - 1;//把比n小放前面

            //循环结束后，i指向最后一个比n小的数。如果没有比n小的，指向start-1。
            for (int j = start; j < end; j++)
            {
                if (array[j] <= n)
                {
                    i++;
                    ArrayUtils.Swap(array, i, j);
                }
            }

            i++;
            ArrayUtils.Swap(array, i, end);
            return i;
        }
    }
}
