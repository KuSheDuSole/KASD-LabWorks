using System.Text.RegularExpressions;
using MyHashSetLib;
class Program
{
    public static void Main(string[] args)
    {
        MyHashSet<string> text = new MyHashSet<string>();
        StreamReader input = new StreamReader("input.txt");
        string? line = input.ReadLine();
        string pattern = @"\b[a-zA-Z]+\b";
        while (line != null)
        {
            MatchCollection matches = Regex.Matches(line, pattern);
            foreach (Match match in matches) text.Add(match.Value.ToLower());
            line = input.ReadLine();
        }
        input.Close();
        Console.WriteLine("Уникальные слова");
        text.Print();
    }
}