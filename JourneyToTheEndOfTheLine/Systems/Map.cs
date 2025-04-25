using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;

namespace JourneyToTheEndOfTheLine.Systems {
    public class Map {
        public char[,] Grid { get; private set; }
        public int Width => Grid.GetLength(1);
        public int Height => Grid.GetLength(0);
        public int PlayerX { get; set; }
        public int PlayerY { get; set; }

        public Map(char[,] grid, int startX, int startY) {
            Grid = grid;
            PlayerX = startX;
            PlayerY = startY;
        }

        public void Draw() {
            Console.Clear();
            for (int y = 0; y < Height; y++) {
                for (int x = 0; x < Width; x++) {
                    if (x == PlayerX && y == PlayerY) {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write("@");
                    } else {
                        Console.ForegroundColor = ConsoleColor.Gray;
                        Console.Write(GetTileSymbol(Grid[y, x]));
                    }
                }
                Console.WriteLine();
            }
            Console.ResetColor();
        }

        private string GetTileSymbol(char tile)
        {
            return tile switch
            {
                '#' => "█",   // Wall/Boundary
                'B' => "♣",   // Bush
                'W' => "≈",   // Whirlpool
                'C' => "☁",   // Cloud
                'T' => "!",   // Threat (Beastman or glitch tile)
                'R' => "⊙",   // Ritual zone
                'O' => "✦",   // Offering Site (Act 3)
                'K' => "⌂",   // Locked Gate
                'P' => "✉",   // Poem Puzzle
                'G' => "$",   // Gold Ingot
                'H' => "~",   // Heat Source
                'F' => "♨",   // Forge
                'L' => "✎",   // Lore Log
                'M' => "✶",   // Map Puzzle (Star)
                'X' => "⌂",   // Hidden tile
                _ => " "      // Empty space
            };
        }

        private ConsoleColor GetTileColor(char tile)
        {
            return tile switch
            {
                '#' => ConsoleColor.DarkGray,
                'B' => ConsoleColor.Green,
                'W' => ConsoleColor.Blue,
                'C' => ConsoleColor.White,
                'T' => ConsoleColor.Red,     
                'R' => ConsoleColor.Magenta,
                'O' => ConsoleColor.White,
                'K' => ConsoleColor.Gray,
                'P' => ConsoleColor.Magenta,
                'G' => ConsoleColor.Yellow,
                'H' => ConsoleColor.Red,
                'F' => ConsoleColor.Magenta,
                'L' => ConsoleColor.Gray,
                'M' => ConsoleColor.Cyan,
                'X' => ConsoleColor.DarkCyan,
                _ => ConsoleColor.White
            };
        }

        public bool Move(char direction) {
            int newX = PlayerX;
            int newY = PlayerY;

            switch (char.ToLower(direction)) {
                case 'w': newY--; break;
                case 's': newY++; break;
                case 'a': newX--; break;
                case 'd': newX++; break;
                default: return false;
            }

            if (newX >= 0 && newX < Width && newY >= 0 && newY < Height && Grid[newY, newX] != '#') {
                PlayerX = newX;
                PlayerY = newY;
                return true;
            }

            return false;
        }

        public char CurrentTile() => Grid[PlayerY, PlayerX];
    }
}
