using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JourneyToTheEndOfTheLine.Systems
{
    public class GameState
    {
        public string PlayerName { get; set; } = "";
        public Inventory Inventory { get; set; } = new Inventory();
        public Dictionary<string, bool> Choices { get; set; } = new Dictionary<string, bool>();

        public bool Act1Completed { get; set; } = false;
        public bool Act2Completed { get; set; } = false;
        public bool Act3Completed { get; set; } = false;
    }
}
