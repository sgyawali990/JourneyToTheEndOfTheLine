using System;

namespace JourneyToTheEndOfTheLine.Systems
{
    public static class MiniGames
    {
        public static void PlayTicTacToePuzzle()
        {
            Console.Clear();
            UI.DisplayTitle("Mini-Game: Ghostly Tic-Tac-Toe");
            UI.TypeText("You find a strange ghost board carved into the deck...\n");
            UI.TypeText("You must complete the pattern correctly to appease the spirits.");

            Console.WriteLine("\nEnter the rows one by one (use X and O only):\n");

            Console.Write("Row 1: ");
            string row1 = Console.ReadLine()?.Trim().ToUpper();

            Console.Write("Row 2: ");
            string row2 = Console.ReadLine()?.Trim().ToUpper();

            Console.Write("Row 3: ");
            string row3 = Console.ReadLine()?.Trim().ToUpper();

            if (row1 == "XXX" && row2 == "OOO" && row3 == "XXX")
            {
                UI.TypeText("\nThe spirits accept your offering. The board fades away peacefully.", ConsoleColor.Green);
                Console.Beep(1000, 300);
            }
            else
            {
                UI.TypeText("\nThe spirits are displeased... The board crumbles into dust.", ConsoleColor.Red);
                Console.Beep(500, 300);
            }

            UI.Pause();
            Console.Clear();
        }

        public static void PlayTarot()
        {
            Console.Clear();
            UI.DisplayTitle("Mini-Game: Ghostly Tarot Reading");

            string[] cards = new string[]
            {
                "The Tower - Chaos looms ahead.",
                "The Sun - Bright fortunes smile upon you.",
                "The Moon - Secrets cloud your path.",
                "Death - A transformation awaits.",
                "The Fool - A strange new journey begins.",
                "The Lovers - Strange alliances form in the mist.",
                "The Hanged Man - A sacrifice must be made."
            };

            Random rand = new Random();
            int draw = rand.Next(cards.Length);

            UI.TypeText($"\nYou pull a card: {cards[draw]}", ConsoleColor.Cyan);

            UI.Pause();
            Console.Clear();
        }
    }
}
