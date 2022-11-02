int[,] Load()
{
    string text = File.ReadAllText("save.txt");
    int pos = text.IndexOf("\n");
    string[] lines = File.ReadAllLines("save.txt");
    int[,] arr = new int[lines.Length, pos - 1];
    // int a;

    for (int i = 0; i < lines.Length; i++)
    {
        string numbers = lines[i];
        int[] num = numbers.Select(x => x - '\n').ToArray();
        // int.TryParse(lines[i], out a);
        for (int j = 0; j < pos - 1; j--)
        {
            Console.Write(num[j]);
            // arr[i,j] = num[j];
            // arr[i,j] = int.Parse(numbers[j]);
            // int.TryParse(numbers[j], out a);
            // arr[i, j] = a % 10;
            // a /= 10;
        }
        System.Console.WriteLine();
    }

    return arr;
}


int[,] array = Load();

int n = array.GetLength(0);
int m = array.GetLength(1);

System.Console.WriteLine(n);
System.Console.WriteLine(m);

for (int i = 0; i < n; i++)
{
    for (int j = 0; j < m; j++)
    {
        Console.Write(array[i, j]);
    }
    Console.WriteLine();
}



// string numbers = "1321656";
//         int[] num = numbers.Select(x => x - '0').ToArray();