using System;
using System.Collections.Generic;

namespace Enkelt_spel
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Skapa en tvådimensionell array för kartan
            char[,] karta = new char[10, 10];

            // Initial position för bokstaven "G" (övre högra hörnet)
            int gX = 9;
            int gY = 0;

            // Initial position för spelaren (i mitten av kartan)
            int playerX = 5;
            int playerY = 5;

            // Rörelsemönster för "G"
            List<Tuple<int, int>> gMovementPattern = new List<Tuple<int, int>>
            {
                Tuple.Create(0, 1),  // Höger
                Tuple.Create(1, 0),  // Ner
                Tuple.Create(0, -1), // Vänster
                Tuple.Create(-1, 0)  // Upp
            };

            int gMoveIndex = 0;

            // Huvudloopen för att uppdatera och skriva ut kartan
            while (true)
            {
                // Uppdatera positionen för bokstaven "G" enligt rörelsemönstret
                gX += gMovementPattern[gMoveIndex].Item1;
                gY += gMovementPattern[gMoveIndex].Item2;

                // Kolla om "G" når kartans kant och ändra riktning om det behövs
                if (gX < 0 || gX >= 10 || gY < 0 || gY >= 10)
                {
                    // Ändra riktningen
                    gMoveIndex = (gMoveIndex + 1) % gMovementPattern.Count;

                    // Justera "G"s position
                    gX = Math.Clamp(gX, 0, 9);
                    gY = Math.Clamp(gY, 0, 9);
                }

                // Rensa kartan
                for (int i = 0; i < 10; i++)
                {
                    for (int j = 0; j < 10; j++)
                    {
                        karta[i, j] = '.';
                    }
                }

                // Lägg till kartan
                for (int i = 0; i < 10; i++)
                {
                    for (int j = 0; j < 10; j++)
                    {
                        Console.Write(karta[i, j] + " ");
                    }
                    Console.WriteLine();
                }

                // Utskrift av "G"
                Console.SetCursorPosition(gX * 2, gY);
                Console.Write('G');

                // Utskrift av spelaren "O"
                Console.SetCursorPosition(playerX * 2, playerY);
                Console.Write('O');

                // Läs in tangenttryckning för att styra spelaren
                ConsoleKeyInfo keyInfo = Console.ReadKey(true);

                // Uppdatera spelarens position baserat på tangenttryckningen
                switch (keyInfo.Key)
                {
                    case ConsoleKey.UpArrow:
                        if (playerY > 0)
                            playerY--;
                        break;
                    case ConsoleKey.DownArrow:
                        if (playerY < 9)
                            playerY++;
                        break;
                    case ConsoleKey.LeftArrow:
                        if (playerX > 0)
                            playerX--;
                        break;
                    case ConsoleKey.RightArrow:
                        if (playerX < 9)
                            playerX++;
                        break;
                }

                // Rensa konsolen för att uppdatera kartan
                Console.Clear();
            }
        }
    }
}
