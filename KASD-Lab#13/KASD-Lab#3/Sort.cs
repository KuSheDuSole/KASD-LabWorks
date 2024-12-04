using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortingLib
{
    public  class Sorting<T> where T: IComparable<T>
    {
            public static void Swap(ref T[] array, int i, int j)
            {
                T temp = array[i];
                array[i] = array[j];
                array[j] = temp;
            }
            public static void Swap(ref T a, ref T b)
            {
                T tmp = a;
                a = b;
                b = tmp;
            }
            public static T[] DoBubbleSort(T[] array)
            {
                for (int i = 0; i < array.Length; i++)
                    for (int j = i + 1; j < array.Length; j++)
                    {
                        if (array[i].CompareTo(array[j]) == 1) Swap(ref array, i, j);

                    }
                return array;
            }
            public static T[] DoInsertionSort(T[] array)
            {
                T k;
                int j;
                for (int i = 1; i < array.Length; i++)
                {
                    k = array[i];
                    j = i - 1;
                    while (j >= 0 && array[j].CompareTo(k) == 1)
                    {
                        array[j + 1] = array[j];
                        array[j] = k;
                        j--;
                    }
                }
                return array;
            }
            public static T[] DoShakerSort(T[] array)
            {
                int left = 0, right = array.Length - 1;

                while (left < right)
                {
                    for (int i = left; i < right; i++)
                    {
                        if (array[i].CompareTo(array[i + 1]) == 1)
                            Swap(ref array, i, i + 1);
                    }
                    right--;

                    for (int i = right; i > left; i--)
                    {
                        if (array[i - 1].CompareTo(array[i]) == 1)
                            Swap(ref array, i - 1, i);
                    }
                    left++;
                }
                return array;   
            }
            public static T[] DoCombSort(T[] array)
            {
                double gap = array.Length;
                bool swaps = true;
                while (gap > 1 || swaps)
                {
                    gap /= 1.247330950103979;
                    if (gap < 1) { gap = 1; }
                    int i = 0;
                    swaps = false;
                    while (i + gap < array.Length)
                    {
                        int igap = i + (int)gap;
                        if (array[i].CompareTo(array[igap]) == 1)
                        {
                            T swap = array[i];
                            array[i] = array[igap];
                            array[igap] = swap;
                            swaps = true;
                        }
                        i++;
                    }
                }
                return array;
            }
            public static T[] DoShellSort( T[] array)
            {
                int step = array.Length / 2;
                while (step > 0)
                {
                    int i, j;
                    for (i = step; i < array.Length; i++)
                    {
                        T value = array[i];
                        for (j = i - step; (j >= 0) && (array[j].CompareTo(value) == 1); j -= step)
                            array[j + step] = array[j];
                        array[j + step] = value;
                    }
                    step /= 2;
                }
                return array;
            }
            public static T[] DoGnomeSort(T[] array)
            {
                int i = 0;
                int r = array.Length - 1;
                while (i <= r)
                {
                    if (i == 0 || array[i - 1].CompareTo(array[i]) == 0 || array[i - 1].CompareTo(array[i]) == -1) i++;
                    else
                    {
                        Swap(ref array, i - 1, i);
                        i--;
                    }
                }
                return array;
            }
            public static T[] DoSelectionSort(T[] array)
            {
                for (int i = 0; i < array.Length - 1; i++)
                {
                    int min = i;
                    for (int j = i + 1; j < array.Length; j++) if (array[j].CompareTo(array[min]) == -1) min = j;
                    Swap(ref array, min, i);
                }
                return array;
            }
            public class DoPyramidSorting
            {
                static int add2pyramid(T[] array, int i, int N)
                {
                    int imax;
                    if ((2 * i + 2) < N)
                    {
                        if (array[2 * i + 1].CompareTo(array[2 * i + 2]) == -1) imax = 2 * i + 2;
                        else imax = 2 * i + 1;
                    }
                    else imax = 2 * i + 1;
                    if (imax >= N) return i;
                    if (array[i].CompareTo(array[imax]) == -1)
                    {
                        Swap(ref array, i, imax);
                        if (imax < N / 2) i = imax;
                    }
                    return i;
                }
                public static T[] Sort(T[] array)
                {
                    int len = array.Length;
                    for (int i = len / 2 - 1; i >= 0; --i) //step 1: building the pyramid
                    {
                        long prev_i = i;
                        i = add2pyramid(array, i, len);
                        if (prev_i != i) ++i;
                    }
                    for (int k = len - 1; k > 0; --k) //step 2: sorting
                    {
                        Swap(ref array, 0, k);
                        int i = 0, prev_i = -1;
                        while (i != prev_i)
                        {
                            prev_i = i;
                            i = add2pyramid(array, i, k);
                        }
                    }
                    return array;
                }
            }
            public class DoQuickSort
            {
                public static void quickSort(T[] array, int firstIndex = 0, int lastIndex = -1)
                {
                    if (lastIndex < 0)
                        lastIndex = array.Length - 1;
                    if (firstIndex >= lastIndex)
                        return;
                    int middleIndex = (lastIndex - firstIndex) / 2 + firstIndex, currentIndex = firstIndex;
                    Swap( ref array[firstIndex],  ref array[middleIndex]);
                    for (int i = firstIndex + 1; i <= lastIndex; ++i)
                    {
                        if (array[i].CompareTo(array[firstIndex]) == 0 || array[i].CompareTo(array[firstIndex]) == -1)
                        {
                            Swap(ref array[++currentIndex],  ref array[i]);
                        }
                    }
                    Swap(ref array[firstIndex],ref  array[currentIndex]);
                    quickSort( array, firstIndex, currentIndex - 1);
                    quickSort( array, currentIndex + 1, lastIndex);
                }
                public static T[] Sort(T[] array)
                {
                    quickSort(array);
                    return array;
                }
                
            }
            public class DoMergeSort
            {
                static void Merge(T[] array, int lowIndex, int middleIndex, int highIndex)//метод для слияния массивов
                {
                    var left = lowIndex;
                    var right = middleIndex + 1;
                    var tempArray = new T[highIndex - lowIndex + 1];
                    var index = 0;
                    while ((left <= middleIndex) && (right <= highIndex))
                    {
                        if (array[left].CompareTo(array[right]) == -1)
                        {
                            tempArray[index] = array[left];
                            left++;
                        }
                        else
                        {
                            tempArray[index] = array[right];
                            right++;
                        }
                        index++;
                    }
                    for (var i = left; i <= middleIndex; i++)
                    {
                        tempArray[index] = array[i];
                        index++;
                    }
                    for (var i = right; i <= highIndex; i++)
                    {
                        tempArray[index] = array[i];
                        index++;
                    }
                    for (var i = 0; i < tempArray.Length; i++)
                    {
                        array[lowIndex + i] = tempArray[i];
                    }
                }
                static void Sort(T[] array, int lowIndex, int highIndex) //сортировка слиянием
                {
                    if (lowIndex < highIndex)
                    {
                        var middleIndex = (lowIndex + highIndex) / 2;
                        Sort(array, lowIndex, middleIndex);
                        Sort(array, middleIndex + 1, highIndex);
                        Merge(array, lowIndex, middleIndex, highIndex);
                    }
                }
                public static T[] Sort(T[] array)
                {
                    Sort(array, 0, array.Length - 1);
                    return array;
                }
            }
            //public static T[] DoCountingSort(T[] array)
            //{
            //    var min = array[0];
            //    var max = array[0];
            //    foreach (T element in array)
            //    {
            //        if (element.CompareTo(max) == 1)
            //        {
            //            max = element;
            //        }
            //        else if (element.CompareTo(min) == -1)
            //        {
            //            min = element;
            //        }
            //    }
            //    var correctionFactor = min != 0 ? -min : 0;
            //    max += correctionFactor;
            //    var count = new T[max + 1];
            //    for (var i = 0; i < array.Length; i++)
            //    {
            //        count[array[i] + correctionFactor]++;
            //    }
            //    var index = 0;
            //    for (var i = 0; i < count.Length; i++)
            //    {
            //        for (var j = 0; j < count[i]; j++)
            //        {
            //            array[index] = i - correctionFactor;
            //            index++;
            //        }
            //    }
            //    return array;
            //}
            //public class DoRadixSort
            //{
            //    static int MaxItem(T[] array)
            //    {
            //        T max = 0;
            //        int loop = 0;

            //        max = array[0];
            //        for (loop = 1; loop < array.Length; loop++)
            //        {
            //            if (array[loop] > max)
            //                max = array[loop];
            //        }
            //        return max;
            //    }
            //    static void CountSort(int[] array, int exp)
            //    {
            //        int loop = 0;
            //        int length = array.Length;
            //        int[] output = new int[length];
            //        int[] count = new int[10];
            //        for (loop = 0; loop < length; loop++) count[(array[loop] / exp) % 10]++;
            //        for (loop = 1; loop < 10; loop++) count[loop] += count[loop - 1];
            //        for (loop = length - 1; loop >= 0; loop--)
            //        {
            //            output[count[(array[loop] / exp) % 10] - 1] = array[loop];
            //            count[(array[loop] / exp) % 10]--;
            //        }
            //        for (loop = 0; loop < length; loop++) array[loop] = output[loop];
            //    }
            //    public static int[] Sort(int[] array)
            //    {
            //        int exp = 1;
            //        int max = MaxItem(array);
            //        int cond = 0;
            //        while (true)
            //        {
            //            cond = max / exp;
            //            if (cond <= 0) break;
            //            CountSort(array, exp);
            //            exp = exp * 10;
            //        }
            //        return array;
            //    }
            //}
            public class DoBitonikSort
            {
                public static T[] Sort(T[] array)
                {
                    BitonicSequenceCreate(array, 0, array.Length, false);
                    return array;
                }
                static void BitonicSequenceSort(T[] array, int low, int count, bool upward)
                {
                    if (count > 1)
                    {
                        int k = count / 2;
                        for (int i = low; i < low + k; i++)
                        {
                            if (upward ? array[i].CompareTo(array[i + k]) == 1 : array[i].CompareTo(array[i + k]) == -1)
                            {
                                T temp = array[i];
                                array[i] = array[i + k];
                                array[i + k] = temp;
                            }
                            T tmp = array[i];
                            array[i] = array[i + k];
                            array[i + k] = tmp;
                        }
                        BitonicSequenceSort(array, low, k, upward);
                        BitonicSequenceSort(array, low + k, k, upward);
                    }
                }
                static void BitonicSequenceCreate(T[] array, int low, int count, bool upward)
                {
                    if (count > 1)
                    {
                        int k = count / 2;
                        BitonicSequenceCreate(array, low, k, true);
                        BitonicSequenceCreate(array, low + k, k, false);
                        BitonicSequenceSort(array, low, count, upward);
                    }
                }
            }
            public class TreeNode
            {
                public TreeNode(T data)
                {
                    Data = data;
                }
                public T Data { get; set; }
                public TreeNode Left { get; set; }
                public TreeNode Right { get; set; }
                public void Insert(TreeNode node)
                {
                    if (node.Data.CompareTo(Data) == -1)
                    {
                        if (Left == null) Left = node;
                        else Left.Insert(node);
                    }
                    else
                    {
                        if (Right == null) Right = node;
                        else Right.Insert(node);
                    }
                }
                public T[] Transform(List<T> elements = null)
                {
                    if (elements == null) elements = new List<T>();
                    if (Left != null) Left.Transform(elements);
                    elements.Add(Data);

                    if (Right != null) Right.Transform(elements);
                    return elements.ToArray();
                }
                public static T[] Sort(T[] array)
                {
                    TreeNode root = new TreeNode(array[0]);
                    for (int i = 1; i < array.Length; i++) root.Insert(new TreeNode(array[i]));
                    T[] newArray = root.Transform();
                    for (int i = 0; i < array.Length; i++) array[i] = newArray[i];
                    return array;
                }
            }
            
        }
    }
