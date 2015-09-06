using System.Collections.Generic;

namespace MRobot.Civilization.Game
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
        public static IDictionary<GamePace, string> GamePaceAsDict
        {
            get 
            { 
                var dict = new Dictionary<GamePace, string>();
                foreach (GamePace val in typeof(GamePace).GetEnumValues())
                    dict.Add(val, val.ToString());
                return dict;
            }
        }
    }
}
