using System;
using System.Windows.Forms;
using ZedGraph;
using MyHashMapLib;
using MyTreeMapLib;
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
            MyTreeMap<int, int> tree = new MyTreeMap<int, int>();
            MyHashMap<int, int> hash = new MyHashMap<int, int>();
            Stopwatch timer = new Stopwatch();
            switch (operationIndex)
            {
                case -1:
                    return;
                case 1:
                    for (int size = 100; size <= 100000; size *= 10)
                    {
                        double sum1 = 0; double sum2 = 0;
                        for (int i = 0; i < 20; i++)
                        {
                            timer.Start();
                            for (int j = 0; j < size; j++) tree.Put(j, random.Next(0, size));
                            timer.Stop();
                            sum1 += timer.ElapsedMilliseconds;
                            timer.Restart();
                            for (int j = 0; j < size; j++) hash.Put(j, random.Next(0, size));
                            timer.Stop();
                            sum2 += timer.ElapsedMilliseconds;
                            timer.Reset();
                        }
                        list1.Add(size, sum1 / 20);
                        list2.Add(size, sum2 / 20);
                        tree.Clear();
                        hash.Clear();
                    }
                    break;
                case 0:
                    for (int size = 100; size <= 100000; size *= 10)
                    {
                        double sum1 = 0; double sum2 = 0;
                        for(int i = 0; i < 20; i++)
                        {
                            for (int j = 0; j < size; j++)tree.Put(j, random.Next(0, size));
                            for (int j = 0; j < size; j++) hash.Put(j, random.Next(0, size));
                            int finding = random.Next(0, size - 1);
                            timer.Start();
                            for (int j = 0; j < size; j++) tree.Get(finding);
                            timer.Stop();
                            sum1 += timer.ElapsedMilliseconds;
                            timer.Restart();
                            for (int j = 0; j < size; j++) hash.Get(finding);
                            timer.Stop();
                            sum2 += timer.ElapsedMilliseconds;
                            timer.Reset();
                        }
                        list1.Add(size, sum1 / 20);
                        list2.Add(size, sum2 / 20);
                        tree.Clear();
                        hash.Clear();
                    }
                    break;
                case 2:
                    for (int size = 100; size <= 1000; size *= 10)
                    {
                        double sum1 = 0; double sum2 = 0;
                        for (int i = 0; i < 20; i++)
                        {
                            for (int j = 0; j < size; j++) tree.Put(j, random.Next(0, size));
                            for (int j = 0; j < size; j++) hash.Put(j, random.Next(0, size));
                            timer.Start();
                            for (int j = 0; j < size; j++)
                            {
                                //int index = random.Next(0, size);
                                tree.Remove(j);
                            }
                            timer.Stop();
                            sum1 += timer.ElapsedMilliseconds;
                            timer.Restart();
                            for (int j = 0; j < size; j++)
                            {
                                //int index = random.Next(0, size);
                                hash.Remove(j);
                            }
                            timer.Stop();
                            sum2 += timer.ElapsedMilliseconds;
                            timer.Reset();
                        }
                        list1.Add(size, sum1 / 20);
                        list2.Add(size, sum2 / 20);
                        tree.Clear();
                        hash.Clear();
                    }
                    break;
            }
            pane.AddCurve("Дерево", list1, Color.Green, SymbolType.Default);
            pane.AddCurve("Хэш", list2, Color.Red, SymbolType.Default);
            zedGraph.AxisChange();
            zedGraph.Invalidate();
        }

        private void DrawButton_Click(object sender, EventArgs e)
        {

        }
    }
}
