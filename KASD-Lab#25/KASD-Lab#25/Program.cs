using MyHashSetLib;
class Program
{
    class MyStringComparer: IComparer<string>
    {
        public int Compare(string? x, string? y)
        {
            if (x == null && y == null) return 0;
            if (x == null) return -1;
            if (y == null) return 1;
            return x.Length.CompareTo(y.Length);
        }
    }
    public static void Main(string[] args)
    {
        MyHashSet<string> text = new MyHashSet<string>();
        StreamReader input = new StreamReader("input.txt");
        string? line = input.ReadLine();
        while (line != null)
        {
            string[] words = line.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            foreach (string word in words) text.Add(word);
            line = input.ReadLine();
        }
        string[] outWords = text.ToArray();
        Array.Sort(outWords, new MyStringComparer());
        foreach (string word in outWords) Console.WriteLine(word);
    }
}