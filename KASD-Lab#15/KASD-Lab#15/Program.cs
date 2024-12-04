using MyArrayDequeLib;
using System.Security.Cryptography;
class Program
{
    public static int NumbOfDigits(string line) {
        int sum = 0;
        foreach (char element in line) if (Char.IsDigit(element)) sum++;
        return sum;
    }
    public static int NumbOfSpaces(string line) => line.Split(' ').Length - 1;

    static void Main(string[] args)
    {
        StreamReader input = new StreamReader("input.txt");
        StreamWriter sorted = new StreamWriter("sorted.txt");
        MyArrayDeque<string> deque = new MyArrayDeque<string>();
        MyArrayDeque<int> digitsOfString = new MyArrayDeque<int>();
        string? line = input.ReadLine();
        if (line == null)
        {
            Console.WriteLine("Your text file turned out to be empty ");
            return;
        }
        deque.Add(line);
        digitsOfString.Add(NumbOfDigits(line));
        line = input.ReadLine();
        while (line != null)
        {
            if (digitsOfString.Peek() < NumbOfDigits(line))
            {
                deque.Add(line);
                digitsOfString.Add(NumbOfDigits(line));
            }
            else
            {
                deque.AddFirst(line);
                digitsOfString.AddFirst(NumbOfDigits(line));
            }
            line = input.ReadLine();
        }
        string[] array = deque.ToArray();
        for (int i = 0; i < array.Length; i++) sorted.WriteLine(array[i]);
        Console.WriteLine("Enter number of spaces ");
        int n = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine();
        for (int i = 0; i < deque.Size(); i++)
        {
            if (NumbOfSpaces(deque.GetByIndex(i)) > n)
            {
                deque.RemoveByIndex(i);
                i--;
            }
        }
        deque.Print();
        input.Close();
        sorted.Close();
    }
}