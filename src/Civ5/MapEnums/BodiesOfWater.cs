using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MRobot.CivilizationV.Game.Maps
{
    public enum BodiesOfWater
    {
        SmallLakes,
        LargeLakes,
        Seas,
        Random
    }

    static partial class EnumDefinitions
    {
        public static IDictionary<object, string> BodiesOfWaterAsDict
        {
            get
            {
                return new Dictionary<object, string>()
                {
                    { BodiesOfWater.SmallLakes, "Small Lakes" },
                    { BodiesOfWater.LargeLakes, "Large Lakes" },
                    { BodiesOfWater.Seas,       "Seas" },
                    { BodiesOfWater.Random,     "Random" }
                };
            }
        }
    }
}
