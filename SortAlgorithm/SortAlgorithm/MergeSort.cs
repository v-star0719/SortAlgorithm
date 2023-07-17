using System;
using System.Collections.Generic;
using System.Text;

namespace SortAlgorithm
{
    class MergeSort
    {
        public static void Sort(int[] array)
        {
            SortInner(array, 0, array.Length - 1, null);
        }

        private static void SortInner(int[] array, int start, int end, int[] tempArray)
        {
            if (tempArray == null)
            {
                tempArray = new int[array.Length + 2];
            }

            if (start >= end)
            {
                return;
            }
            var center = (start + end) >> 1;
            SortInner(array, start, center, tempArray);
            SortInner(array, center + 1, end, tempArray);
            Merge(array, start, center, end, tempArray);
        }

        //传入的tempArray认为是和源array一样大
        //如果未传入，则新建一个大小刚好的
        public static void Merge(int[] array, int p, int q, int r, int[] tempArray)
        {
            var n1 = q - p + 1;
            var n2 = r - q;
            int i = 0;
            int j = n1 + 1;
            if (tempArray == null)
            {
                tempArray = new int[n1 + n2 + 2];
            }
            //[p,q]放入tempArray前面
            for (int k = 0; k < n1; k++)
            {
                tempArray[k] = array[p + k];
            }
            tempArray[n1] = int.MaxValue;
            //[q + 1, r]放入tempArray，紧邻[p,q]
            for (int k = 0; k < n2; k++)
            {
                tempArray[j + k] = array[q + 1 + k];
            }
            tempArray[n1 + n2 + 1] = int.MaxValue;

            for (int k = p; k <= r; k++)
            {
                if (tempArray[i] <= tempArray[j])
                {
                    array[k] = tempArray[i++];
                }
                else
                {
                    array[k] = tempArray[j++];
                }
            }
        }
    }
}
