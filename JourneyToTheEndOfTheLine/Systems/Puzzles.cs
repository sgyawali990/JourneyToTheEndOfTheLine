using System;

namespace JourneyToTheEndOfTheLine.Systems
{
    public static class Puzzles
    {
        public static void PoemPuzzle(ref bool solved)
        {
            Console.Clear();
            UI.DisplayTitle("Poem Puzzle");
            UI.TypeText("An ancient poem reads:\n");
            UI.TypeText("\"Speak the word that parts the veils of stone.\"\n");
            UI.TypeText("What single word will open the gate?");
            Console.Write("\nAnswer: ");
            string input = Console.ReadLine()?.Trim().ToLower();

            if (input == "open")
            {
                UI.TypeText("The gate rumbles as ancient mechanisms stir to life.", ConsoleColor.Green);
                solved = true;
            }
            else
            {
                UI.TypeText("Nothing happens. The poem remains silent.", ConsoleColor.DarkGray);
            }
            UI.Pause();
            Console.Clear();
        }
        public static void StatuePuzzle(ref bool solved)
        {
            Console.Clear();
            UI.DisplayTitle("Statue Puzzle");
            UI.TypeText("Three statues block your path. Each one speaks:");

            UI.TypeText("\n1. \"I tell only the truth.\"\n2. \"I always lie.\"\n3. \"I speak randomly.\"\n");
            UI.TypeText("Only one path is safe. Choose the statue number you trust (1, 2, or 3).");

            Console.Write("\nChoice: ");
            string input = Console.ReadLine()?.Trim();

            if (input == "1")
            {
                UI.TypeText("You chose wisely. The statue steps aside.", ConsoleColor.Green);
                solved = true;
            }
            else
            {
                UI.TypeText("The floor crumbles beneath you... but you cling to the edge and survive.", ConsoleColor.Red);
            }
            UI.Pause();
            Console.Clear();
        }
    }
}