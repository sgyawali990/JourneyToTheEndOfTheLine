using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Threading;

namespace JourneyToTheEndOfTheLine.Systems
{
    public static class UI
    {
        public static void TypeGlitchText(string text, int speed)
        {
            Random random = new Random();
            foreach (char c in text)
            {
                Console.Write(c);
                Thread.Sleep(speed);
            }
            Console.WriteLine();
        }

        public static void TypeText(string text, ConsoleColor color = ConsoleColor.White, int delay = 20)
        {
            var originalColor = Console.ForegroundColor;
            Console.ForegroundColor = color;

            foreach (char c in text)
            {
                Console.Write(c);
                Thread.Sleep(delay);
            }
            Console.WriteLine();

            Console.ForegroundColor = originalColor;
        }


        public static void DisplayTitle(string title)
        {
            try
            {
                Console.Clear();
            }
            catch (IOException)
            {
                Console.WriteLine("(Console clear not supported on this system.)");
            }

            Console.WriteLine("==============================");
            Console.WriteLine($"  {title.ToUpper()}");
            Console.WriteLine("==============================\n");
        }

        public static void PrintDivider()
        {
            Console.WriteLine("\n------------------------------\n");
        }

        public static void DisplayAscii(string fileName)
        {
            string path = Path.Combine("Assets", "ascii", fileName);
            if (File.Exists(path))
            {
                string art = File.ReadAllText(path);
                Console.WriteLine(art);
            }
            else
            {
                Console.WriteLine("[Missing ASCII Art: " + fileName + "]");
            }
        }

        public static void Pause()
        {
            Console.WriteLine("\nPress ENTER to continue...");
            Console.ReadLine();
        }
    }
}
