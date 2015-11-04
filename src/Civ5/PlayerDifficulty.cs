using MRobot.CivilizationV.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MRobot.CivilizationV.Civ5
{
    internal static class PlayerDifficultyProp
    {
        public IGameProperty<PlayerDifficulty> Default
        {
            get
            {
                return new GameProperty<PlayerDifficulty>("Difficulty", PlayerDifficulty.AI, Utils.GetEnumAsDict<PlayerDifficulty>());
            }
        }
    }
}
