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
                { '#', 'L', ' ', ' ', 'M', ' ', ' ', ' ', ' ', '#' },
                { '#', ' ', ' ', ' ', ' ', ' ', ' ', 'W', ' ', '#' },
                { '#', 'W', ' ', ' ', ' ', 'C', ' ', ' ', ' ', '#' },
                { '#', ' ', ' ', ' ', ' ', ' ', 'S', ' ', ' ', '#' },
                { '#', ' ', ' ', 'W', ' ', ' ', ' ', ' ', 'X', '#' }, // <-- Inserted 'X' near bottom right
                { '#', '#', '#', '#', '#', '#', '#', '#', '#', '#' }
            };

            int startX = 1;
            int startY = 1;
            return new Map(grid, startX, startY);
        }
    }
}

