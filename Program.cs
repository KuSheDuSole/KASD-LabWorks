string path = @"piupiu.txt";
int[] vect;
int result = 0;
bool IsSimmetric(int[][] mat, int n)
{
    for (int i = 0; i < n; i++)
        for (int j = i + 1 ; j < n; j++) if (mat[i][j] != mat[j][i]) return false;
    return true;
}
void CalculateLenthVector(int[] vector, int[][] mat, int diment)
{
    if (IsSimmetric (mat, diment))
        {
            int[] secVect = new int[diment];
            for (int i = 0; i < diment; i++)
                for (int j = 0; j < diment; j++)
                    secVect[i] += vect[j] * mat[j][i];
            for (int i = 0; i < diment; i++)
                result += secVect[i] * vect[i];
            Console.WriteLine($"The dismetion of an {diment} - dismetnional space: {Math.Sqrt(result)}");
        }
    else Console.WriteLine("Something is wrong, check the input data");
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
    CalculateLenthVector(vect, matrix, n);
}
catch(Exception e)
{
    Console.WriteLine(e.Message);
}
