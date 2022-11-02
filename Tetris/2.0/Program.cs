// Главное меню
void Menu(int cursor)
{
    int a = 0;
    if (cursor > 0) a = 2;

    Console.Clear();

    Console.SetCursorPosition(40, 10);
    Console.Write("New game");

    Console.SetCursorPosition(42, 12);
    Console.Write("Save");

    Console.SetCursorPosition(42, 14);
    Console.Write("Load");

    Console.SetCursorPosition(37 + a, 10 + cursor);
    Console.Write('*');
}


// Создание поля
int[,] CreateField(int vertical, int horizontal)
{
    int[,] field = new int[vertical, horizontal];

    for (int i = 0; i < vertical - 8; i++)
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

    for (int i = 2; i < vertical - 6; i++)
    {
        for (int j = 9; j < horizontal - 9; j++)
        {
            Console.SetCursorPosition(20 + j, i);
            if (field[i, j] == 1)
                Console.Write('*');
        }
    }
}


// Вывод информации
void PrintInformation(int vertical, int points, int level, int[,] next, int row, int column)
{
    Console.SetCursorPosition(7, vertical - 14);
    Console.Write("Points");
    Console.SetCursorPosition(7, vertical - 12);
    Console.Write(points);
    Console.SetCursorPosition(7, vertical - 20);
    Console.Write("Level " + level);

    Console.SetCursorPosition(7, 6);
    Console.Write("Next Figure:");

    for (int i = 0; i < row; i++)
        for (int j = 0; j < column; j++)
        {
            Console.SetCursorPosition(7 + j, 9 + i);
            if (next[i, j] == 1) Console.Write('*');
        }
}


// Сообщение о паузе
void Pause(int vertical, int horizontal)
{
    Console.SetCursorPosition(20 + horizontal / 2 - 5, 9);
    for (int i = 0; i < 11; i++)
        Console.Write(' ');

    Console.SetCursorPosition(20 + horizontal / 2 - 5, 10);
    for (int i = 0; i < 11; i++)
        Console.Write('+');

    Console.SetCursorPosition(20 + horizontal / 2 - 5, 11);
    Console.WriteLine("+  PAUSE  +");

    Console.SetCursorPosition(20 + horizontal / 2 - 5, 12);
    for (int i = 0; i < 11; i++)
        Console.Write('+');

    Console.SetCursorPosition(20 + horizontal / 2 - 5, 13);
    for (int i = 0; i < 11; i++)
        Console.Write(' ');
}


// Сообщение о проигрыше
void Looser(int vertical, int horizontal)
{
    for (int i = 0; i < 15; i++)
    {
        Console.SetCursorPosition(20 + horizontal / 2 + i - 7, 9);
        Console.Write(' ');
        Console.SetCursorPosition(20 + horizontal / 2 + i - 7, 10);
        Console.Write('+');
        Console.SetCursorPosition(20 + horizontal / 2 + i - 7, 16);
        Console.Write('+');
        Console.SetCursorPosition(20 + horizontal / 2 + i - 7, 17);
        Console.Write(' ');
        if (i > 0 && i < 14)
        {
            Console.SetCursorPosition(20 + horizontal / 2 + i - 7, 12);
            Console.Write(' ');
            Console.SetCursorPosition(20 + horizontal / 2 + i - 7, 13);
            Console.Write(' ');
        }
        if (i == 0 || i == 14)
        {
            Console.SetCursorPosition(20 + horizontal / 2 + i - 7, 12);
            Console.Write('+');
            Console.SetCursorPosition(20 + horizontal / 2 + i - 7, 13);
            Console.Write('+');
        }
    }

    Console.SetCursorPosition(20 + horizontal / 2 - 7, 11);
    Console.WriteLine("+  GAME OVER  +");
    Console.SetCursorPosition(20 + horizontal / 2 - 7, 14);
    Console.Write("+  Try again? +");
    Console.SetCursorPosition(20 + horizontal / 2 - 7, 15);
    Console.Write("+    (y/n)    +");
}


// Запрос рестарта
bool RequestRestart()
{
        var key = Console.ReadKey(true).Key;

        if (key == ConsoleKey.Y) return true;
        if (key == ConsoleKey.N) return false;
        else return RequestRestart();
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


// Копирование фигуры
(int[,], int, int) Copying(int[,] shape, int n, int m)
{
    int[,] f = new int[n, m];

    for (int i = 0; i < n; i++)
        for (int j = 0; j < m; j++)
            f[i, j] = shape[i, j];

    return (f, n, m);
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


// Проверка на слепливание фигур
bool SideTest(int x, int y, int direction, int orientation, int[,] field, int[,] mapping, int row, int column)
{
    for (int i = 0; i < row; i++)
        for (int j = 0; j < column; j++)
            if (mapping[i, j] == 1 && field[y + i + orientation * 2, j + x + direction * 3] == 1) return true;

    return false;
}


// Смещение фигуры при вращении
(int, int) TwistTest(int x, int y, int[,] field, int[,] mapping, int row, int column, int horizontal)
{
    int direction = 0;
    int orientation = 0;

    for (int i = 0; i < row; i += 2)
        for (int j = 3; j < column; j += 3)
            if (mapping[i, j] == 1 && field[i + y, j + x] == 1)
                direction = -1;

    for (int i = 2; i < row; i += 2)
        for (int j = 0; j < column; j += 3)
            if (mapping[i, j] == 1 && field[i + y, j + x] == 1)
                orientation = -1;

    return (3 * direction, 2 * orientation);
}


// Проверка падения фигуры
bool gameOver = false;
bool Drop(int x, int y, int[,] field, int[,] mapping, int row, int column)
{
    for (int i = 0; i < row; i += 2)
        for (int j = 0; j < column; j += 3)
            if (mapping[i, j] == 1 && field[i + y, j + x] == 1)
            {
                if (y < 4) gameOver = true; // Проверка проигрыша
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
    {
        for (int j = 0; j < column; j++)
            if (mapping[i, j] == 1)
            {
                field[i + y - 2, j + x] = 1;
                ++lineCounter[i + y - 2];
            }

        if (lineCounter[i + y - 2] == horizontal - 24 && i % 2 != 0)
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


// Рестарт
(int[,], int[], int, int, bool) Restart(int[,] field, int horizontal, int vertical,
                                        int[] lineCounter, int points, int time, bool gameOver)
{
    field = CreateField(vertical, horizontal);
    for (int i = 2; i < vertical - 8; i++)
        lineCounter[i] = 0;
    points = 0;
    time = 500;
    gameOver = false;

    return (field, lineCounter, points, time, gameOver);
}


// Параметры поля
const int vertical = 42;
const int horizontal = 60;

// Запуск
Console.CursorVisible = false;
bool startGame = false;
bool pause = false;
int cursor = 0;

// Инициализация поля
int[,] field = CreateField(vertical, horizontal);
int[] lineCounter = new int[horizontal - 24];   // Ширина поля -(рамка) -(боковой буфер) 

// Первая запись фигур
(int[,] mapping, int row, int column) = NewFigure();
(int[,] nextMapping, int nextRow, int nextColumn) = NewFigure();

// Начальные параметры
int x = horizontal / 2 - 3;
int y = 0;
int time = 1000;
int points = 0;
int level = 1;


// Логика отрисовки всего
new Thread(() =>
{
    while (true)
    {
        while (!startGame)
        {
            Menu(cursor);
            Thread.Sleep(time);
        }

        while (pause)
        {
            Pause(vertical, horizontal);
            Thread.Sleep(time);
        }

        if (!gameOver)
        {
            PrintField(field, vertical, horizontal);
            PrintInformation(vertical, points, level, nextMapping, nextRow, nextColumn);
            Figure(x, y, mapping, row, column);
            Thread.Sleep(time);

            y += 2;

            if (Drop(x, y, field, mapping, row, column))
            {
                points += ChangeField(x, y, lineCounter, field, mapping, row, column, horizontal, vertical);
                (mapping, row, column) = Copying(nextMapping, nextRow, nextColumn);
                (nextMapping, nextRow, nextColumn) = NewFigure();
                (level, time) = LevelsUp(points);
                y = 0;
                x = horizontal / 2 - 3;
            }
        }
        else
        {
            time = 500;
            Looser(vertical, horizontal);
            if (RequestRestart())
            {
                (field, lineCounter, points, time, gameOver) =
                Restart(field, horizontal, vertical, lineCounter, points, time, gameOver);
            }
            else
            {
                Console.Clear();
                Console.SetCursorPosition(20 + horizontal / 2 - 8, 9);
                Console.WriteLine("Your points: " + points);
                Thread.Sleep(3000);
                startGame = false;
            }
        }
    }
}).Start();


// Логика проверки нажатия кнопок
while (true)
{
    var key = Console.ReadKey(true).Key;

    if (startGame)
    {
        if (key == ConsoleKey.LeftArrow)
        {
            if (!SideTest(x, y, -1, 0, field, mapping, row, column))
                x -= 3;
            Figure(x, y, mapping, row, column);
        }

        if (key == ConsoleKey.RightArrow)
        {
            if (!SideTest(x, y, 1, 0, field, mapping, row, column))
                x += 3;
            Figure(x, y, mapping, row, column);
        }

        if (key == ConsoleKey.Spacebar)
        {
            if (y + row < vertical - 8)
            {
                (mapping, row, column) = Twist(mapping, row, column);
                while (x + column > horizontal - 12) x -= 3;
                while (x < 12) x += 3;
                while (SideTest(x, y, 0, 0, field, mapping, row, column))
                {
                    (int direction, int orientation) = TwistTest(x, y, field, mapping, row, column, horizontal);
                    x += direction;
                    y += orientation;
                }
                Figure(x, y, mapping, row, column);
            }
        }

        if (key == ConsoleKey.DownArrow)
        {
            time = 100;
            Figure(x, y, mapping, row, column);
        }

        if (key == ConsoleKey.P)
        {
            if (!pause)
            {
                time = 500;
                pause = true;
            }
            else
            {
                pause = false;
                (level, time) = LevelsUp(points);
            }

        }

        if (key == ConsoleKey.Escape)
        {
            time = 1000;
            startGame = false;
            if (pause) pause = false;
        }
    }
    else
    {
        if (key == ConsoleKey.DownArrow)
        {
            if (cursor < 4) cursor += 2;
            Menu(cursor);
        }

        if (key == ConsoleKey.UpArrow)
        {
            if (cursor > 0) cursor -= 2;
            Menu(cursor);
        }

        if (key == ConsoleKey.Enter)
        {
            switch (cursor)
            {
                case 0:
                    startGame = true;
                    (mapping, row, column) = NewFigure();
                    (nextMapping, nextRow, nextColumn) = NewFigure();
                    level = 1;
                    (field, lineCounter, points, time, gameOver) =
                    Restart(field, horizontal, vertical, lineCounter,
                    points, time, gameOver);
                    y = 0;
                    x = horizontal / 2 - 3;
                    break;

                case 2:
                    startGame = true;
                    (level, time) = LevelsUp(0);
                    break;

                default:
                    startGame = true;
                    (level, time) = LevelsUp(0);
                    break;
            }
        }
    }
}
