using System;
using System.Collections.Generic;
using System.Text;

namespace SortAlgorithm
{
    public class InsertionSort
    {
        public static void Sort(int[] array)
        {
            var count = array.Length;
            for (int i = 1; i < count; i++)
            {
                //A1 A2 A3 A4 A5 A6 A7
                //一边找位置，一边把元素往后挪
                //从后往前，如果A7比Ai小，Ai往后挪；否则停止，说明应该插入到Ai后面
                var n = array[i];
                int j = i - 1;
                while (j >= 0 && n < array[j])
                {
                    array[j + 1] = array[j];
                    j--;
                }
                array[j + 1] = n;
            }
        }

        public static void Sort(List<int> array)
        {
            var count = array.Count;
            for (int i = 1; i < count; i++)
            {
                //A1 A2 A3 A4 A5 A6 A7
                //一边找位置，一边把元素往后挪
                //从后往前，如果A7比Ai小，Ai往后挪；否则停止，说明应该插入到Ai后面
                var n = array[i];
                int j = i - 1;
                while (j >= 0 && n < array[j])
                {
                    array[j + 1] = array[j];
                    j--;
                }
                array[j + 1] = n;
            }
        }
    }
}
