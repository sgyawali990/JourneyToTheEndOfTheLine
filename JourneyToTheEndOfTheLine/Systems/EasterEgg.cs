using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JourneyToTheEndOfTheLine.Systems
{
    public static class EasterEgg
    {
        public static void CheckForSecret(GameState state)
        {
            // Requirements
            bool allItems = new[]
            {
                "Feather of the Sky", "Shard of Starlight", "Breath of Wind",
                "Sea Clue 1", "Sea Clue 2", "Sea Clue 3",
                "Golden Key"
            }.All(item => state.Inventory.HasItem(item));

            bool allRituals = state.Act1Completed && state.Act2Completed && state.Act3Completed;

            bool madeChoice = state.Choices.ContainsKey("SparedSiren");

            if (allItems && allRituals && madeChoice)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine(">>> UNLOCKED TERMINAL [CLASSIFIED]");
                Console.WriteLine("> Decrypting...");
                System.Threading.Thread.Sleep(1500);
                Console.Clear();
                UI.TypeText("You found everything.\n", ConsoleColor.Gray);
                UI.TypeText("But did it find you?", ConsoleColor.DarkRed);
                UI.Pause();
                Console.ResetColor();
            }
        }
    }
}

