int[,] CreateField(int vertical, int horizontal)
{
    int[,] field = new int[vertical, horizontal];

    for (int i = 2; i < 4; i++)
        for (int j = 0; j < horizontal; j++)
            field[i, j] = 1;

    for (int i = 4; i < vertical - 8; i++)
    {
        for (int j = 0; j < 8; j++)
            field[i, j] = 1;

        for (int j = horizontal - 8; j < horizontal; j++)
            field[i, j] = 1;
    }

    for (int i = vertical - 8; i < vertical; i++)
        for (int j = 0; j < horizontal; j++)
            field[i, j] = 1;

    return field;
}

// Отрисовка поля
void PrintField(int[,] field, int vertical, int horizontal)
{
    for (int i = 0; i < vertical - 6; i++)
    {
        for (int j = 6; j < horizontal - 6; j++)
        {
            Console.SetCursorPosition(20+j, i);
            if (field[i, j] == 1)
                Console.Write('*');
        }
        Console.WriteLine();
    }
}



// Параметры поля
const int vertical = 42;
const int horizontal = 46;

// Инициализация поля
int[,] field = CreateField(vertical, horizontal);
Console.Clear();
PrintField(field, vertical, horizontal);



// int[,] arr = new int[2, 3];

// for (int i = 0; i < 2; i++)
//     for (int j = 0; j < 3; j++)
//         arr[i, j] = 1;

// Console.Clear();

// for (int i = 0; i < 2; i++)
// {
//     for (int j = 0; j < 3; j++)
//     {
//         Console.SetCursorPosition(5+j, i);
//         if (arr[i, j] == 1)
//             Console.Write('*');
//     }
//     Console.WriteLine();
// }