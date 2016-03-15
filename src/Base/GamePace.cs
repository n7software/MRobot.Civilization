using MRobot.Civilization.Base;
using System.Collections.Generic;

namespace MRobot.Civilization.Base
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
