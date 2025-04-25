using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace JourneyToTheEndOfTheLine.Systems
{
    public static class ActTransitions
    {
        public static void Show(string actTitle)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Gray;

            string border = new string('-', actTitle.Length + 10);
            Console.WriteLine("\n\n");
            Console.WriteLine("     " + border);
            Console.WriteLine($"     -- {actTitle.ToUpper()} --");
            Console.WriteLine("     " + border);

            Console.ResetColor();
            Thread.Sleep(1000);
            UI.Pause();
        }
    }
}

