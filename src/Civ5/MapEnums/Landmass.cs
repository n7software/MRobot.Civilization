using System.Collections.Generic;

namespace MRobot.Civilization.Civ5.MapEnums
{
    public enum BasicLandmass
    {
        Pangaea,
        Continents,
        Random
    }

    public enum Landmass
    {
        Pangaea,
        LargeContinents,
        SmallContinents,
        Islands,
        Random
    }

    public enum LandmassAlt
    {
        Random,
        WideContinents,
        NarrowContinents,
        Islands,
        SmallIslands
    }

    static partial class EnumDefinitions
    {
        public static IDictionary<object, string> BasicLandmassAsDict => Utils.GetEnumAsDict<BasicLandmass>();

        public static IDictionary<object, string> LandmassAsDict => Utils.GetEnumAsDict<Landmass>();

        public static IDictionary<object, string> LandmassAltAsDict => Utils.GetEnumAsDict<LandmassAlt>();
    }
}
