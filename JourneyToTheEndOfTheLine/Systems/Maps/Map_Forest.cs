using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JourneyToTheEndOfTheLine.Systems;

namespace JourneyToTheEndOfTheLine.Maps
{
    public static class Map_Forest
    {
        public static Map Generate()
        {
            char[,] grid = new char[,] {
                { '#', '#', '#', '#', '#', '#', '#', '#', '#', '#' },
                { '#', ' ', 'B', ' ', 'T', ' ', ' ', 'B', ' ', '#' },
                { '#', 'T', ' ', ' ', ' ', 'T', ' ', ' ', 'T', '#' },
                { '#', ' ', 'B', ' ', ' ', ' ', 'B', ' ', ' ', '#' },
                { '#', ' ', ' ', ' ', 'R', ' ', ' ', ' ', ' ', '#' },
                { '#', ' ', 'T', ' ', ' ', ' ', 'T', ' ', 'B', '#' },
                { '#', 'B', ' ', ' ', 'T', ' ', ' ', 'T', ' ', '#' },
                { '#', ' ', ' ', 'B', ' ', ' ', ' ', ' ', ' ', '#' },
                { '#', '#', '#', '#', '#', '#', '#', '#', '#', '#' }
            };

            int startX = 1;
            int startY = 1;
            return new Map(grid, startX, startY);
        }
    }
}

