﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SortingLib;
using GenerateArraysLib;
using System.IO;
using System.Reflection;
using ZedGraph;
using System.Diagnostics;

namespace KASD_Lab_3
{
    public partial class Form1 : Form
    {
        public void SetPath()
        {
            string appDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            pathArray = appDirectory + @"\ArraySave.txt";
            pathTime = appDirectory + @"\TimeSave.txt";
        }
        string pathArray;
        string pathTime;
        int flag = 0;
        public Form1()
        {
            InitializeComponent();
            GraphPane pane = zedGraph.GraphPane;
            pane.CurveList.Clear();
            pane.XAxis.Title.Text = "Размер массива (шт)";
            pane.YAxis.Title.Text = "Время выполнения (мс)";
            pane.Title.Text = "Зависимости времени выполнения от размера массива";
        }
        public void TimeOfSorting(Func<int, int[]> Generate, int lenth, params Func<int[], int[]>[] SortMethods)
        {
            SetPath();
            double[] sumSpeed = new double[SortMethods.Length];
            for (int i = 0; i < 20; i++)
            {
                int[] myArray = Generate(lenth);
                try
                {
                    StreamWriter sw = File.AppendText(pathArray);
                    sw.WriteLine("Unsorted array: ");
                    foreach (int item in myArray) sw.Write(item.ToString() + " ");

                    int index = 0;
                    int[] sortedArray = null;
                    foreach (Func<int[], int[]> Method in SortMethods)
                    {
                        Stopwatch timer = new Stopwatch();
                        timer.Start();
                        sortedArray = Method(myArray);
                        timer.Stop();
                        sumSpeed[index] += timer.ElapsedMilliseconds;
                        index++;
                    }
                    sw.WriteLine("Sorted array: ");
                    foreach (int member in sortedArray) sw.Write(member.ToString() + " ");
                    sw.Write("\n");
                    sw.Close();
                }
                catch
                {
                    textBox1.Text = "Error, please try again";
                }
            }
            try
            {
                StreamWriter sw = File.AppendText(pathTime);
                sw.Write(((double)(sumSpeed[0] / 20)).ToString());
                for (int i = 1; i < SortMethods.Length; i++) sw.Write(" " + ((double)(sumSpeed[i] / 20)).ToString());
                sw.WriteLine();
                sw.Close();
            }
            catch
            {
                textBox1.Text = "Error, please try again";
            }
        }
        int arrayIndex = -1;
        int algorithmIndex = -1;
        private void button1_Click(object sender, EventArgs e)
        {
            pictureBox1.BackColor = Color.Red;
            zedGraph.GraphPane.CurveList.Clear(); // Очистить кривые
            zedGraph.GraphPane.GraphObjList.Clear(); // Очистить объекты графика (если есть)
            zedGraph.AxisChange(); // Обновить оси
            zedGraph.Invalidate();
            SetPath();
            File.WriteAllText(pathTime, string.Empty);
            File.WriteAllText(pathArray, string.Empty);
            switch (arrayIndex)
            {
                case -1:
                    textBox1.Text = "Выберите группы тестовых данных";
                    break;
                case 0:
                    switch (algorithmIndex)
                    {
                        case -1:
                            textBox1.Text = "Выберите алгоритмы сортировок";
                            break;
                        case 0:
                            for (int lenth = 10; lenth <= Math.Pow(10, 4); lenth *= 10)
                                TimeOfSorting(GenerateArrays.GenerateGroup1, lenth, Sorting<int>.DoBubbleSort, Sorting<int>.DoInsertionSort, Sorting<int>.DoSelectionSort, Sorting<int>.DoShakerSort, Sorting<int>.DoGnomeSort);
                            flag = 1;
                            break;
                        case 1:
                            for (int lenth = 10; lenth <= Math.Pow(10, 5); lenth *= 10)
                                TimeOfSorting(GenerateArrays.GenerateGroup1, lenth, Sorting<int>.DoBitonikSort.Sort, Sorting<int>.DoShellSort);//, Sorting.TreeNode.Sort);
                            flag = 2;
                            break;
                        case 2:
                            for (int lenth = 10; lenth <= Math.Pow(10, 6); lenth *= 10)
                                TimeOfSorting(GenerateArrays.GenerateGroup1, lenth, Sorting<int>.DoCombSort,/*, Sorting.DoPyramidSorting.Sort, *//*Sorting.DoQuickSort.Sort, */Sorting<int>.DoMergeSort.Sort);
                            flag = 3;
                            break;
                    }
                    break;
                case 1:
                    switch (algorithmIndex)
                    {
                        case -1:
                            textBox1.Text = "Выберите алгоритмы сортировок";
                            break;
                        case 0:
                            for (int lenth = 10; lenth <= Math.Pow(10, 4); lenth *= 10)
                                TimeOfSorting(GenerateArrays.GenerateGroup2, lenth, Sorting<int>.DoBubbleSort, Sorting<int>.DoInsertionSort, Sorting<int>.DoSelectionSort, Sorting<int>.DoShakerSort, Sorting<int>.DoGnomeSort);
                            flag = 1;
                            break;
                        case 1:
                            for (int lenth = 10; lenth <= Math.Pow(10, 5); lenth *= 10)
                                TimeOfSorting(GenerateArrays.GenerateGroup2, lenth, Sorting<int>.DoBitonikSort.Sort, Sorting<int>.DoShellSort/*, Sorting.TreeNode.Sort*/);
                            flag = 2;
                            break;
                        case 2:
                            for (int lenth = 10; lenth <= Math.Pow(10, 6); lenth *= 10)
                                TimeOfSorting(GenerateArrays.GenerateGroup2, lenth, Sorting<int>.DoCombSort,/* Sorting.DoPyramidSorting.Sort, Sorting.DoQuickSort.Sort, */Sorting<int>.DoMergeSort.Sort);
                            flag = 3;
                            break;
                    }
                    break;
                case 2:
                    switch (algorithmIndex)
                    {
                        case -1:
                            textBox1.Text = "Выберите алгоритмы сортировок";
                            break;
                        case 0:
                            for (int lenth = 10; lenth <= Math.Pow(10, 4); lenth *= 10)
                                TimeOfSorting(GenerateArrays.GenerateGroup3, lenth, Sorting<int>.DoBubbleSort, Sorting<int>.DoInsertionSort, Sorting<int>.DoSelectionSort, Sorting<int>.DoShakerSort, Sorting<int>.DoGnomeSort);
                            flag = 1;
                            break;
                        case 1:
                            for (int lenth = 10; lenth <= Math.Pow(10, 5); lenth *= 10)
                                TimeOfSorting(GenerateArrays.GenerateGroup3, lenth, Sorting<int>.DoBitonikSort.Sort, Sorting<int>.DoShellSort/*, Sorting.TreeNode.Sort*/);
                            flag = 2;
                            break;
                        case 2:
                            for (int lenth = 10; lenth <= Math.Pow(10, 6); lenth *= 10)
                                TimeOfSorting(GenerateArrays.GenerateGroup3, lenth, Sorting<int>.DoCombSort,/* Sorting.DoPyramidSorting.Sort, Sorting.DoQuickSort.Sort, */Sorting<int>.DoMergeSort.Sort);
                            flag = 3;
                            break;
                    }
                    break;
                case 3:
                    switch (algorithmIndex)
                    {
                        case -1:
                            textBox1.Text = "Выберите алгоритмы сортировок";
                            break;
                        case 0:
                            for (int lenth = 10; lenth <= Math.Pow(10, 4); lenth *= 10)
                                TimeOfSorting(GenerateArrays.GenerateGroup4, lenth, Sorting<int>.DoBubbleSort, Sorting<int>.DoInsertionSort, Sorting<int>.DoSelectionSort, Sorting<int>.DoShakerSort, Sorting<int>.DoGnomeSort);
                            flag = 1;
                            break;
                        case 1:
                            for (int lenth = 10; lenth <= Math.Pow(10, 5); lenth *= 10)
                                TimeOfSorting(GenerateArrays.GenerateGroup4, lenth, Sorting<int>.DoBitonikSort.Sort, Sorting<int>.DoShellSort/*, Sorting.TreeNode.Sort*/);
                            flag = 2;
                            break;
                        case 2:
                            for (int lenth = 10; lenth <= Math.Pow(10, 6); lenth *= 10)
                                TimeOfSorting(GenerateArrays.GenerateGroup4, lenth, Sorting<int>.DoCombSort,/* Sorting.DoPyramidSorting.Sort, Sorting.DoQuickSort.Sort, */Sorting<int>.DoMergeSort.Sort);
                            flag = 3;
                            break;
                    }
                    break;
            }
            pictureBox1.BackColor = Color.Green;
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            arrayIndex = comboBox1.SelectedIndex;
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            algorithmIndex = comboBox2.SelectedIndex;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SetPath();
            List<List<double>> time = new List<List<double>>();
            try
            {
                StreamReader sr = new StreamReader(pathTime);
                string line = sr.ReadLine();

                while (line != null)
                {
                    List<double> speed = new List<double>();
                    string[] lineArray = line.Split(' ');
                    foreach (string str in lineArray) speed.Add(Convert.ToDouble(str));
                    time.Add(speed);
                    line = sr.ReadLine();
                }
                sr.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            GraphPane pane = zedGraph.GraphPane;
            pane.CurveList.Clear();
            pane.XAxis.Title.Text = "Размер массива (шт)";
            pane.YAxis.Title.Text = "Время выполнения (мс)";
            pane.Title.Text = "Зависимости времени выполнения от размера массива";
            for (int i = 0; i < time[0].Count(); i++)
            {
                PointPairList pointList = new PointPairList();
                int x = 10;

                for (int j = 0; j < time.Count(); j++)
                {

                    pointList.Add(x, time[j][i]);
                    x *= 10;
                }
                switch (i)
                {
                    case 0:
                        if (flag == 1) {
                            pane.XAxis.Scale.Max = 10000;
                            pane.AddCurve("BubbleSort: " + i, pointList, Color.Black, SymbolType.Default);
                        }
                        if (flag == 2)
                        {
                            pane.XAxis.Scale.Max = 100000;
                            pane.AddCurve("BitonikSort: " + i, pointList, Color.Black, SymbolType.Default);
                        }
                        if (flag == 3)
                        {
                            pane.XAxis.Scale.Max = 1000000;
                            pane.AddCurve("CombSort: " + i, pointList, Color.Black, SymbolType.Default);
                        }
                        break;
                    case 1:
                        if (flag == 1) pane.AddCurve("InsertionSort: " + i, pointList, Color.Green, SymbolType.Default);
                        if (flag == 2) pane.AddCurve("ShellSort: " + i, pointList, Color.Green, SymbolType.Default);
                        if (flag == 3) pane.AddCurve("MergeSort: " + i, pointList, Color.Green, SymbolType.Default);
                        break;
                    case 2:
                        if (flag == 1) pane.AddCurve("SelectionSort: " + i, pointList, Color.Blue, SymbolType.Default);
                        if (flag == 2) pane.AddCurve("TreeSort: " + i, pointList, Color.Blue, SymbolType.Default);
                        if (flag == 3) pane.AddCurve("CountingSort: " + i, pointList, Color.Blue, SymbolType.Default);
                        break;
                    case 3:
                        if (flag == 1) pane.AddCurve("ShakerSort: " + i, pointList, Color.Pink, SymbolType.Default);
                        if (flag == 3) pane.AddCurve("RadixSort: " + i, pointList, Color.Pink, SymbolType.Default);
                        break;
                    case 4:
                        if (flag == 1) pane.AddCurve("GnomeSort: " + i, pointList, Color.Purple, SymbolType.Default);
                        //if (flag == 3) pane.AddCurve("CountingSort: " + i, pointList, Color.Purple, SymbolType.Default);
                        break;
                    //case 5:
                    //    if (flag == 3) pane.AddCurve("RadixSort: " + i, pointList, Color.SandyBrown, SymbolType.Default);
                    //    break;
                }
                zedGraph.AxisChange();
                zedGraph.Invalidate();
                
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SetPath();
            File.WriteAllText(pathTime, string.Empty);
            File.WriteAllText(pathArray, string.Empty);
            pictureBox1.BackColor = Color.Red;
        }
    }
}
