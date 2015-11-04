using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MRobot.CivilizationV.Civ5
{
    public class Player : Base.Player
    {
        public Player()
            : base(Utils.GetEnumAsDict<Base.PlayerDifficulty>())
        { }

        public ICivilization Civilization { get; set; }

        public static Player AiPlayer
        {
            get { return new Player { Type = PlayerType.AI }; }
        }

        public static Player ClosedSlot
        {
            get { return new Player { Type = PlayerType.None }; }
        }

        public static Player CityState
        {
            get { return new Player { Type = PlayerType.Unknown }; }
        }

        public static Player Barbarian
        {
            get { return new Player { Type = PlayerType.Unknown, Civilization = DefaultCivilizations.Unknown }; }
        }
    }
}
