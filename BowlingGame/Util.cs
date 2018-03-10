using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BowlingGame
{
    [Serializable]
    class Util
    {
        public static List<string> lstNamePlayers { get; set; }
        public static int numHit { get; set; }
        public static int numColumn { get; set; }
        public static int numColumnAux { get; set; }
        public static int leftPosition { get; set; }
        public static int numPlayer { get; set; }
        public static int scoreTotal { get; set; }
        public static Dictionary<string, List<KeyValuePair<string, int>>> dcPlayerScore =
                                     new Dictionary<string, List<KeyValuePair<string, int>>>();
        public static List<KeyValuePair<string, int>> lstPlayers = new List<KeyValuePair<string, int>>();
        public static Dictionary<string, int> dcScoreTotal = new Dictionary<string, int>();
        public static List<Player> lstPlayerScore = new List<Player>();
        
    }
}
