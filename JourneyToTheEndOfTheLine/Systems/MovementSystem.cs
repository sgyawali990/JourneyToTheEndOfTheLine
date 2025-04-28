using System;
using JourneyToTheEndOfTheLine.Systems;

namespace JourneyToTheEndOfTheLine.Systems
{
    public static class MovementSystem
    {
        public static void Run(Map map, GameState state, Func<char, bool> interactAction, Func<bool> exitCondition)
        {
            bool exit = false;
            var originalBackground = Console.BackgroundColor;

            while (!exit)
            {
                Console.BackgroundColor = originalBackground;
                Console.Clear();
                map.Draw();
                Console.SetCursorPosition(0, map.Height + 3);
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("\nUse W A S D or Arrow Keys to move. Press E to interact. Press Q to exit.\n");
                Console.Write("Input: ");
                Console.ResetColor();

                ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                char inputChar = char.ToLower(keyInfo.KeyChar);

                bool moveSuccessful = false;

                if (keyInfo.Key == ConsoleKey.Q)
                {
                    if (exitCondition())
                    {
                        exit = true;
                    }
                    else
                    {
                        UI.TypeText("You can't leave yet — there's more to do here.", ConsoleColor.Yellow);
                        UI.Pause();
                    }
                }
                else if (keyInfo.Key == ConsoleKey.E)
                {
                    bool didInteract = interactAction(map.CurrentTile());

                    if (!didInteract)
                    {
                        Console.ForegroundColor = ConsoleColor.Gray;
                        Console.WriteLine("\nThere is nothing here to interact with.");
                        Console.ResetColor();
                        Thread.Sleep(500);
                    }
                }
                else if (keyInfo.Key == ConsoleKey.UpArrow || inputChar == 'w')
                {
                    moveSuccessful = map.Move('w');
                }
                else if (keyInfo.Key == ConsoleKey.DownArrow || inputChar == 's')
                {
                    moveSuccessful = map.Move('s');
                }
                else if (keyInfo.Key == ConsoleKey.LeftArrow || inputChar == 'a')
                {
                    moveSuccessful = map.Move('a');
                }
                else if (keyInfo.Key == ConsoleKey.RightArrow || inputChar == 'd')
                {
                    moveSuccessful = map.Move('d');
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("\nInvalid input. Use W A S D or Arrow Keys to move. Press E to interact, Q to exit.");
                    Console.ResetColor();
                    Thread.Sleep(500);
                }

                if (!moveSuccessful &&
                    (keyInfo.Key == ConsoleKey.UpArrow || inputChar == 'w' ||
                     keyInfo.Key == ConsoleKey.DownArrow || inputChar == 's' ||
                     keyInfo.Key == ConsoleKey.LeftArrow || inputChar == 'a' ||
                     keyInfo.Key == ConsoleKey.RightArrow || inputChar == 'd'))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\nYou bump into a wall. You can’t go that way.");
                    Console.ResetColor();
                    Thread.Sleep(500);
                }
            }
        }
    }
}