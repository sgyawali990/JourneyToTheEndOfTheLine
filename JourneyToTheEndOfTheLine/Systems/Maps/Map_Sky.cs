using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JourneyToTheEndOfTheLine.Systems;

namespace JourneyToTheEndOfTheLine.Maps
{
    public static class Map_Sky
    {
        public static Map Generate()
        {
            char[,] grid = new char[,] {
                { '#', '#', '#', '#', '#', '#', '#', '#', '#', '#' },
                { '#', ' ', 'C', ' ', 'O', ' ', ' ', 'C', ' ', '#' },
                { '#', 'T', ' ', ' ', ' ', 'T', ' ', ' ', 'T', '#' },
                { '#', ' ', 'C', ' ', ' ', ' ', 'C', ' ', ' ', '#' },
                { '#', ' ', ' ', ' ', 'R', ' ', ' ', ' ', ' ', '#' },
                { '#', ' ', 'T', ' ', ' ', ' ', 'T', ' ', 'O', '#' },
                { '#', 'O', ' ', ' ', 'T', ' ', ' ', 'T', ' ', '#' },
                { '#', ' ', ' ', 'C', ' ', ' ', ' ', ' ', ' ', '#' },
                { '#', '#', '#', '#', '#', '#', '#', '#', '#', '#' }
            };

            int startX = 1;
            int startY = 1;
            return new Map(grid, startX, startY);
        }
    }
}

