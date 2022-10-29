// Вид стартового поля
int[,] CreateField(int horizontal, int vertical)
{
    int[,] f = new int[vertical + 2, horizontal];

    for (int i = 0; i < vertical; i++)
    {
        f[i, 0] = 1;
        f[i, horizontal - 1] = 1;
    }

    for (int i = 0; i < horizontal; i++)
    {
        f[0, i] = 1;
        for (int j = vertical - 1; j < vertical + 2; j++)
            f[j, i] = 1;
    }

    return f;
}


// Отрисовка поля
void PrintField(int[,] field, int horizontal, int vertical)
{
    for (int i = 0; i < vertical; i++)
        for (int j = 0; j < horizontal; j++)
        {
            Console.SetCursorPosition(20 + i, j);
            if (j == 0 || j == horizontal - 1)
                Console.Write(Convert.ToChar(22));
            if ((i == 0 || i == vertical - 1) && j > 0 && j < horizontal - 1)
                Console.Write(Convert.ToChar(19));
            if (field[i, j] == 1 && i > 0 && i < vertical - 1 && j > 0 && j < horizontal - 1)
                Console.Write(Convert.ToChar(4));
        }
}


// Рисунок следующей фигуры
void PrintNextFigure(int[,] nextMapping, int nextRow, int nextColumn, int vertical)
{
    Console.SetCursorPosition(24 + vertical, 2);
    Console.Write("Next Figure:");

    for (int i = 0; i < nextRow; i++)
    {
        for (int j = 0; j < nextColumn; j++)
        {
            Console.SetCursorPosition(28 + vertical + i, 4 + j);
            if (nextMapping[i, j] == 1) Console.Write(Convert.ToChar(4));
        }
    }
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
                field[x + i, j + y - 1] = 1;
                ++lineCounter[j + y];
                if (lineCounter[j + y] == vertical - 2)
                {
                    count++;
                    Reduction(j + y, field, lineCounter, vertical);
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


// Выбор фигуры
int[,] Choice(int n)
{
    int[,] shape1 = {{0,1},
                     {1,1},
                     {1,0}};

    int[,] shape2 = { { 1, 1, 1, 1 } };

    int[,] shape3 = {{1,0},
                     {1,0},
                     {1,1}};

    int[,] shape4 = {{1,1},
                     {1,1}};

    int[,] shape5 = {{1,0},
                     {1,1},
                     {1,0}};

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

        default:
            return shape5;
    }
}


// Создание следующей фигуры
(int[,], int, int) NewFigure()
{
    int[,] shape = Choice(Random.Shared.Next(1, 6));
    int n = shape.GetLength(0);
    int m = shape.GetLength(1);

    return (shape, n, m);
}


// Копирование фигуры
(int[,], int, int) Copying(int[,] shape, int n, int m)
{
    int[,] f = new int[n, m];

    for (int i = 0; i < n; i++)
        for (int j = 0; j < m; j++)
            f[i, j] = shape[i, j];

    return (f, n, m);
}


// Поворот фигуры
(int[,], int, int) Twist(int[,] arr, int n, int m)
{
    int[,] revers = new int[m, n];

    for (int i = 0; i < n; i++)
        for (int j = 0; j < m; j++)
            revers[j, n - 1 - i] = arr[i, j];

    return (revers, m, n);
}


// Движение фигуры
void Figure(int x, int y, int[,] mapping, int row, int column)
{
    for (int i = 0; i < row; i++)
        for (int j = 0; j < column; j++)
        {
            Console.SetCursorPosition(20 + i + x, j + y);
            if (mapping[i, j] == 1 && y > 0) Console.Write(Convert.ToChar(4));
        }
}


// Проверка падения фигуры
bool gameOver = false;
bool Drop(int x, int y, int[,] field, int[,] mapping, int row, int column)
{
    for (int i = 0; i < row; i++)
        for (int j = 0; j < column; j++)
            if (mapping[i, j] == 1 && field[x + i, j + y] == 1)
            {
                if (y - column < 1) gameOver = true; // Проверка проигрыша
                return true;
            }

    return false;
}


// Сокращение линий
void Reduction(int line, int[,] field, int[] lineCounter, int vertical)
{
    for (int i = line; i > 0; i--)
    {
        for (int j = 1; j < vertical - 1; j++)
            field[j, i] = field[j, i - 1];
        lineCounter[i] = lineCounter[i - 1];
    }

    for (int i = 1; i < vertical - 1; i++)
        field[i, 1] = 0;
}


// Вывод подсчёта очков
void PrintPoints(int points, int level, int vertical, int horizontal)
{
    Console.SetCursorPosition(26 + vertical, horizontal - 5);
    Console.Write("Points:");
    Console.SetCursorPosition(27 + vertical, horizontal - 3);
    Console.Write(points);
    Console.SetCursorPosition(26 + vertical, horizontal - 8);
    Console.Write("level " + level);
}


// Уровни
(int, int) LevelsUp(int points)
{
    int level = 1;
    int time = 500;

    if (points >= 2000 && points < 5000)
    {
        level = 2;
        time = 450;
    }
    if (points >= 5000 && points < 8000)
    {
        level = 3;
        time = 400;
    }
    if (points >= 8000 && points < 12000)
    {
        level = 4;
        time = 300;
    }
    if (points >= 12000 && points < 20000)
    {
        level = 5;
        time = 200;
    }
    if (points >= 20000)
    {
        level = 6;
        time = 100;
    }
    return (level, time);
}


// Проверка на слепливание фигур
bool SideTest(int x, int y, int direction, int orientation, int[,] field, int[,] mapping, int row, int column)
{
    for (int i = 0; i < row; i++)
        for (int j = 0; j < column; j++)
            if (mapping[i, j] == 1 && field[x + i + direction, j + y + orientation] == 1) return true;

    return false;
}


// Запрос рестарта
bool RequestRestart(int[,] field, int horizontal, int vertical)
{
    Console.SetCursorPosition(19 + vertical / 4, horizontal + 2);
    Console.Write("GAME OVER!");
    Console.SetCursorPosition(19 + vertical / 4, horizontal + 4);
    Console.Write("Try again?");
    Console.SetCursorPosition(21 + vertical / 4, horizontal + 5);
    Console.Write("(y/n)");

    var key = Console.ReadKey(true).Key;

    if (key == ConsoleKey.Y) return true;
    if (key == ConsoleKey.N) return false;
    else return RequestRestart(field, horizontal, vertical);
}


// Рестарт
(int[,], int[], int, int, bool) Restart(int[,] field, int horizontal, int vertical, 
                                        int[] lineCounter, int points, int time, bool gameOver)
{
    field = CreateField(horizontal, vertical);
    for (int i = 1; i < horizontal; i++)
        lineCounter[i] = 0;
    points = 0;
    time = 500;
    gameOver = false;

    return (field, lineCounter, points, time, gameOver);
}


// Параметры поля
const int horizontal = 22;
const int vertical = 18;

// Инициализация поля
int[,] field = CreateField(horizontal, vertical);
int[] lineCounter = new int[horizontal];

// Первая запись фигур
(int[,] mapping, int row, int column) = NewFigure();
(int[,] nextMapping, int nextRow, int nextColumn) = NewFigure();

// Начальные параметры
Console.CursorVisible = false;
int x = vertical / 2 - 1;
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

        Console.Clear();
        Console.SetCursorPosition(20, vertical);
        PrintField(field, horizontal, vertical);
        PrintNextFigure(nextMapping, nextRow, nextColumn, vertical);
        PrintPoints(points, level, vertical, horizontal);
        Figure(x, y, mapping, row, column);
        Thread.Sleep(time);

        if (gameOver)
        {
            time = 99999999;
            if (RequestRestart(field, horizontal, vertical))
                (field, lineCounter, points, time, gameOver) =
                Restart(field, horizontal, vertical, lineCounter, points, time, gameOver);
            else break;
        }

        y++;

        if (Drop(x, y, field, mapping, row, column))
        {
            points += ChangeField(x, y, lineCounter, field, mapping, row, column, horizontal, vertical);
            (mapping, row, column) = Copying(nextMapping, nextRow, nextColumn);
            (nextMapping, nextRow, nextColumn) = NewFigure();
            (level, time) = LevelsUp(points);
            y = 0;
            x = vertical / 2 - 1;
        }
    }
}).Start();


// Логика проверки нажатия кнопок
while (true)
{
    var key = Console.ReadKey(true).Key;

    if (key == ConsoleKey.LeftArrow)
    {
        if (x > 1 && !SideTest(x, y, -1, 0, field, mapping, row, column)) x--;
        Figure(x, y, mapping, row, column);
    }

    if (key == ConsoleKey.RightArrow)
    {
        if (x < vertical - 1 - row && !SideTest(x, y, 1, 0, field, mapping, row, column)) x++;
        Figure(x, y, mapping, row, column);
    }

    if (key == ConsoleKey.Spacebar)
    {
        (mapping, row, column) = Twist(mapping, row, column);
        while (x > vertical - 1 - row) x--;
        while (x < 1) x++;
        while (y + column > horizontal - 1) y--;
        if (y > 1)
        {
            while (SideTest(x, y, 0, 1, field, mapping, row, column))
            {
                y--;
                if (SideTest(x, y, 1, 0, field, mapping, row, column)) x--;
                if (SideTest(x, y, -1, 0, field, mapping, row, column)) x++;
            }
        }
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
            Console.SetCursorPosition(22 + vertical / 4, horizontal + 2);
            System.Console.WriteLine("PAUSE");
        }
        else (level, time) = LevelsUp(points);
    }
}
