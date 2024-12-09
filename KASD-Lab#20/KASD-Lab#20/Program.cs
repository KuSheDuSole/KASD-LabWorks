using MyHashMapLib;
using System.Text.RegularExpressions;

class Program
{
    enum TypeEum
    {
        Integer,
        Double,
        Float
    }
    public static void Main(string[] args)
    {
        try
        {
            StreamReader input = new StreamReader("input.txt");
            MyHashMap<string, string> definitions = new MyHashMap<string, string>();
            Regex regex = new Regex(@"(double|int|float) \S* ?(?:=) ?(\S)+?(?=;)");
            string? line = input.ReadLine();
            if (line == null) Console.WriteLine("Файл пуст");
            while (line != null)
            {
                MatchCollection matches = regex.Matches(line);
                foreach (Match match in matches)
                {
                    string[] parts = match.Value.Split(' ');
                    string type = parts[0];
                    string valuable = parts[3];
                    string name = parts[1];
                    string tv = type + " " + valuable;
                    if (definitions.ContainsKey(name)) Console.WriteLine($"повтор: {type} {name} = {valuable}");
                    else definitions.Put(name, tv);
                }
                line = input.ReadLine();
            }
            Console.WriteLine();
            input.Close();
            var pair = definitions.EntrySet();
            foreach (var element in pair)
                Console.WriteLine(element.Key + " " + element.Value);
        }
        catch (Exception ex) { Console.WriteLine("Exception : " + ex.Message); }
    }
}