using System;
using JourneyToTheEndOfTheLine.Systems;
using JourneyToTheEndOfTheLine.Acts;

namespace JourneyToTheEndOfTheLine
{
    class Program
    {
        static void Main(string[] args)
        { 
            try
            {
                // Set up the console window
                Console.Title = "Journey to the End of the Line";
                Console.SetWindowSize(150, 50);
                Console.SetBufferSize(150, 500);
                Console.BackgroundColor = ConsoleColor.DarkGray;
                Console.ForegroundColor = ConsoleColor.White;
                Console.Clear();
            }
            catch (IOException)
            {
                Console.WriteLine("Console resizing not supported. Continuing normally...");
            }

            try
            {
                Console.Clear();
            }
            catch (IOException)
            {
                Console.WriteLine("(Console clear not supported.)");
            }

            // Start game
            GameState state = new GameState();
            TitleScreen.Show();
            Console.Clear();
            Console.Write("What is the name of this adventurer?: ");
            state.PlayerName = Console.ReadLine();

            try
            {
                Console.Clear();
            }
            catch (IOException)
            {
                Console.WriteLine("(Console clear not supported on this system.)");
            }

            UI.DisplayTitle("JOURNEY TO THE END OF THE LINE");
            UI.TypeText($"Welcome, {state.PlayerName}, to a world on the edge of collapse...\n");
            UI.Pause();

            RunActMenu(state);

            GameEnding.Show(state);

            if (state.Act1Completed && state.Act2Completed && state.Act3Completed)
            {
                PostCreditScene.Show();
                EasterEgg.CheckForSecret(state);
            }
        }

        static void RunActMenu(GameState state)
        {
            bool done = false;

            while (!done)
            {
                try
                {
                    Console.Clear();
                }
                catch (IOException)
                {
                    Console.WriteLine("(Console clear not supported on this system.)");
                }

                UI.DisplayTitle("Select an Act");
                Console.WriteLine("[1] " + FormatAct("Act I: The Forest of Tusks", true, state.Act1Completed));
                Console.WriteLine("[2] " + FormatAct("Act II: The Storm at Sea", state.Act1Completed, state.Act2Completed));
                Console.WriteLine("[3] " + FormatAct("Act III: The Celestial Ascent", state.Act2Completed, state.Act3Completed));
                Console.WriteLine("[0] Exit Game");
                Console.Write("\nEnter your choice: ");

                string input = Console.ReadLine();
                if (input == null)
                {
                    Console.WriteLine("(Input not available. Exiting...)");
                    return; // or Environment.Exit(0); if you want instant shutdown
                }
                input = input.Trim();

                switch (input)
                {
                    case "1":
                        Act1.Start(state);
                        break;
                    case "2":
                        if (state.Act1Completed) Act2.Start(state);
                        else UI.TypeText("That path is still sealed.");
                        break;
                    case "3":
                        if (state.Act2Completed) Act3.Start(state);
                        else UI.TypeText("That path is still sealed.");
                        break;
                    case "0":
                        done = true;
                        break;
                    default:
                        UI.TypeText("Invalid selection.");
                        break;
                }

                if (state.Act1Completed && state.Act2Completed && state.Act3Completed)
                {
                    done = true;
                }
            }
        }

        static string FormatAct(string title, bool unlocked, bool completed)
        {
            if (completed) return "[✔] " + title;
            if (!unlocked) return "[🔒] " + title;
            return "[🔓] " + title;
        }
    }
}