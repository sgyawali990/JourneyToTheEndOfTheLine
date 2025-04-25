using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JourneyToTheEndOfTheLine.Maps;
using JourneyToTheEndOfTheLine.Systems;

namespace JourneyToTheEndOfTheLine.Acts
{
    public static class Act2
    {
        private static void ShowMapLegend()
        {
            Console.WriteLine("\n== Map Legend ==");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("≈ : Whirlpool (Searchable Clue)");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("! : Siren Encounter");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("✎ : Captain’s Log");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("✶ : Star Chart Puzzle");
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("⊙ : Glyph Ritual Site");
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("⌂ : Hidden Room");
            Console.ResetColor();
            UI.Pause();
        }

        public static void Start(GameState state)
        {
            ActTransitions.Show("Act II: The Storm at Sea");

            UI.DisplayTitle("Act 2: The Storm at Sea");
            UI.TypeText($"{state.PlayerName}, you step onto the Eternal Tide — a ghostly ship guided by forgotten winds.");
            UI.Pause();

            var map = Map_Sea.Generate();
            ShowMapLegend();
            int cluesFound = 0;
            int totalClues = 3;
            bool sirenEncountered = false;
            bool starPuzzleSolved = false;
            bool ritualComplete = false;

            MovementSystem.Run(
                map,
                state,
                (tile) => {
                    switch (tile)
                    {
                        case 'W':
                            if (new Random().NextDouble() < 0.5 && cluesFound < totalClues)
                            {
                                string clue = $"Sea Clue {cluesFound + 1}";
                                if (!state.Inventory.HasItem(clue))
                                {
                                    state.Inventory.AddItem(clue);
                                    cluesFound++;
                                    UI.TypeText($"The whirlpool reveals a fragment of truth: {clue}.", ConsoleColor.Green);
                                    Console.Beep(600, 150);
                                    Console.Beep(800, 150);
                                }
                                else
                                {
                                    UI.TypeText("You sense something, but find nothing new.", ConsoleColor.DarkGray);
                                }
                            }
                            else
                            {
                                UI.TypeText("The waters churn, but remain silent.", ConsoleColor.Red);
                                Console.Beep(500, 200);
                                Console.Beep(300, 300);
                            }
                            return true;

                        case 'S':
                            if (!sirenEncountered)
                            {
                                UI.TypeText("A siren emerges from the storm: \"Spare my sisters, and I shall calm the sea.\"");
                                Console.Write("Accept her deal? (yes/no): ");
                                string choice = Console.ReadLine().Trim().ToLower();
                                if (choice == "yes")
                                {
                                    state.Choices["SparedSiren"] = true;
                                    UI.TypeText("The siren smiles and vanishes. The waves settle.", ConsoleColor.Green);
                                    Console.Beep(700, 100);
                                    Console.Beep(950, 300);
                                    UI.Pause();
                                }
                                else
                                {
                                    state.Choices["SparedSiren"] = false;
                                    UI.TypeText("The siren wails and sinks beneath the waves. The storm rages on.", ConsoleColor.Red);
                                    Console.Beep(700, 100);
                                    Console.Beep(950, 300);
                                    UI.Pause();
                                }
                                sirenEncountered = true;
                            }
                            else
                            {
                                UI.TypeText("The waters remember your choice.", ConsoleColor.DarkGray);
                                UI.Pause();
                            }
                            return true;

                        case 'L':
                            UI.TypeText("You find the captain’s log: \"We sail for the sky, but the sea watches always.\"", ConsoleColor.Gray);
                            return true;

                        case 'M':
                            if (!starPuzzleSolved)
                            {
                                UI.TypeText("A chart of constellations appears: \"First of fire, last of light, the twin’s middle marks the night.\"");
                                while (true)
                                {
                                    Console.Write("Name the guiding star: ");
                                    if (Console.ReadLine().Trim().ToLower() == "pollux") break;
                                    UI.TypeText("The stars remain silent.", ConsoleColor.Red);
                                }
                                UI.TypeText("The sky responds. The path is clear.", ConsoleColor.Green);
                                Console.Beep(600, 150);
                                Console.Beep(800, 150);
                                UI.Pause();
                                starPuzzleSolved = true;
                            }
                            else
                            {
                                UI.TypeText("The stars are already aligned.", ConsoleColor.DarkGray);
                            }
                            return true;

                        case 'C':
                            if (!ritualComplete)
                            {
                                UI.TypeText("Glyphs glow: SUN | MOON | SEA");
                                Console.Write("Choose your glyph: ");
                                string input = Console.ReadLine().Trim().ToLower();
                                if (input == "sea")
                                {
                                    if (state.Choices.ContainsKey("SparedSiren") && state.Choices["SparedSiren"])
                                    {
                                        UI.TypeText("The waters part with respect for your mercy.", ConsoleColor.Green);
                                        Console.Beep(250, 200);
                                        Console.Beep(400, 200);
                                        Console.Beep(600, 200);
                                        Console.Beep(600, 600);

                                    }
                                    else
                                    {
                                        UI.TypeText("The sea accepts your defiance. You pass.", ConsoleColor.Green);
                                        UI.Pause();   
                                    }
                                    ritualComplete = true;
                                }
                                else
                                {
                                    UI.TypeText("The glyph fades. That was not the one.", ConsoleColor.Red);
                                }
                            }
                            else
                            {
                                UI.TypeText("The ritual has already been completed.", ConsoleColor.DarkGray);
                            }
                            return true;

                        case 'X':
                            UI.TypeText("You drift into a silent pocket of the sea. Whispers brush your mind: 'Not all voyages end where they begin.'", ConsoleColor.Gray);
                            return true;

                        default:
                            return false;
                    }
                },
                () => ritualComplete && cluesFound >= totalClues && starPuzzleSolved
            );

            UI.TypeText("The ship sails beyond the horizon, into the skies. Your journey is far from—", ConsoleColor.Gray);
            UI.Pause();
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkRed;

            Console.WriteLine("[ERR] Memory Access Violation @ 0x002FFAA3");
            Console.WriteLine("[SYS] Attempting recovery sequence...");
            Console.WriteLine("[DBG] Invalid pointer dereferenced");
            Console.WriteLine("[DBG] Core module integrity: 67%");
            Console.WriteLine("[SYS] Personality core corrupted: " + state.PlayerName.Reverse().ToArray());
            Console.WriteLine("[SYS] Reconstructing...");
            Thread.Sleep(2500);
            Console.ResetColor();
            Console.Beep(1200, 50);
            Console.Beep(300, 50);
            Console.Beep(900, 50);
            Console.Beep(400, 50);
            Console.Beep(800, 200);
            Console.Clear();

            UI.TypeText("The ship sails beyond the horizon, into the skies. Your journey is far from over.", ConsoleColor.Green);

            state.Act2Completed = true;
            UI.Pause();
        }
    }
}