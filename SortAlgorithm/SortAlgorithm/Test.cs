using System;
using System.Collections.Generic;
using System.Text;

namespace SortAlgorithm
{
    public class Test
    {
        public static void Run()
        {
            //int[] array33 = new[] { 5, 4, 2, 2, 3, 6 };
            //MergeSort.Merge(array33, 0, 0, 1, null);
            //PrintArray(array33);

            //int[] array33 = new[] { 5, 4, 1, 2, 3, 3 };
            //QuickSort.Partition(array33, 2, 3);
            //PrintArray(array33);

            //var array3 = new[] { -1, 1, 2, 3, 4, 5, 6 };
            //var array3 = new[] { -1, 6, 5, 4, 3, 2, 1 };
            //var heap = new HeapMin(array3, array3.Length - 1);
            //heap.Build();
            //heap.PrintHeap();
            //PrintArray(array3);

            int[][] arrays =
            {
                //new int[] {32, 1, 3, 4, 9, 10, 5, 4, 7, 9, 0, 99},
                //new int[] {0, 1, 2, 3, 4, 5, 6, 7, 8, 9},
                //new int[] {9, 8, 7, 6, 5, 4, 3, 2, 1, 0},
                //new int[] {3, 2, 3, 9, 7, 1, 7, 8, 0, 5},
            };
            for (int i = 0; i < arrays.Length; i++)
            {
                var array = arrays[i];
                Console.WriteLine("=============================" + i);
                Console.Write("排序前：\n");
                PrintArray(array);
                Console.Write("排序后： \n");
                BubbleSort.Sort(array);
                InsertionSort.Sort(array);
                SelectionSort.Sort(array);
                QuickSort.Sort(array);
                ShellSort.Sort(array);
                HeapSort.Sort(array);
                MergeSort.Sort(array);
                CountingSort.Sort(array);
                RadixSort.Sort(array, 10, 2);
                BucketSort.Sort(array, 100);
                PrintArray(array);
            }

            //正确性测试，以冒泡排序结果作为参考值
            const int N = 1000;//随机数数量以及范围
            const int RADIX = 10; //基数
            int digits = (int)Math.Ceiling(Math.Log(N, RADIX));//位数
            int[] numbers = new int[N];
            int[] bubbleSortResult = new int[N];
            int[] bubbleSortResultForHeap = new int[N];
            int[] otherSortResult = new int[N];
            var radom = new Random();

            Console.WriteLine($"随机数数量：{N}，随机数范围：[0, {N})，基数：{RADIX}，位数：{digits}");
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    numbers[j] = radom.Next(N);
                }
                Array.Copy(numbers, bubbleSortResult, N);
                BubbleSort.Sort(bubbleSortResult);
                Array.Copy(numbers, bubbleSortResultForHeap, N);
                bubbleSortResultForHeap[0] = 0; //堆排序会跳过0号元素。0号用最小的元素填充一下。这样结果就一致了
                BubbleSort.Sort(bubbleSortResultForHeap);

                Array.Copy(numbers, otherSortResult, N);
                InsertionSort.Sort(otherSortResult);
                CheckEqual(bubbleSortResult, otherSortResult, 0, "InsertionSort");

                Array.Copy(numbers, otherSortResult, N);
                SelectionSort.Sort(otherSortResult);
                CheckEqual(bubbleSortResult, otherSortResult, 0, "SelectionSort");

                Array.Copy(numbers, otherSortResult, N);
                QuickSort.Sort(otherSortResult);
                CheckEqual(bubbleSortResult, otherSortResult, 0, "QuickSort");

                Array.Copy(numbers, otherSortResult, N);
                ShellSort.Sort(otherSortResult);
                CheckEqual(bubbleSortResult, otherSortResult, 0, "ShellSort");

                Array.Copy(numbers, otherSortResult, N);
                HeapSort.Sort(otherSortResult);
                CheckEqual(bubbleSortResultForHeap, otherSortResult, 1, "HeapSort");

                Array.Copy(numbers, otherSortResult, N);
                MergeSort.Sort(otherSortResult);
                CheckEqual(bubbleSortResult, otherSortResult, 0, "MergeSort");

                Array.Copy(numbers, otherSortResult, N);
                CountingSort.Sort(otherSortResult);
                CheckEqual(bubbleSortResult, otherSortResult, 0, "CountingSort");

                Array.Copy(numbers, otherSortResult, N);
                RadixSort.Sort(otherSortResult, RADIX, digits);
                CheckEqual(bubbleSortResult, otherSortResult, 0, "RadixSort");

                Array.Copy(numbers, otherSortResult, N);
                BucketSort.Sort(otherSortResult, N);
                CheckEqual(bubbleSortResult, otherSortResult, 0, "BucketSort");
            }

            Console.WriteLine("测试完成");
        }

        static void PrintArray(int[] array)
        {
            Console.Write("数字数量：");
            Console.Write(array.Length);
            Console.Write("\n");
            foreach (var n in array)
            {
                Console.Write(n);
                Console.Write(" ");
            }
            Console.WriteLine("\n");
        }

        static void CheckEqual(int[] array1, int[] array2, int start, string tip)
        {
            for (int i = start; i < array1.Length; i++)
            {
                if (array1[i] != array2[i])
                {
                    Console.WriteLine("排序结果错误：" + tip);
                    return;
                }
            }
        }
    }
}
