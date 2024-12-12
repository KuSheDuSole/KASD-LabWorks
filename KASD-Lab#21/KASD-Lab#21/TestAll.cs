using MyTreeMapLib;
class Program
{
    public static void Main(string[] args)
    {
        MyTreeMap<int, int> tree = new MyTreeMap<int, int>();
        tree.Put(8, 20);
        tree.Put(3, 30);
        tree.Put(10, 40);
        tree.Put(1, 50);
        tree.Put(6, 60);
        tree.Put(14, 70);
        tree.Put(4, 80);
        tree.Put(7, 90);
        tree.Put(13, 100);
        tree.Print();
        tree.Remove(8);
        tree.Print();
        MyTreeMap<int, int> tree2 = tree.TailMap(7);
    }
}