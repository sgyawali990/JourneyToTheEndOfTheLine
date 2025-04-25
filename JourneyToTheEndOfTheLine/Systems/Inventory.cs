using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JourneyToTheEndOfTheLine.Systems
{
    public class Inventory
    {
        public int ItemCount => items.Count;
        private List<string> items = new List<string>();

        public void AddItem(string item)
        {
            if (!items.Contains(item))
            {
                items.Add(item);
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"\n[+] You have acquired: {item}");
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.WriteLine($"\n[!] You already have the {item}.");
                Console.ResetColor();
            }
        }

        public void RemoveItem(string item)
        {
            if (items.Contains(item))
            {
                items.Remove(item);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"\n[-] {item} removed from inventory.");
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.WriteLine($"\n[!] {item} is not in your inventory.");
                Console.ResetColor();
            }
        }

        public bool HasItem(string item)
        {
            return items.Contains(item);
        }

        public void ShowInventory()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("\n== Inventory ==");

            if (items.Count == 0)
            {
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.WriteLine(" - (empty)");
            }
            else
            {
                foreach (var item in items)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($" - {item}");
                }
            }
            Console.ResetColor();
        }
    }
}