using System;
using JourneyToTheEndOfTheLine.Maps;
using JourneyToTheEndOfTheLine.Systems;

namespace JourneyToTheEndOfTheLine.Acts
{
    public static class Act2
    {
        public static void Play(GameState state)
        {
            Console.Clear();
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Loading Act II: The Storm at Sea...");
            Thread.Sleep(1000);
            Console.Clear();

            ActTransitions.Show("Act II: The Storm at Sea");

            UI.DisplayTitle("Act 2: The Storm at Sea");
            UI.TypeText($"{state.PlayerName}, you awaken aboard the Eternal Tide — a ghost ship adrift on endless waves.");
            UI.Pause();

            var map = Map_Sea.Generate();

            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
            Console.Clear();
            ShowMapLegend();

            Console.Clear();

            int cluesFound = 0;
            int totalCluesNeeded = 5;
            bool starRiddleSolved = false;
            bool sirenDealtWith = false;
            bool seaRitualComplete = false;
            bool sailorNoteRead = false;
            bool beastmanDefeated = false;
            bool canExit = false;

            MovementSystem.Run(map, state, (tile) =>
            {
                if (tile == '≈') // Water tile with possible clue
                {
                    if (cluesFound < totalCluesNeeded)
                    {
                        if (Random.Shared.Next(2) == 0)
                        {
                            cluesFound++;
                            map.SetTile(map.PlayerX, map.PlayerY, ' ');
                            UI.TypeText("You find a soaked relic clinging to the shipwreck.", ConsoleColor.Green);
                            Console.Beep(700, 200);

                            if (cluesFound >= totalCluesNeeded)
                            {
                                UI.TypeText("You've gathered enough relics to understand the ship's ritual.", ConsoleColor.Cyan);
                            }
                        }
                        else
                        {
                            UI.TypeText("Nothing but splinters and seawater.", ConsoleColor.Gray);
                        }
                    }
                    else
                    {
                        UI.TypeText("You've gathered all you need.", ConsoleColor.DarkGray);
                    }
                    return true;
                }
                else if (tile == 'R') // Ritual Stone - Star Riddle
                {
                    if (!starRiddleSolved)
                    {
                        Riddles.StarRiddle(ref starRiddleSolved);
                        Console.Beep(1000, 200);
                    }
                    else
                    {
                        UI.TypeText("The star glyphs shimmer faintly.", ConsoleColor.Gray);
                    }
                    return true;
                }
                else if (tile == 'F') // Sea Ritual Site
                {
                    if (starRiddleSolved && cluesFound >= totalCluesNeeded)
                    {
                        if (!seaRitualComplete)
                        {
                            UI.TypeText("You complete the Sea Ritual, binding your soul to the eternal tides.", ConsoleColor.Cyan);
                            seaRitualComplete = true;
                            Console.Beep(1200, 300);
                            canExit = true;
                        }
                        else
                        {
                            UI.TypeText("The ritual is already complete.", ConsoleColor.Gray);
                        }
                    }
                    else
                    {
                        UI.TypeText("You feel unworthy to perform the ritual yet.", ConsoleColor.Red);
                    }
                    return true;
                }
                else if (tile == 'S') // Siren Encounter
                {
                    if (!sirenDealtWith)
                    {
                        UI.TypeText("A Siren sings from the shattered mast, eyes gleaming with hunger.", ConsoleColor.Magenta);
                        Console.WriteLine("\nSpare her (S) or Strike her down (K)?");
                        var choice = Console.ReadKey(true).Key;
                        if (choice == ConsoleKey.S)
                        {
                            UI.TypeText("You show mercy. She fades into mist, her sorrow lingering.", ConsoleColor.Cyan);
                        }
                        else
                        {
                            UI.TypeText("You strike swiftly. Her wail pierces the storm as she vanishes.", ConsoleColor.Red);
                        }
                        sirenDealtWith = true;
                        Console.Beep(900, 200);
                        map.SetTile(map.PlayerX, map.PlayerY, ' ');
                    }
                    else
                    {
                        UI.TypeText("Only echoes remain where the Siren once sang.", ConsoleColor.Gray);
                    }
                    return true;
                }
                else if (tile == 'Q') // Tic-Tac-Toe Puzzle
                {
                    MiniGames.PlayTicTacToePuzzle();
                    map.SetTile(map.PlayerX, map.PlayerY, ' ');
                    return true;
                }
                else if (tile == 'Z') // Tarot Mini-Game
                {
                    MiniGames.PlayTarot();
                    map.SetTile(map.PlayerX, map.PlayerY, ' ');
                    return true;
                }
                else if (tile == 'P') // Sailor's Ghost Note
                {
                    if (!sailorNoteRead)
                    {
                        UI.TypeText("You find a tattered letter clinging to a rotted beam:", ConsoleColor.Yellow);
                        UI.TypeText("\"If you find this, know I never made it ashore. I pray the waves are kinder to you...\"");
                        sailorNoteRead = true;
                        Console.Beep(500, 200);
                    }
                    else
                    {
                        UI.TypeText("These words mean less than before... reading them again weakens their meaning.", ConsoleColor.DarkGray);
                    }
                    return true;
                }
                else if (tile == '!') // Beastman Threat
                {
                    if (!beastmanDefeated)
                    {
                        UI.TypeText("The Beastman emerges — faster, stronger than before!", ConsoleColor.Red);
                        Console.Beep(500, 400);

                        if (Random.Shared.Next(3) < 2)
                        {
                            UI.TypeText("The Beastman overpowers you! You awaken gasping by the broken mast...", ConsoleColor.Red);
                            Console.Beep(400, 400);
                            map.ResetPlayerPosition();
                        }
                        else
                        {
                            UI.TypeText("You dodge the Beastman's blow and it vanishes into mist.", ConsoleColor.Yellow);
                            beastmanDefeated = true;
                            map.SetTile(map.PlayerX, map.PlayerY, ' ');
                        }
                    }
                    else
                    {
                        UI.TypeText("The deck groans beneath invisible weight.", ConsoleColor.Gray);
                    }
                    return true;
                }

                return false;
            },
            () => canExit);

            state.Act2Completed = true;
        }

        private static void ShowMapLegend()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("≈ : Broken Deck / Water");

            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("R : Ritual Stone (Star Riddle)");

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("F : Sea Ritual Site (Final Puzzle)");

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("S : Siren Encounter");

            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("Q : Tic-Tac-Toe Puzzle");

            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("Z : Tarot Reading");

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("P : Sailor's Ghost Note");

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("! : Beastman Threat");

            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("# : Hull Walls");

            Console.ResetColor();
        }
    }
}