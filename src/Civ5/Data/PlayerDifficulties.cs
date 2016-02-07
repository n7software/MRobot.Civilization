using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MRobot.Civilization.Civ5.Data
{
    public class PlayerDifficulties
    {
        public const int Settler = 0;
        public const int Chieftain = 1;
        public const int Warlord = 2;
        public const int Prince = 3;
        public const int King = 4;
        public const int Emperor = 5;
        public const int Immortal = 6;
        public const int Diety = 7;
        public const int AI = 8;

        public const int DefaultDifficulty = Chieftain;

        public static IDictionary<int, string> DifficultyNames = new Dictionary<int, string>
        {
            [Settler] = "Setter",
            [Chieftain] = "Chieftain",
            [Warlord] = "Warlord",
            [Prince] = "Prince",
            [King] = "King",
            [Emperor] = "Emperor",
            [Immortal] = "Immortal",
            [Diety] = "Diety",
            [AI] = "AI"
        };
    }
}
