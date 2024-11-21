using MyPriorityQueue;
using System.Diagnostics;

//public class RequestComparer: Comparer<Request>
//{ 
//    public override int Compare(Request? ap1, Request? ap2)
//    {
//        if (ap1 is null || ap2 is null) throw new ArgumentException("Некорректное значение параметра");
//        return ap1.priority - ap2.priority;
//    }
//}
public class Request: IComparable<Request>
{
    public int priority { get; }
    public int numOfRe { get; }
    public int numOfStep { get; }
    public Request(int priority, int numOfRe, int numOfStep)
    {
        this.priority = priority;
        this.numOfRe = numOfRe;
        this.numOfStep = numOfStep;
    }
    public int CompareTo(Request? ap1)
    {
        if (ap1 is null) throw new ArgumentException("Некорректное значение параметра");
        if (priority - ap1.priority > 0) return 1;
        if (priority - ap1.priority < 0) return -1;
        return 0;
    }
}
class Program
{
    public static void Removing(StreamWriter stream, MyPriorityQueue<Request> queue)
    {
        Request? removing = queue.Poll();
        if (removing != null) stream.WriteLine($"Remove: request - {removing.numOfRe}" +
            $"  priority - {removing.priority}  step - {removing.numOfStep}");
    }
    static void Main(string[] args)
    {
        Stopwatch stopwatcher = new Stopwatch();
        Console.WriteLine("Введите количество шагов: ");
        int n = Convert.ToInt32(Console.ReadLine());
        StreamWriter log = new StreamWriter("Log.txt");
        int globalNumberOfReq = 1;
        MyPriorityQueue<Request> queue = new MyPriorityQueue<Request>(10);
        Random rand = new Random();
        stopwatcher.Start();
        for (int i = 0; i < n; i++)
        {
            int numbOfReq = rand.Next(1, 11);
            for (int j = 0; j < numbOfReq; j++)
            {
                Request request = new Request(rand.Next(1, 6), globalNumberOfReq++, i);
                queue.Add(request);
                log.WriteLine($"ADD: request - {request.numOfRe}  priority - {request.priority}  step - {request.numOfStep}");
            }
            Removing(log, queue);
        }
        while (!queue.IsEmpty()) Removing(log, queue);
        stopwatcher.Stop();
        log.WriteLine($"Execution time: {stopwatcher.Elapsed}");
        log.Close();
        Console.WriteLine($"Execution time: {stopwatcher.Elapsed}");
    }
}