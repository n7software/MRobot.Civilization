using MRobot.Civilization.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MRobot.Civilization.Civ5
{
    internal static class PlayerDifficultyProp
    {
        public static IGameProperty<PlayerDifficulty> Default => new GameProperty<PlayerDifficulty>("Difficulty", PlayerDifficulty.AI, Utils.GetEnumAsDict<PlayerDifficulty>());
    }
}
