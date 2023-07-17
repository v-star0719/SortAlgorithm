using System;
using System.Collections.Generic;
using System.Text;

namespace SortAlgorithm
{
    class BubbleSort
    {
        public static void Sort(int[] array)
        {
            var count = array.Length;
            for (int i = 1; i < count; i++)
            {
                for (int j = 0; j < count - i; j++)
                {
                    if (array[j] >= array[j + 1])
                    {
                        ArrayUtils.Swap(array, j, j + 1);
                    }
                }
            }
        }

        //这个优化对全随机的数据来说没什么提升。
        //bool swaped = false;
        //swaped = true;
        //if (!swaped)
        //{
        //    break;
        //}
    }
}
