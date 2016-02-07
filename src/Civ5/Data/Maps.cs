using System;
using System.Collections.Generic;
using System.Linq;
using MRobot.Civilization.Base;
using MRobot.Civilization.Civ5.MapEnums;

namespace MRobot.Civilization.Civ5.Data
{
    public class Maps
    {
        private static IDictionary<SaveString, Func<Map>> _All;
        public static Map FindByPath(SaveString mapPath)
        {
            VerifyAllDict();

            return _All.ContainsKey(mapPath) ? _All[mapPath]() : null;
        }

        public static IList<Map> GetAllDefaultMaps()
        {
            VerifyAllDict();
            return _All.Values.Distinct().Select(v => v()).ToList();
        }

        private static void VerifyAllDict()
        {
            if (_All == null)
                _All = Utils.GetStaticGettersOfType<SaveString, Map>(map => map.AllPossiblePaths);
        }

        public static Map Africa => new Map
            (
                name: "Africa Scrambled",
                requirement: Expansions.ScrambledContinents,
                mapSize: MapProperties.NonStandardMapSizeProp(MapSizes.Duel, MapSizes.Small, MapSizes.Standard, MapSizes.Large),
                sizedMaps: new Dictionary<MapSize, SaveString>()
                {
                    { MapSizes.Duel, @"Assets\DLC\DLC_SP_Maps_2\Maps\Random_Africa_Duel.Civ5Map" },
                    { MapSizes.Small, @"Assets\DLC\DLC_SP_Maps_2\Maps\Random_Africa_Small.Civ5Map" },
                    { MapSizes.Standard, @"Assets\DLC\DLC_SP_Maps_2\Maps\Random_Africa_Standard.Civ5Map" },
                    { MapSizes.Large, @"Assets\DLC\DLC_SP_Maps_2\Maps\Random_Africa_Large.Civ5Map" },
                }
            );

        public static Map Amazon => new Map
            (
                name: "Amazon",
                saveName: @"Assets\DLC\DLC_SP_Maps\Maps\Amazon.lua",
                requirement: Expansions.ExplorersMapPack
            );

        public static Map AmazonPlus => new Map
            (
                name: "Amazon Plus",
                saveName: @"Assets\DLC\Expansion\Maps\Amazon_XP.lua",
                requirement: Expansions.GodsAndKings
            );

        public static Map Americas => new Map
            (
                name: "Americas",
                saveName: @"Assets\Maps\Americas.Civ5Map"
            );

        public static Map AncientLakes => new Map
            (
                name: "Ancient Lakes",
                saveName: @"Assets\Maps\M_AncientLake.Civ5Map"
            );

        public static Map Arborea => new Map
            (
                name: "Arborea",
                saveName: @"Assets\DLC\Expansion\Maps\Arborea.lua",
                requirement: Expansions.GodsAndKings,
                mapProperties: MapProperties.StandardSetPlus
                    (
                        new Tuple<int, GameProperty> (3, MapProperties.SeaLevelProp),
                        new Tuple<int, GameProperty> (-1, MapProperties.FullLandmassProp)
                    )
            );

        public static Map Archipelago => new Map
            (
                name: "Archipelago",
                saveName: @"Assets\Maps\Archipelago.lua",
                mapProperties: MapProperties.StandardSetWithSeaLevel
            );

        public static Map Asia => new Map
            (
                name: "Asia",
                saveName: @"Assets\Maps\Asia.Civ5Map"
            );

        public static Map Australia => new Map
            (
                name: "Australia Scrambled",
                requirement: Expansions.ScrambledNations,
                mapSize: MapProperties.NonStandardMapSizeProp(MapSizes.Duel, MapSizes.Small, MapSizes.Standard, MapSizes.Large),
                sizedMaps: new Dictionary<MapSize, SaveString>()
                {
                    { MapSizes.Duel, @"Assets\DLC\DLC_SP_Maps_3\Maps\Random_Australia_Duel.Civ5Map" },
                    { MapSizes.Small, @"Assets\DLC\DLC_SP_Maps_3\Maps\Random_Australia_Small.Civ5Map" },
                    { MapSizes.Standard, @"Assets\DLC\DLC_SP_Maps_3\Maps\Random_Australia_Standard.Civ5Map" },
                    { MapSizes.Large, @"Assets\DLC\DLC_SP_Maps_3\Maps\Random_Australia_Large.Civ5Map" },
                }
            );

        public static Map BeringStrait => new Map
            (
                name: "Bering Strait",
                saveName: @"Assets\DLC\DLC_SP_Maps\Maps\BeringStrait.Civ5Map",
                requirement: Expansions.ExplorersMapPack,
                mapSize: MapProperties.NonStandardMapSizeProp(MapSizes.Standard)
            );

        public static Map Boreal => new Map
            (
                name: "Boreal",
                saveName: @"Assets\DLC\Expansion\Maps\Boreal.lua",
                requirement: Expansions.GodsAndKings,
                mapProperties: new GameProperty[]
                {
                    MapProperties.WorldAgeProp,
                    MapProperties.RainfallProp,
                    MapProperties.ResourcesProp
                }
            );

        public static Map BritishIsles => new Map
            (
                name: "British Isles",
                saveName: @"Assets\DLC\DLC_SP_Maps\Maps\BritishIsles.Civ5Map",
                requirement: Expansions.ExplorersMapPack,
                mapSize: MapProperties.NonStandardMapSizeProp(MapSizes.Standard)
            );

        public static Map Canada => new Map
            (
                name: "Canada Scrambled",
                requirement: Expansions.ScrambledNations,
                mapSize: MapProperties.NonStandardMapSizeProp(MapSizes.Tiny, MapSizes.Small, MapSizes.Standard, MapSizes.Large),
                sizedMaps: new Dictionary<MapSize, SaveString>()
                {
                    { MapSizes.Tiny, @"Assets\DLC\DLC_SP_Maps_3\Maps\Random_Canada_Tiny.Civ5Map" },
                    { MapSizes.Small, @"Assets\DLC\DLC_SP_Maps_3\Maps\Random_Canada_Small.Civ5Map" },
                    { MapSizes.Standard, @"Assets\DLC\DLC_SP_Maps_3\Maps\Random_Canada_Standard.Civ5Map" },
                    { MapSizes.Large, @"Assets\DLC\DLC_SP_Maps_3\Maps\Random_Canada_Large.Civ5Map" }
                }
            );

        public static Map Caribbean => new Map
            (
                name: "Caribbean",
                saveName: @"Assets\DLC\DLC_SP_Maps\Maps\Caribbean.Civ5Map",
                requirement: Expansions.ExplorersMapPack,
                mapSize: MapProperties.NonStandardMapSizeProp(MapSizes.Standard)
            );

        public static Map Continents => new Map
            (
                name: "Continents",
                saveName: @"Assets\Maps\Continents.lua",
                mapProperties: MapProperties.StandardSetWithSeaLevel
            );

        public static Map ContinentsPlus => new Map
            (
                name: "Continents Plus",
                saveName: @"Assets\DLC\DLC_SP_Maps\Maps\ContinentsPlus.lua",
                requirement: Expansions.ExplorersMapPack,
                mapProperties: MapProperties.StandardSetWithSeaLevel
            );

        public static Map Donut => new Map
            (
                name: "Donut",
                saveName: @"Assets\DLC\DLC_SP_Maps\Maps\Donut.lua",
                requirement: Expansions.ExplorersMapPack,
                mapProperties: new GameProperty[] { MapProperties.CenterRegionProp }
            );

        public static Map Earth => new Map
            (
                name: "Earth",
                sizedMaps: new Dictionary<MapSize, SaveString>()
                {
                    { MapSizes.Duel, @"Assets\Maps\Earth_Duel.Civ5Map" },
                    { MapSizes.Tiny, @"Assets\Maps\Earth_Tiny.Civ5Map" },
                    { MapSizes.Small, @"Assets\Maps\Earth_Small.Civ5Map" },
                    { MapSizes.Standard, @"Assets\Maps\Earth_Standard.Civ5Map" },
                    { MapSizes.Large, @"Assets\Maps\Earth_Large.Civ5Map" },
                    { MapSizes.Huge, @"Assets\Maps\Earth_Huge.Civ5Map" }
                }
            );

        public static Map EarthScrambled => new Map
            (
                name: "Earth Scrambled",
                requirement: Expansions.ScrambledContinents,
                sizedMaps: new Dictionary<MapSize, SaveString>()
                {
                    { MapSizes.Duel, @"Assets\DLC\DLC_SP_Maps_2\Maps\Random_Earth_Duel.Civ5Map" },
                    { MapSizes.Tiny, @"Assets\DLC\DLC_SP_Maps_2\Maps\Random_Earth_Tiny.Civ5Map" },
                    { MapSizes.Small, @"Assets\DLC\DLC_SP_Maps_2\Maps\Random_Earth_Small.Civ5Map" },
                    { MapSizes.Standard, @"Assets\DLC\DLC_SP_Maps_2\Maps\Random_Earth_Standard.Civ5Map" },
                    { MapSizes.Large, @"Assets\DLC\DLC_SP_Maps_2\Maps\Random_Earth_Large.Civ5Map" },
                    { MapSizes.Huge, @"Assets\DLC\DLC_SP_Maps_2\Maps\Random_Earth_Huge.Civ5Map" }
                }
            );

        public static Map EastAsia => new Map
            (
                name: "East Asia Scrambled",
                requirement: Expansions.ScrambledContinents,
                mapSize: MapProperties.NonStandardMapSizeProp(MapSizes.Small, MapSizes.Large),
                sizedMaps: new Dictionary<MapSize, SaveString>()
                {
                    { MapSizes.Small, @"Assets\DLC\DLC_SP_Maps_2\Maps\Random_Eastern_Asia_Small.Civ5Map" },
                    { MapSizes.Large, @"Assets\DLC\DLC_SP_Maps_2\Maps\Random_Eastern_Asia_Large.Civ5Map" }
                }
            );

        public static Map EasternUnitedStates => new Map
            (
                name: "Eastern United States",
                saveName: @"Assets\DLC\DLC_SP_Maps\Maps\EasternUnitedStates.Civ5Map",
                requirement: Expansions.ExplorersMapPack,
                mapSize: MapProperties.NonStandardMapSizeProp(MapSizes.Standard)
            );

        public static Map Europe => new Map
            (
                name: "Europe",
                saveName: @"Assets\DLC\Expansion\Maps\Europe.lua",
                requirement: Expansions.GodsAndKings
            );

        public static Map FourCorners => new Map
            (
                name: "Four Corners",
                saveName: @"Assets\Maps\Four_Corners.lua",
                mapProperties: MapProperties.StandardSetPlus
                    (
                        new GameProperty("Buffer Zones", LandType.Ocean, new Dictionary<object, string>()
                        {
                            { LandType.Ocean, "Ocean" },
                            { LandType.Mountains, "Mountains" },
                            { LandType.Random, "Random" }
                        }),
                        MapProperties.TeamSettingProp
                    )
            );

        public static Map Fractal => new Map
            (
                name: "Fractal",
                saveName: @"Assets\Maps\Fractal.lua"
            );

        public static Map Frontier => new Map
            (
                name: "Frontier",
                saveName: @"Assets\DLC\Expansion\Maps\Frontier.lua",
                requirement: Expansions.GodsAndKings,
                mapProperties: MapProperties.StandardSetPlus
                    (
                        new Tuple<int, GameProperty> (3, MapProperties.SeaLevelProp),
                        new Tuple<int, GameProperty> (-1, MapProperties.BasicLandmassProp)
                    )
            );

        public static Map GreatPlains => new Map
            (
                name: "Great Plains",
                saveName: @"Assets\Maps\Great_Plains.lua"
            );

        public static Map GreatPlainsPlus => new Map
            (
                name: "Great Plains Plus",
                saveName: @"Assets\DLC\Expansion\Maps\Great_Plains_XP.lua",
                requirement: Expansions.GodsAndKings
            );

        public static Map Hemispheres => new Map
            (
                name: "Hemispheres",
                saveName: @"Assets\DLC\Expansion\Maps\Hemispheres.lua",
                requirement: Expansions.GodsAndKings,
                mapProperties: new GameProperty[]
                {
                    MapProperties.WorldAgeProp,
                    MapProperties.TemperatureProp,
                    MapProperties.RainfallProp,
                    MapProperties.ResourcesProp,
                    new GameProperty("Tiny Islands", MapEnums.TinyIslands.Various, EnumDefinitions.TinyIslandsAsDict),
                    MapProperties.TeamSettingProp,
                }
            );

        public static Map Highlands => new Map
            (
                name: "Highlands",
                saveName: @"Assets\Maps\Highlands.lua",
                mapProperties: new GameProperty[]
                {
                    MapProperties.TemperatureProp,
                    MapProperties.RainfallProp,
                    MapProperties.ResourcesProp,
                    new GameProperty("Mountain Pattern", MountainPattern.Random, EnumDefinitions.MountainPatternAsDict),
                    new GameProperty("Mountain Density", MountainDensity.Random, EnumDefinitions.MountainDensityAsDict),
                    MapProperties.BodiesOfWaterProp
                }
            );

        public static Map IceAge => new Map
            (
                name: "Ice Age",
                saveName: @"Assets\Maps\Ice_Age.lua",
                mapProperties: MapProperties.StandardSetPlus
                    (
                        new Tuple<int, GameProperty> (3, MapProperties.SeaLevelProp), 
                        new Tuple<int, GameProperty> (-1, new GameProperty("Landmass Type", LandmassAlt.Random, EnumDefinitions.LandmassAltAsDict)
                            ))
            );

        public static Map InlandSea => new Map
            (
                name: "Inland Sea",
                saveName: @"Assets\Maps\InlandSea.lua",
                mapProperties: MapProperties.StandardSet
            );

        public static Map Italy => new Map
            (
                name: "Italy Scrambled",
                requirement: Expansions.ScrambledNations,
                mapSize: MapProperties.NonStandardMapSizeProp(MapSizes.Small, MapSizes.Standard),
                sizedMaps: new Dictionary<MapSize, SaveString>()
                {
                    { MapSizes.Small, @"Assets\DLC\DLC_SP_Maps_3\Maps\Random_Italy_Small.Civ5Map" },
                    { MapSizes.Standard, @"Assets\DLC\DLC_SP_Maps_3\Maps\Random_Italy_Standard.Civ5Map" }
                }
            );

        public static Map Japan => new Map
            (
                name: "Japan Scrambled",
                requirement: Expansions.ScrambledNations,
                mapSize: MapProperties.NonStandardMapSizeProp(MapSizes.Duel, MapSizes.Small),
                sizedMaps: new Dictionary<MapSize, SaveString>()
                {
                    { MapSizes.Duel, @"Assets\DLC\DLC_SP_Maps_3\Maps\Random_Japan_Duel.Civ5Map" },
                    { MapSizes.Small, @"Assets\DLC\DLC_SP_Maps_3\Maps\Random_Japan_Small.Civ5Map" }
                }
            );

        public static Map JapaneseMainland => new Map
            (
                name: "Japanese Mainland",
                saveName: @"Assets\DLC\DLC_SP_Maps\Maps\JapaneseMainland.Civ5Map",
                requirement: Expansions.ExplorersMapPack,
                mapSize: MapProperties.NonStandardMapSizeProp(MapSizes.Tiny)
            );

        public static Map Lakes => new Map
            (
                name: "Lakes",
                saveName: @"Assets\Maps\Lakes.lua",
                mapProperties: new GameProperty[]
                {
                    MapProperties.WorldAgeProp,
                    MapProperties.TemperatureProp,
                    MapProperties.RainfallProp,
                    MapProperties.ResourcesProp,
                    MapProperties.BodiesOfWaterProp
                }
            );

        public static Map LargeIslands => new Map
            (
                name: "Large Islands",
                saveName: @"Assets\DLC\Expansion\Maps\Large_Islands.lua",
                requirement: Expansions.GodsAndKings,
                mapProperties: MapProperties.StandardSet
            );

        public static Map Mediterranean => new Map
            (
                name: "Mediterranean",
                saveName: @"Assets\Maps\Mediterranean.Civ5Map"
            );

        public static Map Mesopotamia => new Map
            (
                name: "Mesopotamia",
                saveName: @"Assets\Maps\Mesopotamia.Civ5Map"
            );

        public static Map MiddleEast => new Map
            (
                name: "Middle East Scrambled",
                requirement: Expansions.ScrambledContinents,
                mapSize: MapProperties.NonStandardMapSizeProp(MapSizes.Duel, MapSizes.Tiny, MapSizes.Small, MapSizes.Standard, MapSizes.Large),
                sizedMaps: new Dictionary<MapSize, SaveString>()
                {
                    { MapSizes.Duel, @"Assets\DLC\DLC_SP_Maps_2\Maps\Random_Middle_East_Duel.Civ5Map" },
                    { MapSizes.Tiny, @"Assets\DLC\DLC_SP_Maps_2\Maps\Random_Middle_East_Tiny.Civ5Map" },
                    { MapSizes.Small, @"Assets\DLC\DLC_SP_Maps_2\Maps\Random_Middle_East_Small.Civ5Map" },
                    { MapSizes.Standard, @"Assets\DLC\DLC_SP_Maps_2\Maps\Random_Middle_East_Standard.Civ5Map" },
                    { MapSizes.Large, @"Assets\DLC\DLC_SP_Maps_2\Maps\Random_Middle_East_Large.Civ5Map" }
                }
            );

        public static Map NorthAmerica => new Map
            (
                name: "North America Scrambled",
                requirement: Expansions.ScrambledContinents,
                sizedMaps: new Dictionary<MapSize, SaveString>()
                {
                    { MapSizes.Duel, @"Assets\DLC\DLC_SP_Maps_2\Maps\Random_North_America_Duel.Civ5Map" },
                    { MapSizes.Tiny, @"Assets\DLC\DLC_SP_Maps_2\Maps\Random_North_America_Tiny.Civ5Map" },
                    { MapSizes.Small, @"Assets\DLC\DLC_SP_Maps_2\Maps\Random_North_America_Small.Civ5Map" },
                    { MapSizes.Standard, @"Assets\DLC\DLC_SP_Maps_2\Maps\Random_North_America_Standard.Civ5Map" },
                    { MapSizes.Large, @"Assets\DLC\DLC_SP_Maps_2\Maps\Random_North_America_Large.Civ5Map" },
                    { MapSizes.Huge, @"Assets\DLC\DLC_SP_Maps_2\Maps\Random_North_America_Huge.Civ5Map" }
                }
            );

        public static Map NorthVsSouth => new Map
            (
                name: "North vs South",
                saveName: @"Assets\Maps\North_vs_South.lua",
                mapProperties: MapProperties.VersusSet
            );

        public static Map Oceania => new Map
            (
                name: "Oceania",
                requirement: Expansions.ScrambledContinents,
                saveName: @"Assets\DLC\DLC_SP_Maps_2\Maps\Script_Oceania.lua",
                mapProperties: new GameProperty[] 
                {
                    MapProperties.RainfallProp,
                    MapProperties.ResourcesProp,
                    new GameProperty("Ocean", Ocean.Large, EnumDefinitions.OceanAsDict)
                }
            );

        public static Map Oval => new Map
            (
                name: "Oval",
                saveName: @"Assets\Maps\Oval.lua",
                mapProperties: MapProperties.StandardSetWithSeaLevel
            );

        public static Map Pangaea => new Map
            (
                name: "Pangaea",
                saveName: @"Assets\Maps\Pangaea.lua",
                mapProperties: MapProperties.StandardSetWithSeaLevel
            );

        public static Map PangaeaPlus => new Map
            (
                name: "Pangaea Plus",
                saveName: @"Assets\DLC\DLC_SP_Maps\Maps\PangaeaPlus.lua",
                requirement: Expansions.ExplorersMapPack,
                mapProperties: MapProperties.StandardSetWithSeaLevel
            );

        public static Map Rainforest => new Map
            (
                name: "Rainforest",
                saveName: @"Assets\DLC\Expansion\Maps\Rainforest.lua",
                requirement: Expansions.GodsAndKings,
                mapProperties: MapProperties.StandardSetPlus
                    (
                        new Tuple<int, GameProperty> (3, MapProperties.SeaLevelProp), 
                        new Tuple<int, GameProperty> (-1, MapProperties.FullLandmassProp)
                    )
            );

        public static Map Ring => new Map
            (
                name: "Ring",
                saveName: @"Assets\Maps\Ring.lua",
                mapProperties: new GameProperty[]
                {
                    new GameProperty("Dominant Terrain", Terrain.Random, new Dictionary<object, string>()
                    {
                        { Terrain.Grasslands,    "Grasslands" },
                        { Terrain.Plains,        "Plains" },
                        { Terrain.Forest,        "Forest" },
                        { Terrain.Jungle,        "Jungle" },
                        { Terrain.Random,        "Random" }
                    }),
                    new GameProperty("Land Shape", LandShape.Random, EnumDefinitions.LandShapeAsDict),
                    new GameProperty("Isthmus Width", IsthmusWidth.ThreePlotsWide, EnumDefinitions.IsthmusWidthAsDict),
                    MapProperties.ResourcesProp
                }
            );

        public static Map Russia => new Map
            (
                name: "Russia",
                mapSize: MapProperties.MapSizeProp,
                sizedMaps: new Dictionary<MapSize, SaveString>()
                {
                    { MapSizes.Duel, @"Assets\DLC\DLC_SP_Maps_3\Maps\Random_Russia_Duel.Civ5Map" },
                    { MapSizes.Tiny, @"Assets\DLC\DLC_SP_Maps_3\Maps\Random_Russia_Tiny.Civ5Map" },
                    { MapSizes.Small, @"Assets\DLC\DLC_SP_Maps_3\Maps\Random_Russia_Small.Civ5Map" },
                    { MapSizes.Standard, @"Assets\DLC\DLC_SP_Maps_3\Maps\Random_Russia_Standard.Civ5Map" },
                    { MapSizes.Large, @"Assets\DLC\DLC_SP_Maps_3\Maps\Random_Russia_Large.Civ5Map" },
                    { MapSizes.Huge, @"Assets\DLC\DLC_SP_Maps_3\Maps\Random_Russia_Huge.Civ5Map" }
                }
            );

        public static Map Sandstorm => new Map
            (
                name: "Sandstorm",
                saveName: @"Assets\DLC\DLC_SP_Maps\Maps\Sandstorm.lua",
                requirement: Expansions.ExplorersMapPack,
                mapProperties: new GameProperty[]
                {
                    MapProperties.WorldAgeProp,
                    MapProperties.SeaLevelProp,
                    MapProperties.ResourcesProp,
                    MapProperties.BasicLandmassProp
                }
            );

        public static Map Scandinavia => new Map
            (
                name: "Scandinavia Scrambled",
                requirement: Expansions.ScrambledNations,
                mapSize: MapProperties.NonStandardMapSizeProp(MapSizes.Small, MapSizes.Standard, MapSizes.Large),
                sizedMaps: new Dictionary<MapSize, SaveString>()
                {
                    { MapSizes.Small, @"Assets\DLC\DLC_SP_Maps_3\Maps\Random_Scandinavia_Small.Civ5Map" },
                    { MapSizes.Standard, @"Assets\DLC\DLC_SP_Maps_3\Maps\Random_Scandinavia_Standard.Civ5Map" },
                    { MapSizes.Large, @"Assets\DLC\DLC_SP_Maps_3\Maps\Random_Scandinavia_Large.Civ5Map" }
                }
            );

        public static Map Shuffle => new Map
            (
                name: "Shuffle",
                saveName: @"Assets\DLC\Expansion\Maps\Shuffle.lua",
                requirement: Expansions.GodsAndKings
            );

        public static Map Skirmish => new Map
            (
                name: "Skirmish",
                saveName: @"Assets\Maps\Skirmish.lua",
                mapProperties: new GameProperty[] 
                {
                    new GameProperty("Dominant Terrain", Terrain.Random, EnumDefinitions.TerrainAsDict),
                    new GameProperty("Water Setting", WaterSetting.Rivers, EnumDefinitions.WaterSettingAsDict),
                    MapProperties.ResourcesProp
                }
            );

        public static Map SmallContinents => new Map
            (
                name: "Small Continents",
                saveName: @"Assets\Maps\SmallContinents.lua",
                mapProperties: MapProperties.StandardSetWithSeaLevel
            );

        public static Map SmallContinentsPlus => new Map
            (
                name: "Small Continents Plus",
                saveName: @"Assets\DLC\DLC_SP_Maps_2\Maps\Script_Small_Continents_Plus.lua",
                requirement: Expansions.ScrambledContinents,
                mapProperties: MapProperties.StandardSetWithSeaLevel
            );

        public static Map Terra => new Map
            (
                name: "Terra",
                saveName: @"Assets\Maps\Terra.lua",
                mapProperties: MapProperties.StandardSet
            );

        public static Map TiltedAxis => new Map
            (
                name: "Tilted Axis",
                saveName: @"Assets\DLC\Expansion\Maps\Tilted_Axis.lua",
                requirement: Expansions.GodsAndKings,
                mapProperties: new GameProperty[] 
                {
                    MapProperties.WorldAgeProp,
                    MapProperties.RainfallProp,
                    MapProperties.SeaLevelProp,
                    MapProperties.ResourcesProp,
                    MapProperties.FullLandmassProp
                }
            );

        public static Map TinyIslands => new Map
            (
                name: "Tiny Islands",
                saveName: @"Assets\Maps\TinyIslands.lua",
                mapProperties: new GameProperty[]
                {
                    MapProperties.WorldAgeProp,
                    MapProperties.TemperatureProp,
                    MapProperties.RainfallProp,
                    MapProperties.SeaLevelProp
                }
            );

        public static Map Turkey => new Map
            (
                name: "Turkey Scrambled",
                requirement: Expansions.ScrambledNations,
                mapSize: MapProperties.NonStandardMapSizeProp(MapSizes.Small, MapSizes.Standard, MapSizes.Large),
                sizedMaps: new Dictionary<MapSize, SaveString>()
                {
                    { MapSizes.Small, @"Assets\DLC\DLC_SP_Maps_3\Maps\Random_Turkey_Small.Civ5Map" },
                    { MapSizes.Standard, @"Assets\DLC\DLC_SP_Maps_3\Maps\Random_Turkey_Standard.Civ5Map" },
                    { MapSizes.Large, @"Assets\DLC\DLC_SP_Maps_3\Maps\Random_Turkey_Large.Civ5Map" }
                }
            );

        public static Map UnitedKingdom => new Map
            (
                name: "United Kingdom Scrambled",
                requirement: Expansions.ScrambledNations,
                mapSize: MapProperties.NonStandardMapSizeProp(MapSizes.Tiny, MapSizes.Standard),
                sizedMaps: new Dictionary<MapSize, SaveString>()
                {
                    { MapSizes.Tiny, @"Assets\DLC\DLC_SP_Maps_3\Maps\Random_UK_Tiny.Civ5Map" },
                    { MapSizes.Standard, @"Assets\DLC\DLC_SP_Maps_3\Maps\Random_UK_Standard.Civ5Map" }
                }
            );

        public static Map WestVsEast => new Map
            (
                name: "West vs East",
                saveName: @"Assets\Maps\West_vs_East.lua",
                mapProperties: MapProperties.VersusSet
            );

        public static Map WesternEurope => new Map
            (
                name: "Western Europe Scrambled",
                requirement: Expansions.ScrambledNations,
                mapSize: MapProperties.NonStandardMapSizeProp(MapSizes.Small, MapSizes.Standard),
                sizedMaps: new Dictionary<MapSize, SaveString>()
                {
                    { MapSizes.Small, @"Assets\DLC\DLC_SP_Maps_3\Maps\Random_Western_Europe_Small.Civ5Map" },
                    { MapSizes.Standard, @"Assets\DLC\DLC_SP_Maps_3\Maps\Random_Western_Europe_Standard.Civ5Map" }
                }
            );
    }
}
