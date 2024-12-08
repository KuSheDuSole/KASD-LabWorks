using System;
using System.Windows.Forms;
using ZedGraph;
using MyLinkedList;
using MyListLib;
using System.Diagnostics;
using System.Drawing;
using System.Net.Http.Headers;

namespace KASD_Lab_17
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            GraphPane pane = zedGraph.GraphPane;
            pane.CurveList.Clear();
            pane.XAxis.Title.Text = "Размер массива (шт)";
            pane.YAxis.Title.Text = "Время выполнения (мс)";
            pane.Title.Text = "Зависимости времени выполнения от размера массива";
        }
        int operationIndex = -1;
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            operationIndex = comboBox1.SelectedIndex;
        }

        private void StartTests_Click(object sender, EventArgs e)
        {
            GraphPane pane = zedGraph.GraphPane;
            pane.CurveList.Clear();
            Random random = new Random();
            PointPairList list1 = new PointPairList();
            PointPairList list2 = new PointPairList();
            MyArrayList<int> arrayList = new MyArrayList<int>(10);
            MyLinkedList<int> linkedList = new MyLinkedList<int>();
            Stopwatch timer = new Stopwatch();
            switch (operationIndex)
            {
                case -1:
                    return;
                case 0:
                    for (int size = 100; size <= 10000; size *= 10)
                    {
                        double sum1 = 0; double sum2 = 0;
                        for (int i = 0; i < 20; i++)
                        {
                            timer.Start();
                            for (int j = 0; j < size; j++) arrayList.Add(j);
                            timer.Stop();
                            sum1 += timer.ElapsedMilliseconds;
                            timer.Restart();
                            for (int j = 0; j < size; j++) linkedList.Add(j);
                            timer.Stop();
                            sum2 += timer.ElapsedMilliseconds;
                            timer.Reset();
                        }
                        list1.Add(size, sum1 / 20);
                        list2.Add(size, sum2 / 20);
                        arrayList.Clear();
                        linkedList.Clear();
                    }
                    break;
                case 1:
                    for (int size = 100; size <= 1000; size *= 10)
                    {
                        double sum1 = 0; double sum2 = 0;
                        for(int i = 0; i < 20; i++)
                        {
                            for (int j = 0; j < size; j++)arrayList.Add(j);
                            for (int j = 0; j < size; j++) linkedList.Add(j);
                            int finding = random.Next(0, size - 1);
                            timer.Start();
                            for (int j = 0; j < size; j++) arrayList.Get(finding);
                            timer.Stop();
                            sum1 += timer.ElapsedMilliseconds;
                            timer.Restart();
                            for (int j = 0; j < size; j++) linkedList.Get(finding);
                            timer.Stop();
                            sum2 += timer.ElapsedMilliseconds;
                            timer.Reset();
                        }
                        list1.Add(size, sum1 / 20);
                        list2.Add(size, sum2 / 20);
                        arrayList.Clear();
                        linkedList.Clear();
                    }
                    break;
                case 2:
                    for (int size = 100; size <= 1000; size *= 10)
                    {
                        double sum1 = 0; double sum2 = 0;
                        for (int i = 0; i < 20; i++)
                        {
                            for (int j = 0; j < size; j++) arrayList.Add(j);
                            for (int j = 0; j < size; j++) linkedList.Add(j);
                            timer.Start();
                            for (int j = 0; j < size; j++)
                            {
                                int index = random.Next(0, arrayList.Size() - 1);
                                int number = random.Next(0, 10000);
                                arrayList.Set(index, number);
                            }
                            timer.Stop();
                            sum1 += timer.ElapsedMilliseconds;
                            timer.Restart();
                            for (int j = 0; j < size; j++)
                            {
                                int index = random.Next(0, linkedList.Size() - 1);
                                int number = random.Next(0, 10000);
                                linkedList.Set(index, number);
                            }
                            timer.Stop();
                            sum2 += timer.ElapsedMilliseconds;
                            timer.Reset();
                        }
                        list1.Add(size, sum1 / 20);
                        list2.Add(size, sum2 / 20);
                        arrayList.Clear();
                        linkedList.Clear();
                    }
                    break;
                case 3:
                    for (int size = 100; size <= 1000; size *= 10)
                    {
                        double sum1 = 0; double sum2 = 0;
                        for (int i = 0; i < 20; i++)
                        {
                            for (int j = 0; j < size; j++) arrayList.Add(j);
                            for (int j = 0; j < size; j++) linkedList.Add(j);
                            timer.Start();
                            for (int j = 0; j < size; j++)
                            {
                                int index = random.Next(0, arrayList.Size() - 1);
                                int number = random.Next(0, 10000);
                                arrayList.Add(index, number);
                            }
                            timer.Stop();
                            sum1 += timer.ElapsedMilliseconds;
                            timer.Restart();
                            for (int j = 0; j < size; j++)
                            {
                                int index = random.Next(0, linkedList.Size() - 1);
                                int number = random.Next(0, 10000);
                                linkedList.Add(index, number);
                            }
                            timer.Stop();
                            sum2 += timer.ElapsedMilliseconds;
                            timer.Reset();
                        }
                        list1.Add(size, sum1 / 20);
                        list2.Add(size, sum2 / 20);
                        arrayList.Clear();
                        linkedList.Clear();
                    }
                    break;
                case 4:
                    for (int size = 100; size <= 1000; size *= 10)
                    {
                        double sum1 = 0; double sum2 = 0;
                        for (int i = 0; i < 20; i++)
                        {
                            for (int j = 0; j < size; j++) arrayList.Add(j);
                            for (int j = 0; j < size; j++) linkedList.Add(j);
                            timer.Start();
                            for (int j = 0; j < size; j++)
                            {
                                int number = random.Next(0, arrayList.Size() + 1);
                                arrayList.Remove(number);
                            }
                            timer.Stop();
                            sum1 += timer.ElapsedMilliseconds;
                            timer.Restart();
                            for (int j = 0; j < size; j++)
                            {
                                int number = random.Next(0, linkedList.Size() + 1);
                                linkedList.Remove(number);
                            }
                            timer.Stop();
                            sum2 += timer.ElapsedMilliseconds;
                            timer.Reset();
                        }
                        list1.Add(size, sum1 / 20);
                        list2.Add(size, sum2 / 20);
                        arrayList.Clear();
                        linkedList.Clear();
                    }
                    break;
            }
            pane.AddCurve("Массив", list1, Color.Green, SymbolType.Default);
            pane.AddCurve("Список", list2, Color.Red, SymbolType.Default);
            zedGraph.AxisChange();
            zedGraph.Invalidate();
        }

        private void DrawButton_Click(object sender, EventArgs e)
        {

        }
    }
}
