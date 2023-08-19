using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace SortAlgorithm
{
    public class Heap
    {
        //节点索引从1开始，因为0右移左移都是0，左右节点算不出来会原地不动。
        protected int[] array;//array的0号位置会跳过
        protected int size;
        public int Size => size;

        public Heap(int[] array, int size)
        {
            Reset(array, size);
        }

        public void Reset(int[] array, int size)
        {
            this.array = array;
            this.size = size;
        }
        
        public virtual void Heapify(int i)
        {
        }
        
        public void Build()
        {
            for (int i = size >> 1; i >= 1; i--)
            {
                Heapify(i);
            }
        }

        public int Pop()
        {
            ArrayUtils.Swap(array, 1, size);
            size--;
            Heapify(1);
            return array[size + 1];
        }

        public void Shrink()
        {
            ArrayUtils.Swap(array, 1, size);
            size--;
            Heapify(1);
        }
        
        public int Left(int i)
        {
            return (i << 1);
        }

        public int Right(int i)
        {
            return (i << 1) + 1;
        }

        public int Parent(int i)
        {
            return i >> 1;
        }

        public void PrintHeap()
        {
            List<int> nodes1 = new List<int>();
            List<int> nodes2 = new List<int>();
            nodes1.Add(1);
            while (nodes1.Count > 0)
            {
                foreach (var i in nodes1)
                {
                    Console.Write(array[i] + " ");
                    var l = Left(i);
                    var r = Right(i);
                    if (l <= size)
                    {
                        nodes2.Add(l);
                    }
                    if (r <= size)
                    {
                        nodes2.Add(r);
                    }
                }
                Console.WriteLine(" ");
                nodes1.Clear();
                var t = nodes2;
                nodes2 = nodes1;
                nodes1 = t;
            }
        }
    }

    public class HeapMax : Heap
    {
        public HeapMax(int[] array, int size) : base(array, size)
        {
        }

        public override void Heapify(int i)
        {
            var l = Left(i);
            var r = Right(i);
            var largest = i;
            if (l <= size && array[i] < array[l])
            {
                largest = l;
            }
            if (r <= size && array[largest] < array[r])
            {
                largest = r;
            }

            if (largest != i)
            {
                ArrayUtils.Swap(array, i, largest);
                Heapify(largest);
            }
        }
    }

    public class HeapMin: Heap
    {
        public HeapMin(int[] array, int size) : base(array, size)
        {
        }

        public override void Heapify(int i)
        {
            var l = Left(i);
            var r = Right(i);
            var smallest = i;
            if (l <= size && array[i] > array[l])
            {
                smallest = l;
            }
            if (r <= size && array[smallest] > array[r])
            {
                smallest = r;
            }

            if (smallest != i)
            {
                ArrayUtils.Swap(array, i, smallest);
                Heapify(smallest);
            }
        }
    }
}
