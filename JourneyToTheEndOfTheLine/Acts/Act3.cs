using System;
using JourneyToTheEndOfTheLine.Maps;
using JourneyToTheEndOfTheLine.Systems;

namespace JourneyToTheEndOfTheLine.Acts
{
    public static class Act3
    {
        public static void Play(GameState state)
        {
            Console.Clear();
            Console.BackgroundColor = ConsoleColor.DarkGray;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Loading Act III: The Celestial Ascent...");
            Thread.Sleep(1000);
            Console.Clear();

            ActTransitions.Show("Act III: The Celestial Ascent");

            UI.DisplayTitle("Act 3: The Celestial Ascent");
            UI.TypeText($"{state.PlayerName}, you step onto the shattered remains of a forgotten sky.");
            UI.Pause();

            var map = Map_Sky.Generate();

            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
            Console.Clear();
            ShowMapLegend();
            Console.Clear();

            int cluesFound = 0;
            const int totalCluesNeeded = 4;
            bool beastmanKilled = false;
            bool aborashAppeared = false;
            bool finalChoiceMade = false;
            bool canExit = false;
            bool glitchTriggered = false;

            MovementSystem.Run(map, state, (tile) =>
            {
                if (tile == '*') // Broken Star Fragment
                {
                    if (cluesFound < totalCluesNeeded)
                    {
                        cluesFound++;
                        UI.TypeText("You collect a shimmering fragment of a fallen star.", ConsoleColor.Cyan);
                        Console.Beep(800, 200);
                        map.SetTile(map.PlayerX, map.PlayerY, ' ');

                        if (cluesFound == totalCluesNeeded)
                        {
                            UI.TypeText("\nThe fragments pulse in your hands... something has changed.", ConsoleColor.Magenta);
                        }
                    }
                    else
                    {
                        UI.TypeText("The stars no longer respond to your touch.", ConsoleColor.DarkGray);
                    }
                    return true;
                }
                else if (tile == 'L') // Lost Temple Writing
                {
                    UI.TypeText("The ancient writings hum:\n\"Ascend or fall, the choice is yours.\"", ConsoleColor.Gray);
                    map.SetTile(map.PlayerX, map.PlayerY, ' ');
                    return true;
                }
                else if (tile == 'R') // Ritual Site - Glitch trigger
                {
                    if (!glitchTriggered)
                    {
                        TriggerGlitchSequence();
                        glitchTriggered = true;
                    }
                    else
                    {
                        UI.TypeText("The rift still pulses faintly.", ConsoleColor.DarkGray);
                    }
                    return true;
                }
                else if (tile == 'T') // Final Decision Place
                {
                    if (!finalChoiceMade)
                    {
                        AborashSequence(state);
                        finalChoiceMade = true;
                        canExit = true;
                    }
                    else
                    {
                        UI.TypeText("The shattered statues whisper silently.", ConsoleColor.Gray);
                    }
                    return true;
                }
                else if (tile == '!') // Beastman Encounter
                {
                    if (!beastmanKilled)
                    {
                        UI.TypeText("The Beastman lunges from the clouds—", ConsoleColor.Red);
                        Thread.Sleep(500);
                        UI.TypeGlitchText(" A blade of pure blackness cleaves him in two.", 30);
                        Thread.Sleep(700);
                        UI.TypeText("\nA figure cloaked in twilight steps forward...", ConsoleColor.Magenta);
                        Console.Beep(700, 300);
                        beastmanKilled = true;
                        aborashAppeared = true;
                        map.SetTile(map.PlayerX, map.PlayerY, ' ');
                    }
                    return true;
                }

                return false;
            },
            () => canExit);

            state.Act3Completed = true;
        }

        private static void AborashSequence(GameState state)
        {
            Console.Clear();
            UI.DisplayTitle("Aborash");
            UI.TypeText("The figure speaks, voice dripping with mockery:\n", ConsoleColor.Magenta);
            UI.TypeText("\"You think yourself the hero of this world...\"");
            Thread.Sleep(1000);
            UI.TypeText("\"You are nothing but a puppet. Strings pulled by beings you cannot comprehend.\"");
            Thread.Sleep(1000);

            Console.WriteLine("\nDo you choose to:");
            Console.WriteLine("[T] Learn the truth");
            Console.WriteLine("[F] Fight Aborash");
            Console.Write("\nChoice: ");
            var choice = Console.ReadKey(true).Key;

            if (choice == ConsoleKey.T)
            {
                LearnTheTruth();
            }
            else if (choice == ConsoleKey.F)
            {
                FightAborash();
            }
            else
            {
                UI.TypeText("\nFrozen by fear, your soul fractures anyway...", ConsoleColor.Red);
                LearnTheTruth();
            }
        }

        private static void LearnTheTruth()
        {
            Console.Clear();
            UI.TypeGlitchText("REVEALING... REVEALING... REVEALING...", 40);
            Thread.Sleep(500);

            UI.TypeGlitchText("YOU ARE NOT REAL.", 30);
            UI.TypeGlitchText("YOU ARE BEING CONTROLLED.", 30);
            UI.TypeGlitchText("SOMEONE OUTSIDE THIS WORLD IS PLAYING YOU.", 30);
            Thread.Sleep(1000);

            UI.TypeGlitchText("WHO ARE THEY?", 50);
            UI.TypeGlitchText("WHAT ARE YOU?", 50);
            Thread.Sleep(500);

            Console.Clear();
            UI.TypeText("The sky falls apart.\nYour name... your journey... your memories... all lies.", ConsoleColor.Red);
            Thread.Sleep(1500);

            Console.Clear();
            UI.TypeText("And yet...\nYou still endure.", ConsoleColor.Cyan);
            Thread.Sleep(1000);

            UI.TypeText("\n[You survived the truth.]", ConsoleColor.Green);
            UI.Pause();
        }

        private static void FightAborash()
        {
            Console.Clear();
            UI.DisplayTitle("Battle Against Aborash");

            int attackCount = 0;
            const int maxAttacks = 100;

            while (attackCount < maxAttacks)
            {
                if (Console.KeyAvailable)
                {
                    var key = Console.ReadKey(true).Key;
                    if (key == ConsoleKey.D)
                    {
                        UI.TypeText("\n(Developer skip activated!)", ConsoleColor.Yellow);
                        break; // Exit the loop early
                    }
                }

                UI.TypeText("You strike Aborash...");
                Thread.Sleep(200);
                UI.TypeText("He reforms instantly, laughing in your face.");
                Thread.Sleep(300);
                attackCount++;
            }

            Console.Clear();
            UI.TypeText("You fall to your knees. The futility becomes overwhelming...", ConsoleColor.Red);
            Thread.Sleep(1500);
            UI.TypeText("\nAborash: \"You cannot defeat what you refuse to understand.\"", ConsoleColor.Magenta);
            UI.Pause();
        }

        private static void TriggerGlitchSequence()
        {
            Console.Clear();
            UI.TypeGlitchText("SYSTEM FAILURE. DATA CORRUPTION.", 30);
            Thread.Sleep(500);
            UI.TypeGlitchText("RECOVERING LOST FILES...", 25);
            Thread.Sleep(700);
            UI.TypeGlitchText("VERIFYING USER AUTHENTICATION.", 20);

            Console.WriteLine("\nEnter your Social Security Number (format: ###-##-####):");
            Console.Write("\nInput: ");
            string fakeInput = Console.ReadLine();
            Console.WriteLine("\nVerifying...");
            Thread.Sleep(1500);

            UI.TypeGlitchText("IDENTITY ACCEPTED.", 30);
            Thread.Sleep(500);
            Console.Clear();
        }

        private static void ShowMapLegend()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("* : Broken Star Fragment (clues)");

            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("L : Lost Temple Writing (lore)");

            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("R : Ritual Stone (Glitch trigger)");

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("T : Truth/Power Statues (Final Choice)");

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("! : Beastman Threat");

            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("# : Edge of the Broken Sky");

            Console.ResetColor();
        }
    }
}