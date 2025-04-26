using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JourneyToTheEndOfTheLine.Systems;
using JourneyToTheEndOfTheLine.Maps;

namespace JourneyToTheEndOfTheLine.Acts
{
    public static class Act3
    {
        private static void ShowMapLegend()
        {
            Console.WriteLine("\n== Map Legend ==");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("☁ : Cloud (Searchable Clue)");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("! : Glitch Tile");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("❂ : Shrine Fragment");
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("⊙ : Celestial Altar (Ritual)");
            Console.ResetColor();
            UI.Pause();
        }

        public static void Start(GameState state)
        {
            ActTransitions.Show("Act III: The Celestial Ascent");

            UI.DisplayTitle("Act 3: The Celestial Ascent");
            UI.TypeText($"{state.PlayerName}, you awaken floating among shattered sky-temples and drifting clouds. The world below is gone.");
            UI.Pause();

            var map = Map_Sky.Generate();
            ShowMapLegend();
            string[] offerings = { "Feather of the Sky", "Shard of Starlight", "Breath of Wind" };
            int offeringsFound = 0;
            bool ritualDone = false;
            bool finalDecisionMade = false;
            bool glitchTriggered = false; 

            MovementSystem.Run(
                map,
                state,
                (tile) => {
                    switch (tile)
                    {
                        case 'C':
                            if (new Random().NextDouble() < 0.5 && offeringsFound < offerings.Length)
                            {
                                string item = offerings[offeringsFound];
                                if (!state.Inventory.HasItem(item))
                                {
                                    state.Inventory.AddItem(item);
                                    offeringsFound++;
                                    UI.TypeText($"You search the cloud and find the offering: {item}.");
                                    Console.Beep(600, 150);
                                    Console.Beep(800, 150);
                                }
                                else
                                {
                                    UI.TypeText("The cloud drifts silently. You've already searched here.");
                                }
                            }
                            else
                            {
                                UI.TypeText("The clouds are silent.");
                            }
                            return true;

                        case 'O':
                            UI.TypeText("A shrine fragment glows briefly. It accepts nothing — not yet.");
                            return true;

                        case 'S':
                            if (!state.Choices.ContainsKey("StatuePuzzleSolved"))
                            {
                                UI.TypeText("Three broken statues float in the clouds, each whispering cryptic truths...");
                                UI.TypeText("One tells the truth, one lies, and one answers at random.");
                                UI.TypeText("Choose carefully.");

                                GuardianStatue[] statues = new GuardianStatue[3];
                                statues[0] = new TruthStatue();
                                statues[1] = new LiarStatue();
                                statues[2] = new RandomStatue();

                                Random rand = new Random();
                                for (int i = 0; i < statues.Length; i++)
                                {
                                    int swapIndex = rand.Next(i, statues.Length);
                                    var temp = statues[i];
                                    statues[i] = statues[swapIndex];
                                    statues[swapIndex] = temp;
                                }

                                Console.Write("Pick a statue (1, 2, or 3): ");
                                string input = Console.ReadLine().Trim();
                                if (int.TryParse(input, out int selected) && selected >= 1 && selected <= 3)
                                {
                                    UI.TypeText($"The statue says: \"{statues[selected - 1].Respond()}\"");
                                    Console.Write("Dig here? (yes/no): ");
                                    string digChoice = Console.ReadLine().Trim().ToLower();

                                    if (digChoice == "yes" && statues[selected - 1] is TruthStatue)
                                    {
                                        UI.TypeText("Beneath the clouds, you find a hidden artifact!");
                                        Console.Beep(1000, 200);
                                        Console.Beep(1200, 300);
                                        state.Inventory.AddItem("Celestial Relic");
                                        state.Choices["StatuePuzzleSolved"] = true;
                                    }
                                    else
                                    {
                                        UI.TypeText("You find nothing but mist.");
                                        Console.Beep(300, 300);
                                    }
                                }
                                else
                                {
                                    UI.TypeText("The statues remain silent, confused by your indecision.");
                                }
                            }
                            else
                            {
                                UI.TypeText("The statues are silent now.");
                            }
                            return true;

                        case 'R':
                            if (!ritualDone)
                            {
                                bool hasAll = true;
                                foreach (var item in offerings)
                                {
                                    if (!state.Inventory.HasItem(item)) hasAll = false;
                                }
                                if (hasAll)
                                {
                                    UI.TypeText("You place the offerings at the Celestial Altar. Light spirals upward.");
                                    Console.Beep(250, 200);
                                    Console.Beep(400, 200);
                                    Console.Beep(600, 200);
                                    Console.Beep(600, 600);
                                    UI.Pause();
                                    ritualDone = true;
                                }
                                else
                                {
                                    UI.TypeText("You are still missing pieces of the sky.");
                                }
                            }
                            else
                            {
                                UI.TypeText("The altar has accepted your gift. A void opens beyond.");
                            }
                            return true;

                        case 'T':
                            if (!glitchTriggered)
                            {
                                glitchTriggered = true;
                                UI.TypeText("You step onto unstable debris — and something glitches.", ConsoleColor.Red);
                                Console.Clear();
                                Console.ForegroundColor = ConsoleColor.DarkRed;
                                Console.WriteLine("▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒");
                                Console.Beep(1200, 50);
                                Console.Beep(300, 50);
                                Console.Beep(900, 50);
                                Console.Beep(400, 50);
                                Console.Beep(800, 200);
                                Console.ResetColor();
                                UI.TypeText("...System recovered.", ConsoleColor.Gray);
                                UI.Pause();
                            }
                            return true;

                        default:
                            return false;
                    }
                },
                () => ritualDone
            );

            UI.PrintDivider();
            UI.TypeText("Aborash awaits — cloaked in light, wreathed in memory.");
            UI.TypeText("'You have come far. But do you seek truth... or dominion?' he asks.");

            while (!finalDecisionMade)
            {
                Console.WriteLine("\n1. Demand power\n2. Ask for the truth");
                Console.Write("Your choice: ");
                string input = Console.ReadLine().Trim();

                if (input == "1")
                {
                    UI.TypeText("You raise your voice — but your power was never yours to claim.");
                    Console.Beep(400, 300);
                    Console.Beep(400, 300);
                    UI.TypeText("Aborash steps forward. 'This was never your fight.'");
                    UI.Pause();
                    finalDecisionMade = true;
                }
                else if (input == "2")
                {
                    UI.TypeText("You bow your head. 'Tell me everything.'");
                    Console.Beep(400, 300);
                    Console.Beep(400, 300);
                    UI.TypeText("Aborash smiles: 'Then you are ready.' The sky peels open.");
                    finalDecisionMade = true;
                }
                else
                {
                    UI.TypeText("Aborash waits for your answer.");
                }
            }

            UI.TypeText("The heavens tremble. A new era begins.");
            state.Act3Completed = true;
            UI.Pause();
        }

        abstract class GuardianStatue
        {
            public abstract string Respond();
        }

        class TruthStatue : GuardianStatue
        {
            public override string Respond()
            {
                return "The key is beneath my feet.";
            }
        }

        class LiarStatue : GuardianStatue
        {
            public override string Respond()
            {
                return "The key is not beneath my feet.";
            }
        }

        class RandomStatue : GuardianStatue
        {
            private Random random = new Random();
            public override string Respond()
            {
                return random.Next(0, 2) == 0 ? "The key is beneath my feet." : "The key is not beneath my feet.";
            }
        }
    }
}
