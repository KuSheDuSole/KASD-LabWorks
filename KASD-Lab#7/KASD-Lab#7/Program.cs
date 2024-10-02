using MyVectorLib;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;

class Program
{
    public static void CheckSimbol(string part, ref string IP, ref bool isDone, ref int block_count)
    {
        int block_part = Convert.ToInt32(part);
        if (block_part > 0 && block_part < 256 && part.Length == 3) {
            IP += part + '.';
            block_count++;
        }
        else
        {
            IP = "";
            block_count = 0;
        }
        if (block_count == 4)
        {
            IP = IP.Remove(IP.Length - 1);
            block_count = 0;
            isDone = true;
        }
    }
    public static bool Repeating(string myIP, MyVector<string> array)
    {
        for (int i = 0; i < array.Size(); i++) if (myIP == array.Get(i)) return true;
        return false;
    }
    public static void PutInFile(MyVector<string> array)
    {
        StreamWriter writer = new StreamWriter("Output.txt");
        for (int i = 0; i < array.Size(); i++) writer.WriteLine(array.Get(i));
        writer.Close();
    }
    static void Main(string[] args)
    {
        string pathInput = "Input.txt";
        StreamReader reader = new StreamReader(pathInput);
        string line = reader.ReadLine();
        MyVector<string> array = new MyVector<string>();
        string nowIP = "";
        bool isDone = false;
        int block_count = 0;
        while (line != null)
        {
            string[] line_part = line.Split(" ");
            foreach (string part in line_part)
            {
                string[] IP = part.Split(".");
                foreach (string block in IP)
                {
                    CheckSimbol(block, ref nowIP, ref isDone, ref block_count);
                    if (isDone)
                    {
                        if (!Repeating(nowIP, array))
                        {
                            array.Add(nowIP);
                            nowIP = "";
                            isDone = false;
                        }
                        else
                        {
                            nowIP = "";
                            isDone = false;
                        }
                    }
                }
            }
            line = reader.ReadLine();
        }
        PutInFile(array);
        reader.Close();
        array.Print();
    }
}