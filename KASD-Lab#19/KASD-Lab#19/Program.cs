using MyHashMapLib;
using System.Text.RegularExpressions;
class Program
{
    static void Main(string[] args)
    {
        StreamReader input = new StreamReader("input.txt");
        MyHashMap<string, int> tags = new MyHashMap<string, int>();
        Regex regex = new Regex(@"</?[a-zA-Z]\w*>");
        string? line = input.ReadLine();
        if (line == null) Console.WriteLine("Строка пуста");
        while (line != null)
        {
            MatchCollection matches = regex.Matches(line);
            foreach (Match match in matches)
            {
                if (!tags.ContainsKey(match.Value.ToLower())) tags.Put(match.Value.ToLower(), 1);
                else tags.Put(match.Value.ToLower(), tags.Get(match.Value.ToLower()) + 1);
            }
            line = input.ReadLine();
        }
        input.Close();
        KeyValuePair<string, int>[] pairs = tags.EntrySet();
        for (int i = 0; i < pairs.Length; i++) Console.WriteLine($"{pairs[i].Key}: {pairs[i].Value}");

    }
}