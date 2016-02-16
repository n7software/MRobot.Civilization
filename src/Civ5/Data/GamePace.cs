using MRobot.Civilization.Base;
using System.Collections.Generic;

namespace MRobot.Civilization.Civ5.Data
{
    public enum GamePace
    {
        Quick,
        Standard,
        Epic,
        Marathon
    }

    public static class GamePaceDict
    {
        public static IDictionary<object, string> GamePaceAsDict => Utils.GetEnumAsDict<GamePace>();
    }
}
