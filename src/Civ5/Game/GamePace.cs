using MRobot.CivilizationV.Game.Maps;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MRobot.CivilizationV.Game
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
