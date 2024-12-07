using MyLinkedLIst;
using System.Collections;
class Program
{
    static void Main(string[] args)
    {
        int[] ints = { 1, 2, 3, 4, 5, 6};
        MyLinkedList<int> list = new MyLinkedList<int>(ints);
        list.AddAll(ints.Length, [7, 6, 5, 4, 3]);
        //list.Print();
        //Console.WriteLine(list.PollLast());
        list.RemoveFirstOccurrence(3);
        list.Print();
    }
}