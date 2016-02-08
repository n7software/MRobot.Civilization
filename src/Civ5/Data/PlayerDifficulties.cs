using System.Collections.Generic;
using MRobot.Civilization.Base;

namespace MRobot.Civilization.Civ5.Data
{
    public static class PlayerDifficulties
    {
        public readonly static PlayerDifficulty Settler     = new PlayerDifficulty("Settler", 0);
        public readonly static PlayerDifficulty Chieftain   = new PlayerDifficulty("Chieftain", 1);
        public readonly static PlayerDifficulty Warlord     = new PlayerDifficulty("Warlord", 2);
        public readonly static PlayerDifficulty Prince      = new PlayerDifficulty("Prince", 3);
        public readonly static PlayerDifficulty King        = new PlayerDifficulty("King", 4);
        public readonly static PlayerDifficulty Emperor     = new PlayerDifficulty("Emperor", 5);
        public readonly static PlayerDifficulty Immortal    = new PlayerDifficulty("Immortal", 6);
        public readonly static PlayerDifficulty Diety       = new PlayerDifficulty("Diety", 7);
        public readonly static PlayerDifficulty AI          = new PlayerDifficulty("AI", 8);

        public readonly static PlayerDifficulty DefaultDifficulty = Chieftain;

        public static IEnumerable<PlayerDifficulty> All = new List<PlayerDifficulty>
        {
            Settler,
            Chieftain,
            Warlord,
            Prince,
            King,
            Emperor,
            Immortal,
            Diety,
            AI
        };
    }
}
