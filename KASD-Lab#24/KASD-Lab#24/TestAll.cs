using RBTreeLib;
class Program
{
    public static void Main(string[] args)
    {
        RBTree<int> tree = new RBTree<int>();
        tree.Add(1);
        tree.Add(2);
        tree.Add(3);
        tree.Add(4);
        tree.Add(5);
        tree.Add(6);
        tree.Add(7);
        tree.Add(8);
        tree.Add(9);
        tree.Add(10);
        tree.Remove(10);
        tree.Remove(9);
        tree.Remove(8);
        tree.Remove(7);
        tree.Remove(6);
        tree.Remove(5);
        tree.Remove(4);
        tree.Remove(3);
        tree.Remove(2);
        tree.Remove(1);
        tree.Print();
    }
}