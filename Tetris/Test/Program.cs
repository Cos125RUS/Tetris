void Save(int[,] field, int vertical, int horizontal)
{
    string[] saveGame = new string[vertical];
    File.WriteAllText("save.txt", "");

    for (int i = 0; i < vertical; i++)
    {
        for (int j = 0; j < horizontal; j++)
        {
            saveGame[i] += field[i, j];
        }
    }
    File.AppendAllLines("save.txt", saveGame);
}


const int vertical = 2;
const int horizontal = 4;

int[,] field = {{0,0,1,1},
                {1,1,0,0}};



Save(field, vertical, horizontal);