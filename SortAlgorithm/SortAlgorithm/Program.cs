using System;
using System.Collections.Generic;
using System.Text;

namespace SortAlgorithm
{
    class Program
    {
        static void Main(string[] args)
        {
            //int[] array = {32, 1, 3, 4, 9, 10, 5, 4, 7, 9, 0, 99};
            int[] array = {9, 8, 7, 6, 5, 4, 3, 2, 1};
            PrintArray(array);
            InsertionSort.Sort(array, 0, array.Length);
            Console.Write("排序后：\n");
            PrintArray(array);
            Console.ReadLine();
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
    }
}
