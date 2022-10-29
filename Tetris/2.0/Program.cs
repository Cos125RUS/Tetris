int[,] CreateField(int vertical, int horizontal)
{
    int[,] field = new int[vertical, horizontal];

    for (int i = 2; i < vertical - 8; i++)
    {
        for (int j = 0; j < 12; j++)
            field[i, j] = 1;

        for (int j = horizontal - 12; j < horizontal; j++)
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
    Console.Clear();

    for (int i = 0; i < vertical - 6; i++)
    {
        for (int j = 9; j < horizontal - 9; j++)
        {
            Console.SetCursorPosition(20 + j, i);
            if (field[i, j] == 1)
                Console.Write('*');
        }
        Console.WriteLine();
    }
}


// Выбор фигуры
int[,] Choice(int n)
{
    int[,] shape1 = {{0,0,0,1,1,1},
                     {0,0,0,1,1,1},
                     {1,1,1,1,1,1},
                     {1,1,1,1,1,1},
                     {1,1,1,0,0,0},
                     {1,1,1,0,0,0}};

    int[,] shape2 = { { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 },
                      { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 } };

    int[,] shape3 = {{1,1,1,0,0,0},
                     {1,1,1,0,0,0},
                     {1,1,1,0,0,0},
                     {1,1,1,0,0,0},
                     {1,1,1,1,1,1},
                     {1,1,1,1,1,1}};

    int[,] shape4 = {{1,1,1,1,1,1},
                     {1,1,1,1,1,1},
                     {1,1,1,1,1,1},
                     {1,1,1,1,1,1}};

    int[,] shape5 = {{1,1,1,0,0,0},
                     {1,1,1,0,0,0},
                     {1,1,1,1,1,1},
                     {1,1,1,1,1,1},
                     {1,1,1,0,0,0},
                     {1,1,1,0,0,0}};

    int[,] shape6 = {{0,0,0,1,1,1},
                     {0,0,0,1,1,1},
                     {0,0,0,1,1,1},
                     {0,0,0,1,1,1},
                     {1,1,1,1,1,1},
                     {1,1,1,1,1,1}};

    int[,] shape7 = {{1,1,1,0,0,0},
                     {1,1,1,0,0,0},
                     {1,1,1,1,1,1},
                     {1,1,1,1,1,1},
                     {0,0,0,1,1,1},
                     {0,0,0,1,1,1}};

    switch (n)
    {
        case 1:
            return shape1;

        case 2:
            return shape2;

        case 3:
            return shape3;

        case 4:
            return shape4;

        case 5:
            return shape5;

        case 6:
            return shape6;

        default:
            return shape7;
    }
}


// Создание следующей фигуры
(int[,], int, int) NewFigure()
{
    int[,] shape = Choice(Random.Shared.Next(1, 8));
    int row = shape.GetLength(0);
    int column = shape.GetLength(1);

    return (shape, row, column);
}


// Движение фигуры
void Figure(int x, int y, int[,] mapping, int row, int column)
{
    for (int i = 0; i < row; i++)
        for (int j = 0; j < column; j++)
        {
            Console.SetCursorPosition(20 + j + x, i + y);
            if (mapping[i, j] == 1) Console.Write('*');
        }
}


// Поворот фигуры
(int[,], int, int) Twist(int[,] arr, int n, int m)
{
    int[,] revers = new int[m / 3 * 2, n / 2 * 3];

    // for (int k = 0; k < n / 2; k++)
    //     for (int l = 0; l < m / 3; l++)
    //         for (int i = k * 2; i < k * 2 + 2; i++)
    //             for (int j = l * 3; j < l * 3 + 3; j++)
    //                 revers[l * 2 + i, n / 2 * 3 - 3 * (1 + k) - j] = arr[i, j];

    int k = n / 2;
    int l = m / 3;
    int[,] start = new int[k, l];
    int[,] end = new int[l, k];

    for (int i = 0; i < k; i++)
        for (int j = 0; j < l; j++)
            start[i, j] = arr[i * 2, j * 3];

    for (int i = 0; i < k; i++)
        for (int j = 0; j < l; j++)
            end[j, k - 1 - i] = start[i, j];

    for (int i = 0; i < l; i++)
        for (int j = 0; j < k; j++)
            for (int a = 0; a < 2; a++)
                for (int b = 0; b < 3; b++)
                    revers[i * 2 + a, j * 3 + b] = end[i, j];

    return (revers, m / 3 * 2, n / 2 * 3);
}


// Проверка падения фигуры
// bool gameOver = false;
bool Drop(int x, int y, int[,] field, int[,] mapping, int row, int column)
{
    for (int i = 0; i < row; i += 2)
        for (int j = 0; j < column; j += 3)
            if (mapping[i, j] == 1 && field[i + y, j + x] == 1)
            {
                // if (y - column < 1) gameOver = true; // Проверка проигрыша
                return true;
            }

    return false;
}


// Изменения поля
int ChangeField(int x, int y, int[] lineCounter, int[,] field,
                int[,] mapping, int row, int column,
                int horizontal, int vertical)
{
    int count = 0;

    for (int i = 0; i < row; i++)
        for (int j = 0; j < column; j++)
            if (mapping[i, j] == 1)
            {
                field[i + y - 2, j + x] = 1;
                ++lineCounter[i + y];
                if (lineCounter[i + y] == horizontal - 24)
                {
                    count++;
                    Reduction(i + y - 2, field, lineCounter, horizontal);
                }
            }

    switch (count)
    {
        case 1: return 100;
        case 2: return 250;
        case 3: return 450;
        case 4: return 600;
        default: return 0;
    }
}


// Сокращение линий
void Reduction(int line, int[,] field, int[] lineCounter, int horizontal)
{
    for (int i = line; i > 1; i--)
    {
        for (int j = 12; j < horizontal - 12; j++)
            field[i, j] = field[i - 2, j];
        lineCounter[i] = lineCounter[i - 2];
    }
}


// Параметры поля
const int vertical = 42;
const int horizontal = 60;

// Инициализация поля
int[,] field = CreateField(vertical, horizontal);
int[] lineCounter = new int[horizontal - 24];   // Ширина поля -(поля) -(боковой буфер) 


// Первая запись фигур
(int[,] mapping, int row, int column) = NewFigure();

// Начальные параметры
Console.CursorVisible = false;
int x = horizontal / 2 - 3;
int y = 0;
int time = 500;
int points = 0;
int level = 1;


// Логика отрисовки всего
new Thread(() =>
{
    while (true)
    {
        while (time > 500) { }

        PrintField(field, vertical, horizontal);
        Figure(x, y, mapping, row, column);
        Thread.Sleep(time);

        y += 2;

        if (Drop(x, y, field, mapping, row, column))
        // if (y + row > vertical - 8)
        {
            points += ChangeField(x, y, lineCounter, field, mapping, row, column, horizontal, vertical);
            (mapping, row, column) = NewFigure();
            y = 0;
            x = horizontal / 2 - 3;
            time = 500;
        }
    }
}).Start();


// Логика проверки нажатия кнопок
while (true)
{
    var key = Console.ReadKey(true).Key;

    if (key == ConsoleKey.LeftArrow)
    {
        if (x > 12)
            x -= 3;
        Figure(x, y, mapping, row, column);
    }

    if (key == ConsoleKey.RightArrow)
    {
        if (x < horizontal - 12 - column)
            x += 3;
        Figure(x, y, mapping, row, column);
    }

    if (key == ConsoleKey.Spacebar)
    {
        (mapping, row, column) = Twist(mapping, row, column);
        Figure(x, y, mapping, row, column);
    }

    if (key == ConsoleKey.DownArrow)
    {
        time = 100;
        Figure(x, y, mapping, row, column);
    }

    if (key == ConsoleKey.P)
    {
        if (time <= 500)
        {
            time = 99999999;
            // Console.SetCursorPosition(horizontal / 4, vertical + 2);
            Console.WriteLine("PAUSE");
        }
        else time = 500;
    }
}
