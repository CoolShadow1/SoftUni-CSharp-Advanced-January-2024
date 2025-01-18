byte mazeSize = byte.Parse(Console.ReadLine()!);
char[,] maze = new char[mazeSize, mazeSize];

byte currentRow = 0;
byte currentColumn = 0;

for (byte i = 0; i < mazeSize; i++)
{
    char[] row = Console.ReadLine()!.ToCharArray();
    for (byte j = 0; j < mazeSize; j++)
    {
        if (row[j] == 'P')
        {
            currentRow = i;
            currentColumn = j;
        }

        maze[i, j] = row[j];
    }
}

sbyte playerHealth = 100;
bool hasGameEnded = false;

while (true)
{
    string command = Console.ReadLine()!;
    switch (command)
    {
        case "left":
            MoveTo((byte)(currentColumn - 1), currentRow);
            break;
        case "right":
            MoveTo((byte)(currentColumn + 1), currentRow);
            break;
        case "up":
            MoveTo(currentColumn, (byte)(currentRow - 1));
            break;
        case "down":
            MoveTo(currentColumn, (byte)(currentRow + 1));
            break;
    }

    if (hasGameEnded) break;
}

Console.WriteLine($"Player's health: {playerHealth} units");
PrintMaze();

void MoveTo(byte x, byte y)
{
    if (x < 0 || y < 0 || x >= mazeSize || y >= mazeSize) return;

    char nextPosition = maze[y, x];

    maze[y, x] = 'P';
    maze[currentRow, currentColumn] = '-';
    currentColumn = x;
    currentRow = y;

    switch (nextPosition)
    {
        case 'X':
            Console.WriteLine("Player escaped the maze. Danger passed!");
            hasGameEnded = true;
            break;
        case 'H':
            playerHealth += 15;
            if (playerHealth > 100) playerHealth = 100;
            break;
        case 'M':
            playerHealth -= 40;
            if (playerHealth <= 0)
            {
                playerHealth = 0;
                Console.WriteLine("Player is dead. Maze over!");
                hasGameEnded = true;
            }

            break;
    }
}

void PrintMaze()
{
    for (int i = 0; i < mazeSize; i++)
    {
        for (int j = 0; j < mazeSize; j++) Console.Write(maze[i, j]);
        Console.WriteLine();
    }
}