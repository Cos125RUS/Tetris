// int[,] Load()
// {
//     string text = File.ReadAllText("save.txt");
//     int pos = text.IndexOf("\n");
//     string[] lines = File.ReadAllLines("save.txt");
//     int[,] arr = new int[lines.Length, pos - 1];

//     for (int i = 0; i < lines.Length; i++)
//         for (int j = 0; j < pos - 1; j++)
//             if (Convert.ToInt32(lines[i][j]) == 48) arr[i, j] = 0;
//             else arr[i, j] = 1;

//     return arr;
// }


// int[,] array = Load();

// int n = array.GetLength(0);
// int m = array.GetLength(1);

// System.Console.WriteLine(n);
// System.Console.WriteLine(m);

// for (int i = 0; i < n; i++)
// {
//     for (int j = 0; j < m; j++)
//     {
//         Console.Write(array[i, j]);
//     }
//     Console.WriteLine();
// }



// // string numbers = "1321656";
// //         int[] num = numbers.Select(x => x - '0').ToArray();


string loadPoints = File.ReadAllText("savePoints.txt");
    int points;
    int.TryParse(loadPoints, out points);
    System.Console.WriteLine(points);