using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MRobot.CivilizationV.Game.Maps
{
    public enum Resources
    {
        Sparse,
        Standard,
        Abundant,
        LegendaryStart,
        StrategicBalance,
        Random
    }

    static partial class EnumDefinitions
    {
        public static IDictionary<object, string> ResourcesAsDict
        {
            get
            {
                return new Dictionary<object, string>()
                {
                    { Resources.Sparse,             "Sparse" },
                    { Resources.Standard,           "Standard" },
                    { Resources.Abundant,           "Abundant" },
                    { Resources.LegendaryStart,     "Legendary Start" },
                    { Resources.StrategicBalance,   "Strategic Balance" },
                    { Resources.Random,             "Random" },
                };
            }
        }
    }
}
