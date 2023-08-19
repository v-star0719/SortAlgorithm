using System;

namespace SortAlgorithm
{
    public class ShellSort
    {
        public static void Sort(int[] array)
        {
            var count = array.Length;
            int step = count >> 1;
            while (step > 0)
            {
                for (int s = 0; s < step; s++)
                {
                    for (int i = step + s; i < count; i += step)
                    {
                        var n = array[i];
                        int j = i - step;
                        while (j >= s && n < array[j])
                        {
                            array[j + step] = array[j];
                            j -= step;
                        }
                        array[j + step] = n;
                    }
                }
                step >>= 1;
            }
        }
    }
}