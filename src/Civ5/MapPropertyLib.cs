using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MRobot.Civilization.Base;
using MRobot.Civilization.Civ5.MapEnums;

namespace MRobot.Civilization.Civ5
{
    static class MapPropertyLib
    {
        public static IList<GameProperty> StandardSet => new[]
        {
            WorldAgeProp,
            TemperatureProp,
            RainfallProp,
            ResourcesProp
        };

        public static IList<GameProperty> StandardSetWithSeaLevel = StandardSetPlus(new Tuple<int, GameProperty>(3, SeaLevelProp));


        /// <summary>
        /// Returns the standard set with extra properties inserted
        /// </summary>
        /// <param name="additional">Additional properties to insert, by index. If index is -1, the property is appended to the end.</param>
        /// <returns></returns>
        public static IList<GameProperty> StandardSetPlus(params Tuple<int, GameProperty>[] additional)
        {
            var list = new List<GameProperty>(StandardSet);
            foreach (var mp in additional)
            {
                if (mp.Item1 != -1)
                    list.Insert(mp.Item1, mp.Item2);
                else
                    list.Add(mp.Item2);
            }
            return list;
        }

        public static IList<GameProperty> StandardSetPlus(params GameProperty[] additional)
        {
            return StandardSetPlus(additional.Select(mp => new Tuple<int, GameProperty>(-1, mp)).ToArray());
        }

        public static GameProperty<MapSize> NonStandardMapSizeProp(params MapSize[] possibleSizes)
        {
            return new GameProperty<MapSize>
            (
                name: "Map Size",
                defaultValue: possibleSizes.Length > 1 ? possibleSizes[possibleSizes.Length / 2 - 1] : possibleSizes[0],
                possibleValues: possibleSizes.ToDictionary(m => m, m => m.Name)
            );
        }

        public static IList<GameProperty> VersusSet
        {
            get
            {
                var resources = ResourcesProp;
                resources.Value = Resources.StrategicBalance;

                return new List<GameProperty>
                {
                    WorldAgeProp,
                    TemperatureProp,
                    RainfallProp,
                    resources,
                    TeamSettingLimitedProp
                };
            }
        }


        public static GameProperty<MapSize> MapSizeProp => new GameProperty<MapSize>(
                name: "Map Size",
                defaultValue: MapSizes.Small,
                possibleValues: EnumDefinitions.MapSizeAsDict
            );

        public static GameProperty WorldAgeProp => new GameProperty
            (
                name: "World Age",
                defaultValue: WorldAge.FourBillionYears,
                possibleValues: EnumDefinitions.WorldAgeAsDict
            );

        public static GameProperty TemperatureProp => new GameProperty
            (
                name: "Temperature",
                defaultValue: Temperature.Temperate,
                possibleValues: EnumDefinitions.TemperatureAsDict
            );

        public static GameProperty RainfallProp => new GameProperty
            (
                name: "Rainfall",
                defaultValue: Rainfall.Normal,
                possibleValues: EnumDefinitions.RainfallAsDict
            );

        public static GameProperty SeaLevelProp => new GameProperty
            (
                name: "Sea Level",
                defaultValue: SeaLevel.Medium,
                possibleValues: EnumDefinitions.SeaLevelAsDict
            );

        public static GameProperty BodiesOfWaterProp => new GameProperty
            (
                name: "Bodies of Water",
                defaultValue: BodiesOfWater.Random,
                possibleValues: EnumDefinitions.BodiesOfWaterAsDict
            );

        public static GameProperty CenterRegionProp => new GameProperty
            (
                name: "Center Region",
                defaultValue: LandType.Ocean,
                possibleValues: EnumDefinitions.LandTypeAsDict
            );

        public static GameProperty ResourcesProp => new GameProperty
            (
                name: "Resources",
                defaultValue: Resources.Standard,
                possibleValues: EnumDefinitions.ResourcesAsDict
            );

        public static GameProperty FullLandmassProp => new GameProperty
            (
                name: "Landmass Type",
                defaultValue: Landmass.Random,
                possibleValues: EnumDefinitions.LandmassAsDict
            );

        public static GameProperty BasicLandmassProp => new GameProperty
            (
                name: "Landmass Type",
                defaultValue: BasicLandmass.Random,
                possibleValues: EnumDefinitions.BasicLandmassAsDict
            );

        public static GameProperty TeamSettingProp => new GameProperty
            (
                name: "Team Setting",
                defaultValue: TeamSetting.StartTogether,
                possibleValues: EnumDefinitions.TeamSettingAsDict
            );

        public static GameProperty TeamSettingLimitedProp => new GameProperty
            (
                name: "Team Setting",
                defaultValue: TeamSetting.StartTogether,
                possibleValues: new Dictionary<object, string>()
                {
                    { TeamSetting.StartTogether, "Start Together" },
                    { TeamSetting.StartAnywhere, "Start Anywhere" }
                }
            );
    }
}
