using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JourneyToTheEndOfTheLine.Systems;

namespace JourneyToTheEndOfTheLine.Maps
{
    public static class Map_Sea
    {
        public static Map Generate()
        {
            char[,] grid = new char[,] {
                { '#', '#', '#', '#', '#', '#', '#', '#', '#', '#' },
                { '#', ' ', 'W', ' ', 'S', ' ', ' ', 'W', ' ', '#' },
                { '#', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '#' },
                { '#', 'L', ' ', ' ', 'M', ' ', ' ', ' ', 'Q', '#' },
                { '#', ' ', ' ', ' ', ' ', ' ', ' ', 'W', ' ', '#' },
                { '#', 'W', ' ', ' ', ' ', 'C', ' ', ' ', ' ', '#' },
                { '#', ' ', ' ', ' ', ' ', ' ', 'S', ' ', ' ', '#' },
                { '#', 'Z', ' ', 'W', ' ', ' ', ' ', ' ', 'X', '#' }, // <-- Inserted 'X' near bottom right
                { '#', '#', '#', '#', '#', '#', '#', '#', '#', '#' }
            };

            int startX = 1;
            int startY = 1;
            return new Map(grid, startX, startY);
        }
    }
}

