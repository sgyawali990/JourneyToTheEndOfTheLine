using System;
using JourneyToTheEndOfTheLine.Maps;
using JourneyToTheEndOfTheLine.Systems;

namespace JourneyToTheEndOfTheLine.Acts
{
    public static class Act1
    {
        public static void Play(GameState state)
        {
            Console.Clear();
            Console.BackgroundColor = ConsoleColor.DarkGreen;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Loading Act I: The Forest of Tusks...");
            Thread.Sleep(1000);
            Console.Clear();

            ActTransitions.Show("Act I: The Forest of Tusks");

            UI.DisplayTitle("Act 1: The Forest of Tusks");
            UI.TypeText($"{state.PlayerName}, you step into the haunted groves where tusk-trees pierce the sky...");
            UI.Pause();

            var map = Map_Forest.Generate();

            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
            Console.Clear();
            ShowMapLegend();

            Console.Clear();

            int cluesFound = 0;
            int totalCluesNeeded = 3;
            bool fireRiddleSolved = false;
            bool keyForged = false;
            bool poemSolved = false;
            bool beastmanDefeated = false;
            bool canExit = false;

            MovementSystem.Run(map, state, (tile) =>
            {
                if (tile == 'B') // Bush Clues
                {
                    if (cluesFound < totalCluesNeeded)
                    {
                        if (Random.Shared.Next(2) == 0)
                        {
                            cluesFound++;
                            map.SetTile(map.PlayerX, map.PlayerY, ' ');
                            UI.TypeText("You found a material hidden in the bushes!", ConsoleColor.Green);
                            Console.Beep(800, 200);

                            if (cluesFound >= totalCluesNeeded)
                            {
                                UI.TypeText("You have gathered enough materials to forge something...", ConsoleColor.Cyan);
                            }
                        }
                        else
                        {
                            UI.TypeText("Only withered leaves scatter at your touch.", ConsoleColor.Gray);
                        }
                    }
                    else
                    {
                        UI.TypeText("You search, but find nothing more of value.", ConsoleColor.DarkGray);
                    }
                    return true;
                }
                else if (tile == 'R') // Ritual Stone - Fire Riddle
                {
                    if (!fireRiddleSolved)
                    {
                        Riddles.FireRiddle(ref fireRiddleSolved);
                        Console.Beep(1000, 200);
                    }
                    else
                    {
                        UI.TypeText("The flames have already whispered their truths.", ConsoleColor.Gray);
                    }
                    return true;
                }
                else if (tile == 'F') // Forge
                {
                    if (fireRiddleSolved && cluesFound >= totalCluesNeeded)
                    {
                        if (!keyForged)
                        {
                            UI.TypeText("You carefully forge a glowing Golden Key from your gathered materials.", ConsoleColor.Yellow);
                            state.Inventory.AddItem("Golden Key");
                            keyForged = true;
                            map.SetTile(map.PlayerX, map.PlayerY, ' '); // Forge becomes inactive
                            Console.Beep(900, 300);
                        }
                        else
                        {
                            UI.TypeText("The forge lies dormant, its work complete.", ConsoleColor.Gray);
                        }
                    }
                    else
                    {
                        UI.TypeText("The forge refuses your incomplete offerings.", ConsoleColor.Red);
                    }
                    return true;
                }
                else if (tile == 'P') // Poem Puzzle
                {
                    if (!poemSolved)
                    {
                        Puzzles.PoemPuzzle(ref poemSolved);
                        Console.Beep(1200, 250);
                    }
                    else
                    {
                        UI.TypeText("The ancient poems have nothing more to teach you.", ConsoleColor.Gray);
                    }
                    return true;
                }
                else if (tile == 'K') // Locked Gate
                {
                    if (state.Inventory.HasItem("Golden Key") && poemSolved)
                    {
                        UI.TypeText("You unlock the ancient gate with your Golden Key and whispered word.", ConsoleColor.Cyan);
                        Console.Beep(1500, 400);
                        canExit = true;
                    }
                    else
                    {
                        UI.TypeText("The gate remains shut. You feel you are missing something...", ConsoleColor.Red);
                    }
                    return true;
                }
                else if (tile == '!') // Beastman
                {
                    if (!beastmanDefeated)
                    {
                        UI.TypeText("A feral Beastman lunges from the shadows!", ConsoleColor.Red);
                        Console.Beep(300, 400);

                        if (Random.Shared.Next(2) == 0)
                        {
                            UI.TypeText("The Beastman slams you down! You awaken at the forest entrance...", ConsoleColor.Red);
                            Console.Beep(250, 400);
                            map.ResetPlayerPosition();
                        }
                        else
                        {
                            UI.TypeText("You narrowly dodge the Beastman's strike. It vanishes into the mist...", ConsoleColor.Yellow);
                            beastmanDefeated = true;
                            map.SetTile(map.PlayerX, map.PlayerY, ' ');
                        }
                    }
                    else
                    {
                        UI.TypeText("The ruins echo with distant growls.", ConsoleColor.Gray);
                    }
                    return true;
                }

                return false;
            },
            () => canExit);

            state.Act1Completed = true;
        }

        private static void ShowMapLegend()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("B : Bush (Search for clues)");

            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("R : Ritual Stone (Solve Fire Riddle)");

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("F : Forge (Create Golden Key)");

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("P : Poem Puzzle");

            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("K : Locked Gate (Exit)");

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("! : Beastman Threat");

            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("# : Wall");

            Console.ResetColor();
        }
    }
}