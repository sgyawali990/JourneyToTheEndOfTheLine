using System;

namespace JourneyToTheEndOfTheLine.Systems
{
    public class Map
    {
        public char[,] Grid { get; private set; }
        public int Width => Grid.GetLength(1);
        public int Height => Grid.GetLength(0);
        public int PlayerX { get; set; }
        public int PlayerY { get; set; }

        private int StartX;
        private int StartY;

        public Map(char[,] grid, int startX, int startY)
        {
            Grid = grid;
            PlayerX = startX;
            PlayerY = startY;
            StartX = startX;
            StartY = startY;
        }

        public void SetTile(int x, int y, char newTile)
        {
            if (x >= 0 && x < Width && y >= 0 && y < Height)
            {
                Grid[y, x] = newTile;
            }
        }
        public void ResetPlayerPosition()
        {
            PlayerX = StartX;
            PlayerY = StartY;
        }

        public void Draw()
        {
            Console.SetCursorPosition(0, 0); 

            for (int y = 0; y < Height; y++)
            {
                for (int x = 0; x < Width; x++)
                {
                    if (x == PlayerX && y == PlayerY)
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write("§"); // Player Icon
                    }
                    else
                    {
                        Console.ForegroundColor = GetTileColor(Grid[y, x]);
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
                '#' => "▩", // Wall
                '≈' => "≈", // Broken Deck / Water
                'B' => "♣", // Bush
                'W' => "≈", // Water (other)
                'C' => "☁", // Cloud
                'T' => "♣", // Tree
                'R' => "⊙", // Ritual Stone
                'O' => "✦", // Shrine Piece
                'K' => "⌂", // Locked Gate
                'P' => "✉", // Poem
                'G' => "$", // Gold
                'H' => "~", // Heat Source
                'F' => "♨", // Forge / Ritual Site
                'L' => "✎", // Lore
                'M' => "✶", // Star Puzzle
                'X' => "⌂", // Hidden Room
                'Q' => "☼", // Tic-Tac-Toe
                'Z' => "☽", // Tarot
                'S' => "♒", // Siren Encounter
                '!' => "!", // Beastman
                ' ' => " ", // Empty
                _ => "?"   // Fallback
            };
        }

        private ConsoleColor GetTileColor(char tile)
        {
            return tile switch
            {
                '#' => ConsoleColor.DarkGray,
                'B' => ConsoleColor.Green,
                'W' => ConsoleColor.Cyan,
                'C' => ConsoleColor.White,
                'T' => ConsoleColor.Red,
                'R' => ConsoleColor.Magenta,
                'O' => ConsoleColor.Magenta,
                'K' => ConsoleColor.Gray,
                'P' => ConsoleColor.Magenta,
                'G' => ConsoleColor.Yellow,
                'H' => ConsoleColor.Red,
                'F' => ConsoleColor.Magenta,
                'L' => ConsoleColor.Gray,
                'M' => ConsoleColor.Cyan,
                'X' => ConsoleColor.DarkCyan,
                'Q' => ConsoleColor.Cyan,
                'Z' => ConsoleColor.Cyan,
                ' ' => ConsoleColor.Gray,
                _ => ConsoleColor.DarkGray
            };
        }

        public bool Move(char direction)
        {
            int newX = PlayerX;
            int newY = PlayerY;

            switch (char.ToLower(direction))
            {
                case 'w': newY--; break;
                case 's': newY++; break;
                case 'a': newX--; break;
                case 'd': newX++; break;
                default: return false;
            }

            if (newX >= 0 && newX < Width && newY >= 0 && newY < Height && Grid[newY, newX] != '#')
            {
                PlayerX = newX;
                PlayerY = newY;
                return true;
            }

            return false;
        }

        public char CurrentTile() => Grid[PlayerY, PlayerX];
    }
}
