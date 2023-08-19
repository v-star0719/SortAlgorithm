using System;
using System.Collections.Generic;
using System.Text;

namespace SortAlgorithm
{
    public static class RadixSort
    {
        public static void Sort(int[] array, int radix, int digits)
        {
            var count = array.Length;
            int[] orgArray = array;
            int[] sameDigitsCount = new int[radix];
            int[] tempArray = new int[count];
            int r = 1;
            for (int i = 1; i <= digits; i++)
            {
                //相同数字数量统计
                for (int j = 0; j < count; j++)
                {
                    sameDigitsCount[(array[j] / r) % radix]++;
                }

                //相同数字中最后一个在列表中的位置。从1开始的
                for (int j = 1; j < sameDigitsCount.Length; j++)
                {
                    sameDigitsCount[j] += sameDigitsCount[j - 1];
                }

                //将结果放到tempArray中
                for (int j = count - 1; j >= 0; j--)
                {
                    var d = (array[j] / r) % radix;
                    var index = sameDigitsCount[d];
                    sameDigitsCount[d] = index - 1;
                    tempArray[index - 1] = array[j];
                }

                //清空，下次使用
                for (int j = 1; j < sameDigitsCount.Length; j++)
                {
                    sameDigitsCount[j] = 0;
                }

                r *= radix;

                //两个数组来回用
                var t = array;
                array = tempArray;
                tempArray = t;
            }

            if (array != orgArray)
            {
                for (int i = 0; i < count; i++)
                {
                    orgArray[i] = array[i];
                }
            }
        }
    }
}
