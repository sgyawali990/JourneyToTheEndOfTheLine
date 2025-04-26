using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace JourneyToTheEndOfTheLine.Systems
{
    public static class TitleScreen
    {
        public static void Show()
        {
            try
            {
                Console.Clear();
            }
            catch (IOException)
            {
                Console.WriteLine("(Console clear not supported on this system.)");
            }

            Console.ForegroundColor = ConsoleColor.Gray;

            string[] baseLines = new string[]
            {
                "Journey",
                "to",
                "the",
                "End",
                "of",
                "the",
                "Line"
            };

            foreach (var baseLine in baseLines)
            {
                string stretched = StretchText(baseLine, 7);
                foreach (char c in stretched)
                {
                    Console.Write(c);
                    Thread.Sleep(4);
                }
                Console.WriteLine();
                Thread.Sleep(80);
            }

            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("Created by:");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("Alex W.");
            Console.WriteLine("Sirjan G.");
            Console.WriteLine("Richmond A.");
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("[Press ENTER to begin your descent...]");
            Console.ResetColor();
            Console.ReadLine();
        }

        private static string StretchText(string text, int repeatPerLetter)
        {
            Random rand = new Random();
            StringBuilder sb = new StringBuilder();
            foreach (char c in text)
            {
                for (int i = 0; i < repeatPerLetter; i++)
                {
                    char randomized = rand.NextDouble() < 0.5 ? char.ToLower(c) : char.ToUpper(c);
                    sb.Append(randomized);
                }
            }
            return sb.ToString();
        }
    }
}