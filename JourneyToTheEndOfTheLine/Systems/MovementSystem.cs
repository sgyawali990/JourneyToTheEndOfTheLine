using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JourneyToTheEndOfTheLine.Maps;

namespace JourneyToTheEndOfTheLine.Systems
{
    public static class MovementSystem
    {
        public static void Run(Map map, GameState state, Func<char, bool> onInteract, Func<bool> ritualCheck)
        {
            bool done = false;

            while (!done)
            {
                map.Draw();
                Console.WriteLine("\nUse W A S D to move. Press E to interact. Press Q to exit (if ritual is complete).\n");
                Console.Write("Input: ");
                char input = Console.ReadKey(true).KeyChar;
                bool validMove = false;

                switch (char.ToLower(input))
                {
                    case 'w':
                    case 'a':
                    case 's':
                    case 'd':
                        validMove = map.Move(input);
                        if (!validMove)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("\nYou bump into something. Can't go that way.");
                            Console.ResetColor();
                            Thread.Sleep(500); // tiny pause for feel
                        }
                        break;

                    case 'e':
                        char tile = map.CurrentTile();
                        if (!onInteract(tile))
                        {
                            UI.TypeText("There is nothing to interact with here.");
                            UI.Pause();
                        }
                        break;

                    case 'q':
                        if (ritualCheck())
                        {
                            done = true;
                        }
                        else
                        {
                            UI.TypeText("You can’t leave yet — something’s unfinished.");
                            UI.Pause();
                        }
                        break;

                    default:
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("\nInvalid input. Try W A S D, E, or Q.");
                        Console.ResetColor();
                        Thread.Sleep(500);
                        break;
                }
            }
        }
    }
}