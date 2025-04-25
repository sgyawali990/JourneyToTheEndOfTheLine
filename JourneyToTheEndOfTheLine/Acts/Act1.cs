using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JourneyToTheEndOfTheLine.Systems;
using JourneyToTheEndOfTheLine.Maps;

namespace JourneyToTheEndOfTheLine.Acts
{
    public static class Act1
    {
        private static void ShowMapLegend()
        {
            Console.WriteLine("\n== Map Legend ==");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("♣ : Bush (Searchable Clue)");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("! : Threat / Beastman");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("$ : Gold Ingot");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("~ : Heat Source");
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("⊙ : Riddle Stone");
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("⧫ : Forge Site");
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("✉ : Poem Puzzle");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("⌂ : Locked Gate");
            Console.ResetColor();

            UI.Pause();
        }

        public static void Start(GameState state)
        {
            ActTransitions.Show("Act I: The Forest of Tusks");

            UI.DisplayTitle("Act 1: The Forest of Tusks");
            UI.TypeText($"{state.PlayerName}, you arrive at the edge of the Forest of Tusks. The trees whisper, and old spirits stir.");
            UI.Pause();

            var map = Map_Forest.Generate();
            ShowMapLegend();
            int cluesFound = 0;
            int totalClues = 3;
            bool keyForged = false;
            bool fireRiddleSolved = false;
            bool finalPoemSolved = false;

            MovementSystem.Run(
                map,
                state,
                (tile) => {
                    switch (tile)
                    {
                        case 'B':
                            if (new Random().NextDouble() < 0.5)
                            {
                                string clue = $"Forest Clue {cluesFound + 1}";
                                if (!state.Inventory.HasItem(clue))
                                {
                                    state.Inventory.AddItem(clue);
                                    cluesFound++;
                                    UI.TypeText($"You found a clue hidden in the bush: {clue}.", ConsoleColor.Green);
                                    Console.Beep(600, 150);
                                    Console.Beep(800, 150);
                                    return true;
                                }
                                else
                                {
                                    UI.TypeText("You’ve already found this clue.", ConsoleColor.DarkGray);
                                }
                            }
                            else
                            {
                                UI.TypeText("You search the bush but find nothing.", ConsoleColor.Red);
                                Console.Beep(500, 200);
                                Console.Beep(300, 300);
                            }
                            return true;
                        case 'G':
                            if (!state.Inventory.HasItem("Gold Ingot"))
                            {
                                state.Inventory.AddItem("Gold Ingot");
                                UI.TypeText("You found a Gold Ingot!", ConsoleColor.Green);
                            }
                            else
                            {
                                UI.TypeText("You've already taken the Gold Ingot from here.", ConsoleColor.DarkGray);
                            }
                            return true;
                        case 'C':
                            if (!state.Inventory.HasItem("Crucible"))
                            {
                                state.Inventory.AddItem("Crucible");
                                UI.TypeText("You found a Crucible!", ConsoleColor.Green);
                            }
                            else
                            {
                                UI.TypeText("You already have a Crucible.", ConsoleColor.DarkGray);
                            }
                            return true;
                        case 'H':
                            if (!state.Inventory.HasItem("Heat Source"))
                            {
                                state.Inventory.AddItem("Heat Source");
                                UI.TypeText("You found a Heat Source!", ConsoleColor.Green);
                            }
                            else
                            {
                                UI.TypeText("You already have a Heat Source.", ConsoleColor.DarkGray);
                            }
                            return true;
                        case 'K':
                            if (state.Inventory.HasItem("Golden Key"))
                            {
                                UI.TypeText("You unlock the gate with the Golden Key.", ConsoleColor.Green);
                            }
                            else
                            {
                                UI.TypeText("You need to forge the Golden Key first.", ConsoleColor.Red);
                                Console.Beep(200, 100);
                            }
                            return true;
                        case 'R':
                            if (!fireRiddleSolved)
                            {
                                UI.TypeText("A stone tablet blocks your path. It reads:\n\"I consume all in my path, yet bring warmth to those in need. What am I?\"");
                                while (true)
                                {
                                    Console.Write("Your answer: ");
                                    string answer = Console.ReadLine().Trim().ToLower();
                                    if (answer == "fire") break;
                                    UI.TypeText("The stone remains lifeless. Try again.", ConsoleColor.Red);
                                }
                                UI.TypeText("The stone glows. Flames ignite a path through the woods.", ConsoleColor.Green);
                                Console.Beep(600, 150);
                                Console.Beep(800, 150);
                                UI.Pause();
                                fireRiddleSolved = true;
                            }
                            else
                            {
                                UI.TypeText("The riddle stone is already lit.", ConsoleColor.DarkGray);
                            }
                            return true;
                        case 'F':
                            if (!keyForged &&
                                state.Inventory.HasItem("Gold Ingot") &&
                                state.Inventory.HasItem("Crucible") &&
                                state.Inventory.HasItem("Heat Source"))
                            {
                                UI.TypeText("You have all materials. Forge the Golden Key? (yes/no)");
                                if (Console.ReadLine().Trim().ToLower() == "yes")
                                {
                                    state.Inventory.RemoveItem("Gold Ingot");
                                    state.Inventory.RemoveItem("Crucible");
                                    state.Inventory.RemoveItem("Heat Source");
                                    state.Inventory.AddItem("Golden Key");
                                    keyForged = true;
                                    UI.TypeText("You forge the Golden Key!", ConsoleColor.Green);
                                    Console.Beep(700, 100);
                                    Console.Beep(950, 300);
                                    UI.Pause();
                                }

                                else
                                {
                                    UI.TypeText("You decide to wait.", ConsoleColor.DarkGray);
                                }
                            }
                            else if (keyForged)
                            {
                                UI.TypeText("You've already forged the Golden Key.", ConsoleColor.DarkGray);
                            }
                            else
                            {
                                UI.TypeText("You don't have all the materials to forge the key.", ConsoleColor.Red);
                            }
                            return true;
                        case 'P':
                            if (!finalPoemSolved)
                            {
                                UI.TypeText("A riddle is carved:\n\"Once the gate stands cold and still,\n  deeP within the shadows' will.\n  thE darkened path holds yet the key,\n  oNly the brave may set it free.\"");
                                while (true)
                                {
                                    Console.Write("Speak the word: ");
                                    if (Console.ReadLine().Trim().ToLower() == "open") break;
                                    UI.TypeText("Nothing happens...", ConsoleColor.Red);
                                }
                                UI.TypeText("The stone gate unlocks with a deep rumble. You step into the dark.", ConsoleColor.Green);
                                Console.Beep(250, 200);
                                Console.Beep(400, 200);
                                Console.Beep(600, 200);
                                Console.Beep(600, 600);
                                UI.Pause();
                                finalPoemSolved = true;
                            }
                            else
                            {
                                UI.TypeText("The stone gate has already been opened.", ConsoleColor.DarkGray);
                            }
                            return true;

                        case 'T':
                            UI.TypeText("A beastman lunges from the shadows!", ConsoleColor.Red);
                            UI.TypeText("Instinct takes over — you dodge, and the creature flees into the forest.", ConsoleColor.Gray);
                            UI.Pause();
                            return true;

                        default:
                            return false;
                    }
                },
                () => fireRiddleSolved && keyForged && finalPoemSolved && cluesFound >= totalClues
            );

            UI.TypeText("You emerge from the forest — changed. The trees whisper their farewell.");
            state.Act1Completed = true;
            UI.Pause();
        }
    }
}

