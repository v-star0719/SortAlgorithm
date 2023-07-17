using System;
using System.Collections.Generic;
using System.Text;

namespace SortAlgorithm
{
    public class PerformanceTest
    {
        public static void Run()
        {
            const int N = 1000 * 1 * 10;//随机数数量以及范围
            const int RADIX = 1000; //基数
            const int T = 5;
            int digits = (int)Math.Ceiling(Math.Log(N, RADIX));//位数
            int[] numbers = new int[N];
            int[] numbersToSort = new int[N];
            var radom = new Random();
            var counter = new Counter("");
            Console.WriteLine($"随机数数量：{N}，随机数范围：[0, {N})，基数：{RADIX}，位数：{digits}");
            for (int i = 0; i < N; i++)
            {
                numbers[i] = radom.Next(N);
            }

            //基本有序
            //QuickSort.Sort(numbers);
            //const float ratio = 0.90f;//保持有序的元素数量百分比
            //int defusedCount = (int)((1 - ratio) * N);
            //Console.WriteLine("defusedCount " + defusedCount);
            //for (int i = 0; i < defusedCount; i += 2)
            //{
            //    var index = radom.Next(0, N);
            //    ArrayUtils.Swap(numbers, index, N - 1 - index);
            //}

            counter.Reset();
            for (int i = 0; i < T; i++)
            {
                Array.Copy(numbers, numbersToSort, N);
                counter.Start();
                BubbleSort.Sort(numbersToSort);
                counter.Pause();
            }
            counter.Stop("BubbleSort");

            counter.Reset();
            for (int i = 0; i < T; i++)
            {
                Array.Copy(numbers, numbersToSort, N);
                counter.Start();
                InsertionSort.Sort(numbersToSort);
                counter.Pause();
            }
            counter.Stop("InsertionSort");

            counter.Reset();
            for (int i = 0; i < T; i++)
            {
                Array.Copy(numbers, numbersToSort, N);
                counter.Start();
                SelectionSort.Sort(numbersToSort);
                counter.Pause();
            }
            counter.Stop("SelectionSort");

            counter.Reset();
            for (int i = 0; i < T; i++)
            {
                Array.Copy(numbers, numbersToSort, N);
                counter.Start();
                QuickSort.Sort(numbersToSort);
                counter.Pause();
            }
            counter.Stop("QuickSort");

            counter.Reset();
            for (int i = 0; i < T; i++)
            {
                Array.Copy(numbers, numbersToSort, N);
                counter.Start();
                ShellSort.Sort(numbersToSort);
                counter.Pause();
            }
            counter.Stop("ShellSort");

            counter.Reset();
            for (int i = 0; i < T; i++)
            {
                Array.Copy(numbers, numbersToSort, N);
                counter.Start();
                HeapSort.Sort(numbersToSort);
                counter.Pause();
            }
            counter.Stop("HeapSort");

            counter.Reset();
            for (int i = 0; i < T; i++)
            {
                Array.Copy(numbers, numbersToSort, N);
                counter.Start();
                MergeSort.Sort(numbersToSort);
                counter.Pause();
            }
            counter.Stop("MergeSort");

            counter.Reset();
            for (int i = 0; i < T; i++)
            {
                Array.Copy(numbers, numbersToSort, N);
                counter.Start();
                CountingSort.Sort(numbersToSort);
                counter.Pause();
            }
            counter.Stop("CountingSort");

            counter.Reset();
            for (int i = 0; i < T; i++)
            {
                Array.Copy(numbers, numbersToSort, N);
                counter.Start();
                RadixSort.Sort(numbersToSort, RADIX, digits);
                counter.Pause();
            }
            counter.Stop("RadixSort");

            counter.Reset();
            for (int i = 0; i < T; i++)
            {
                Array.Copy(numbers, numbersToSort, N);
                counter.Start();
                BucketSort.Sort(numbersToSort, N);
                counter.Pause();
            }
            counter.Stop("BucketSort");

            Console.WriteLine("性能测试完成");
        }
    }

    public class Counter
    {
        private long ticks;
        private long diff;
        private readonly string title;
        private int times;

        public Counter(string title)
        {
            this.title = title;
        }

        public void Start()
        {
            times++;
            ticks = DateTime.Now.Ticks;
        }

        public void Pause()
        {
            diff += (DateTime.Now.Ticks - ticks);
        }

        public void Stop(string tip)
        {
            Console.WriteLine($"{title} {tip}: {diff / 100:N0}us, average {diff/(100 * times):N0}us ");
        }

        public void Reset()
        {
            times = 0;
            diff = 0;
        }
    }

    public class CounterAuto : IDisposable
    {
        private readonly long ticks;
        private readonly string title;
        public CounterAuto(string title)
        {
            this.title = title;
            ticks = DateTime.Now.Ticks;
        }
        public void Dispose()
        {
            var diff = (DateTime.Now.Ticks - ticks) / 100000;
            Console.WriteLine($"{title} {diff} ms");
        }
    }
}
