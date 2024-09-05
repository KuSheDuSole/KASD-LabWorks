string path = @"piupiu.txt";
int[] vect;
int result = 0;
bool simmetric(int[][] mat, int n)
{
    for (int i = 0; i < n; i++)
        for (int j = 0; j < n; j++) if (mat[i][j] != mat[j][i]) return false;
    return true;
}
try
{
    StreamReader sr = new StreamReader(path);
    int n = Convert.ToInt32(sr.ReadLine());
    int[][] matrix = new int[n][];
    for (int i = 0; i< n; i++)
    {
        matrix[i] = sr.ReadLine().Split(' ').Select(x => Convert.ToInt32(x)).ToArray();
    }
    vect = sr.ReadLine().Split(' ').Select(x => Convert.ToInt32(x)).ToArray();
    sr.Close();
    if (simmetric (matrix, n))
    {
        int[] secVect = new int[n];
        for (int i = 0; i < n; i++)
            for (int j = 0; j < n; j++)
                secVect[i] += vect[j] * matrix[j][i];
        for (int i = 0; i < n; i++)
            result += secVect[i] * vect[i];
        Console.WriteLine($"The dismetion of an {n} - dismetnional space: {Math.Sqrt(result)}");
    }
}
catch(Exception e)
{
    Console.WriteLine(e.Message);
}