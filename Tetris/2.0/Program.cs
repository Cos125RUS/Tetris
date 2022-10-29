int[,] CreateField(int vertical, int horizontal)
{
    int[,] field = new int[vertical, horizontal];

    for (int i = 2; i < 4; i++)
        for (int j = 0; j < horizontal; j++)
            field[i, j] = 1;

    for (int i = 4; i < vertical - 8; i++)
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


// Параметры поля
const int vertical = 42;
const int horizontal = 60;

// Инициализация поля
int[,] field = CreateField(vertical, horizontal);
PrintField(field, vertical, horizontal);

// Первая запись фигур
(int[,] mapping, int row, int column) = NewFigure();

// Начальные параметры
Console.CursorVisible = false;
int x = horizontal / 2 - 3;
int y = 0;
int time = 500;

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

        if (y + row > vertical - 8)
        {
            y = 0;
            x = horizontal / 2 - 3;
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
            // Console.SetCursorPosition(vertical / 4, horizontal + 2);
            Console.WriteLine("PAUSE");
        }
        else time = 500;
    }
}
