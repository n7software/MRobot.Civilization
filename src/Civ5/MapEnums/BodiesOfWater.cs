using MRobot.Civilization.Base;
using System.Collections.Generic;

namespace MRobot.Civilization.Civ5.MapEnums
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
        public static IDictionary<object, string> BodiesOfWaterAsDict => Utils.GetEnumAsDict<BodiesOfWater>();
    }
}
