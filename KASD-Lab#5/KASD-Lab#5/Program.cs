using MyArrayListLib;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;

class Program
{
    public static void CheckSimbol(ref string tag, char simbol, ref bool IsDone)
    {
        switch (simbol)
        {
            case '<':
                if (tag == "") tag += '<';
                else tag = "";
                break;
            case '/':
                if (tag == "<") tag += '/';
                else tag = "";
                break;
            case '>':
                ChecFigure(ref tag, simbol, ref IsDone);
                break;
            default:
                if (Char.IsLetter(simbol))
                {
                    if (tag != "") tag += simbol;
                    break;
                }
                if (Char.IsDigit(simbol))
                {
                    ChecFigure(ref tag, simbol, ref IsDone);
                    break;
                }
                tag = "";
                break;
        }
        
    }
    public static void ChecFigure(ref string tag, char simbol, ref bool IsDone)
    {
        if (tag == "") return;
        if (tag.Length == 1)
        {
            tag = "";
            return;
        }
        if (tag.Length == 2)
            if (tag[1] != '/')
            {
                tag += simbol;
                if (tag[tag.Length - 1] == '>') IsDone = true;
                return;
            }
            else
            {
                tag = "";
                return;
            }
        tag += simbol;
        if (tag[tag.Length - 1] == '>') IsDone = true;
    }
    public static bool IsRepeat (string tag, MyArrayList<string> signature)
    {
        string currentLetterPart = SignaturePart(tag);
        for (int i = 0; i < signature.Size(); i++) if (currentLetterPart == signature.Get(i)) return true;
        return false;

    }
    public static string SignaturePart(string word)
    {
        string LetterPart = "";
        foreach (char simbol in word)
            if (Char.IsLetter(simbol)) LetterPart += simbol;
        return LetterPart.ToLower();
    }
    static void Main(string[] args)
    {
        string pathInput = "Input.txt";
        StreamReader reader = new StreamReader(pathInput);
        string line = reader.ReadLine();
        MyArrayList<string> array = new MyArrayList<string>();
        MyArrayList<string> signature = new MyArrayList<string>();
        string tag = "";
        bool tagIsDone = false;
        while (line != null)
        {
            foreach (char simbol in line)
            {
                CheckSimbol(ref tag, simbol, ref tagIsDone);
                if (tagIsDone)
                {
                    if (!IsRepeat(tag, signature))
                    {
                        array.Add(tag);
                        signature.Add(SignaturePart(tag));
                    }
                    tag = "";
                    tagIsDone = false;
                }
            }
            line = reader.ReadLine();
        }
        array.Print();
    }
}