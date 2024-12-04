using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SortingLib;
namespace GenerateArraysLib
{
    public static class GenerateArrays
    {
        public static Random random = new Random();
        public static int[] GenerateGroup1(int lenth)
        {
            int[] array = new int[lenth];
            for (int i = 0; i < lenth; i++) array[i] = random.Next(1000);
            return array;
        }
        public static int[] GenerateGroup2(int lenth) {
            int[] finalArray = new int[lenth];
            int curIndex = 0;
            int modulSubArray = (int)Math.Pow(10, random.Next(1, (int)Math.Log(lenth, 10)) + 1);
            while (lenth > 0)
            {
                int curSubLenth = random.Next(1, modulSubArray);
                if (lenth - curSubLenth < 0) curSubLenth = lenth;
                int[] subArray = new int[curSubLenth];
                subArray = GenerateGroup1(curSubLenth);
                Sorting<int>.DoQuickSort.Sort(subArray);

                for (int i = 0; i < curSubLenth; i++)
                {
                    finalArray[curIndex++] = subArray[i];
                }
                lenth -= curSubLenth;
            }
            return finalArray;
        }
        public static int[] GenerateGroup3(int lenth)
        {
            int[] finalArray = new int[lenth];
            finalArray = GenerateGroup1(lenth);
            Array.Sort(finalArray);

            int k = random.Next(1, lenth / 2);
            for (int m = 0; m < k; m++)
            {
                int i = random.Next(0, lenth);
                int j = random.Next(0, lenth);
                Sorting<int>.Swap(ref finalArray, i, j);
            }
            return finalArray;
        }
        public static int[] GenerateGroup4(int lenth)
        {
            int[] finalArray = new int[lenth];
            finalArray = GenerateGroup1(lenth);
            int repeatNum = random.Next(1000);
            int repeating = ((random.Next(10,91)) * lenth)/100;
            for (int i = 0; i < repeating; i++) finalArray[i] = repeatNum;
            return finalArray;
        }
    }
}
