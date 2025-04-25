using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace JourneyToTheEndOfTheLine.Systems
{
    public static class PostCreditScene
    {
        public static void Show()
        {
            Console.Clear();
            Thread.Sleep(1500);

            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("\n\n>> SYSTEM MESSAGE: Reconnection Detected <<");
            Thread.Sleep(1500);
            Console.WriteLine("\nInitializing link to fragmented node...");
            Thread.Sleep(2000);
            Console.WriteLine("\nRecovered Message:\n");
            Thread.Sleep(1000);

            Console.ForegroundColor = ConsoleColor.Gray;
            string[] hidden = new string[] {
                "  They thought it ended.",
                "  They never reached the core.",
                "  The cycle will begin again.",
                "  This time, it won't be observed.",
                "  This time, the line breaks."
            };

            foreach (var line in hidden)
            {
                Console.WriteLine(line);
                Thread.Sleep(1600);
            }

            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("\n\n// CONNECTION LOST //");
            Console.ResetColor();
            Console.WriteLine("\nPress ENTER to terminate.");
            Console.ReadLine();
        }
    }
}
