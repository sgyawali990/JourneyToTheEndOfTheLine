using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace JourneyToTheEndOfTheLine.Systems
{
    public static class GameEnding
    {
        public static void Show(GameState state)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;

            Console.WriteLine("\n\nYou stand at the edge of the world...");
            Console.Beep(660, 300);
            Console.Beep(440, 300);
            Console.Beep(392, 500);
            Thread.Sleep(800);
            Console.WriteLine("The sky folds inward. The stars blink out one by one.");
            Thread.Sleep(800);
            Console.WriteLine("Time unravels like thread. The line is gone.");
            Thread.Sleep(1000);
            Console.WriteLine("\nBut you remain.");
            Thread.Sleep(1200);

            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("\n\n=========== FINAL SUMMARY ===========\n");

            Console.WriteLine($"Player: {state.PlayerName}");
            Console.WriteLine($"Clues Collected: {state.Inventory.ItemCount} items");
            Console.WriteLine($"Siren Spared: {(state.Choices.ContainsKey("SparedSiren") && state.Choices["SparedSiren"] ? "Yes" : "No")}");
            Console.WriteLine("Path Taken: ");
            Console.WriteLine(state.Act1Completed ? "✔ Act I" : "✘ Act I");
            Console.WriteLine(state.Act2Completed ? "✔ Act II" : "✘ Act II");
            Console.WriteLine(state.Act3Completed ? "✔ Act III" : "✘ Act III");

            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("\n\nThank you for walking the line.");
            Console.ResetColor();
            Console.WriteLine("\nPress ENTER to exit.");
            Console.ReadLine();
        }
    }
}
