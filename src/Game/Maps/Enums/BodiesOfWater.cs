using System.Collections.Generic;

namespace MRobot.Civilization.Game.Maps.Enums
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
