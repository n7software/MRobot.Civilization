using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MRobot.CivilizationV.Civ5
{
    public class DefaultMaps
    {
        private static IDictionary<SaveString, Func<Map>> _All;
        public static Map FindByPath(SaveString mapPath)
        {
            VerifyAllDict();

            if (_All.ContainsKey(mapPath))
                return _All[mapPath]();
            else return null;
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

        public static Map Africa
        {
            get
            {
                return new Map
                (
                    name: "Africa Scrambled",
                    requirement: Expansion.ScrambledContinents,
                    mapSize: MapPropertyLib.NonStandardMapSizeProp(MapSize.Duel, MapSize.Small, MapSize.Standard, MapSize.Large),
                    sizedMaps: new Dictionary<MapSize, SaveString>()
                    {
                        { MapSize.Duel, @"Assets\DLC\DLC_SP_Maps_2\Maps\Random_Africa_Duel.Civ5Map" },
                        { MapSize.Small, @"Assets\DLC\DLC_SP_Maps_2\Maps\Random_Africa_Small.Civ5Map" },
                        { MapSize.Standard, @"Assets\DLC\DLC_SP_Maps_2\Maps\Random_Africa_Standard.Civ5Map" },
                        { MapSize.Large, @"Assets\DLC\DLC_SP_Maps_2\Maps\Random_Africa_Large.Civ5Map" },
                    }
                );
            }
        }

        public static Map Amazon
        {
            get
            {
                return new Map
                (
                    name: "Amazon",
                    saveName: @"Assets\DLC\DLC_SP_Maps\Maps\Amazon.lua",
                    requirement: Expansion.ExplorersMapPack
                );
            }
        }
        public static Map AmazonPlus
        {
            get
            {
                return new Map
                (
                    name: "Amazon Plus",
                    saveName: @"Assets\DLC\Expansion\Maps\Amazon_XP.lua",
                    requirement: Expansion.GodsAndKings
                );
            }
        }
        public static Map Americas
        {
            get
            {
                return new Map
                (
                    name: "Americas",
                    saveName: @"Assets\Maps\Americas.Civ5Map"
                );
            }
        }
        public static Map AncientLakes
        {
            get
            {
                return new Map
                (
                    name: "Ancient Lakes",
                    saveName: @"Assets\Maps\M_AncientLake.Civ5Map"
                );
            }
        }
        public static Map Arborea
        {
            get
            {
                return new Map
                (
                    name: "Arborea",
                    saveName: @"Assets\DLC\Expansion\Maps\Arborea.lua",
                    requirement: Expansion.GodsAndKings,
                    mapProperties: MapPropertyLib.StandardSetPlus
                    (
                        new Tuple<int, GameProperty> (3, MapPropertyLib.SeaLevelProp),
                        new Tuple<int, GameProperty> (-1, MapPropertyLib.FullLandmassProp)
                    )
                );
            }
        }
        public static Map Archipelago
        {
            get
            {
                return new Map
                (
                    name: "Archipelago",
                    saveName: @"Assets\Maps\Archipelago.lua",
                    mapProperties: MapPropertyLib.StandardSetWithSeaLevel
                );
            }
        }
        public static Map Asia
        {
            get
            {
                return new Map
                (
                    name: "Asia",
                    saveName: @"Assets\Maps\Asia.Civ5Map"
                );
            }
        }
        public static Map Australia
        {
            get
            {
                return new Map
                (
                    name: "Australia Scrambled",
                    requirement: Expansion.ScrambledNations,
                    mapSize: MapPropertyLib.NonStandardMapSizeProp(MapSize.Duel, MapSize.Small, MapSize.Standard, MapSize.Large),
                    sizedMaps: new Dictionary<MapSize, SaveString>()
                    {
                        { MapSize.Duel, @"Assets\DLC\DLC_SP_Maps_3\Maps\Random_Australia_Duel.Civ5Map" },
                        { MapSize.Small, @"Assets\DLC\DLC_SP_Maps_3\Maps\Random_Australia_Small.Civ5Map" },
                        { MapSize.Standard, @"Assets\DLC\DLC_SP_Maps_3\Maps\Random_Australia_Standard.Civ5Map" },
                        { MapSize.Large, @"Assets\DLC\DLC_SP_Maps_3\Maps\Random_Australia_Large.Civ5Map" },
                    }
                );
            }
        }
        public static Map BeringStrait
        {
            get
            {
                return new Map
                (
                    name: "Bering Strait",
                    saveName: @"Assets\DLC\DLC_SP_Maps\Maps\BeringStrait.Civ5Map",
                    requirement: Expansion.ExplorersMapPack,
                    mapSize: MapPropertyLib.NonStandardMapSizeProp(MapSize.Standard)
                );
            }
        }
        public static Map Boreal
        {
            get
            {
                return new Map
                (
                    name: "Boreal",
                    saveName: @"Assets\DLC\Expansion\Maps\Boreal.lua",
                    requirement: Expansion.GodsAndKings,
                    mapProperties: new GameProperty[]
                    {
                        MapPropertyLib.WorldAgeProp,
                        MapPropertyLib.RainfallProp,
                        MapPropertyLib.ResourcesProp
                    }
                );
            }
        }
        public static Map BritishIsles
        {
            get
            {
                return new Map
                (
                    name: "British Isles",
                    saveName: @"Assets\DLC\DLC_SP_Maps\Maps\BritishIsles.Civ5Map",
                    requirement: Expansion.ExplorersMapPack,
                    mapSize: MapPropertyLib.NonStandardMapSizeProp(MapSize.Standard)
                );
            }
        }
        public static Map Canada
        {
            get
            {
                return new Map
                (
                    name: "Canada Scrambled",
                    requirement: Expansion.ScrambledNations,
                    mapSize: MapPropertyLib.NonStandardMapSizeProp(MapSize.Tiny, MapSize.Small, MapSize.Standard, MapSize.Large),
                    sizedMaps: new Dictionary<MapSize, SaveString>()
                    {
                        { MapSize.Tiny, @"Assets\DLC\DLC_SP_Maps_3\Maps\Random_Canada_Tiny.Civ5Map" },
                        { MapSize.Small, @"Assets\DLC\DLC_SP_Maps_3\Maps\Random_Canada_Small.Civ5Map" },
                        { MapSize.Standard, @"Assets\DLC\DLC_SP_Maps_3\Maps\Random_Canada_Standard.Civ5Map" },
                        { MapSize.Large, @"Assets\DLC\DLC_SP_Maps_3\Maps\Random_Canada_Large.Civ5Map" }
                    }
                );
            }
        }
        public static Map Caribbean
        {
            get
            {
                return new Map
                (
                    name: "Caribbean",
                    saveName: @"Assets\DLC\DLC_SP_Maps\Maps\Caribbean.Civ5Map",
                    requirement: Expansion.ExplorersMapPack,
                    mapSize: MapPropertyLib.NonStandardMapSizeProp(MapSize.Standard)
                );
            }
        }
        public static Map Continents
        {
            get
            {
                return new Map
                (
                    name: "Continents",
                    saveName: @"Assets\Maps\Continents.lua",
                    mapProperties: MapPropertyLib.StandardSetWithSeaLevel
                );
            }
        }
        public static Map ContinentsPlus
        {
            get
            {
                return new Map
                (
                    name: "Continents Plus",
                    saveName: @"Assets\DLC\DLC_SP_Maps\Maps\ContinentsPlus.lua",
                    requirement: Expansion.ExplorersMapPack,
                    mapProperties: MapPropertyLib.StandardSetWithSeaLevel
                );
            }
        }
        public static Map Donut
        {
            get
            {
                return new Map
                (
                    name: "Donut",
                    saveName: @"Assets\DLC\DLC_SP_Maps\Maps\Donut.lua",
                    requirement: Expansion.ExplorersMapPack,
                    mapProperties: new GameProperty[] { MapPropertyLib.CenterRegionProp }
                );
            }
        }
        public static Map Earth
		{
			get
			{
				return new Map
                (
                    name: "Earth",
                    sizedMaps: new Dictionary<MapSize, SaveString>()
                    {
                        { MapSize.Duel, @"Assets\Maps\Earth_Duel.Civ5Map" },
                        { MapSize.Tiny, @"Assets\Maps\Earth_Tiny.Civ5Map" },
                        { MapSize.Small, @"Assets\Maps\Earth_Small.Civ5Map" },
                        { MapSize.Standard, @"Assets\Maps\Earth_Standard.Civ5Map" },
                        { MapSize.Large, @"Assets\Maps\Earth_Large.Civ5Map" },
                        { MapSize.Huge, @"Assets\Maps\Earth_Huge.Civ5Map" }
                    }
                );
            }
        }
        public static Map EarthScrambled
        {
            get
            {
                return new Map
                (
                    name: "Earth Scrambled",
                    requirement: Expansion.ScrambledContinents,
                    sizedMaps: new Dictionary<MapSize, SaveString>()
                    {
                        { MapSize.Duel, @"Assets\DLC\DLC_SP_Maps_2\Maps\Random_Earth_Duel.Civ5Map" },
                        { MapSize.Tiny, @"Assets\DLC\DLC_SP_Maps_2\Maps\Random_Earth_Tiny.Civ5Map" },
                        { MapSize.Small, @"Assets\DLC\DLC_SP_Maps_2\Maps\Random_Earth_Small.Civ5Map" },
                        { MapSize.Standard, @"Assets\DLC\DLC_SP_Maps_2\Maps\Random_Earth_Standard.Civ5Map" },
                        { MapSize.Large, @"Assets\DLC\DLC_SP_Maps_2\Maps\Random_Earth_Large.Civ5Map" },
                        { MapSize.Huge, @"Assets\DLC\DLC_SP_Maps_2\Maps\Random_Earth_Huge.Civ5Map" }
                    }
                );
            }
        }
        public static Map EastAsia
        {
            get
            {
                return new Map
                (
                    name: "East Asia Scrambled",
                    requirement: Expansion.ScrambledContinents,
                    mapSize: MapPropertyLib.NonStandardMapSizeProp(MapSize.Small, MapSize.Large),
                    sizedMaps: new Dictionary<MapSize, SaveString>()
                    {
                        { MapSize.Small, @"Assets\DLC\DLC_SP_Maps_2\Maps\Random_Eastern_Asia_Small.Civ5Map" },
                        { MapSize.Large, @"Assets\DLC\DLC_SP_Maps_2\Maps\Random_Eastern_Asia_Large.Civ5Map" }
                    }
                );
            }
        }
        public static Map EasternUnitedStates 
		{
			get
			{
				return new Map
                (
                    name: "Eastern United States",
                    saveName: @"Assets\DLC\DLC_SP_Maps\Maps\EasternUnitedStates.Civ5Map",
                    requirement: Expansion.ExplorersMapPack,
                    mapSize: MapPropertyLib.NonStandardMapSizeProp(MapSize.Standard)
                );
            }
        }
        public static Map Europe 
		{
			get
			{
				return new Map
                (
                    name: "Europe",
                    saveName: @"Assets\DLC\Expansion\Maps\Europe.lua",
                    requirement: Expansion.GodsAndKings
                );
            }
        }
        public static Map FourCorners 
		{
			get
			{
				return new Map
                (
                    name: "Four Corners",
                    saveName: @"Assets\Maps\Four_Corners.lua",
                    mapProperties: MapPropertyLib.StandardSetPlus
                    (
                        new GameProperty("Buffer Zones", LandType.Ocean, new Dictionary<object, string>()
                        {
                            { LandType.Ocean, "Ocean" },
                            { LandType.Mountains, "Mountains" },
                            { LandType.Random, "Random" }
                        }),
                        MapPropertyLib.TeamSettingProp
                    )
                );
            }
        }
        public static Map Fractal 
		{
			get
			{
				return new Map
                (
                    name: "Fractal",
                    saveName: @"Assets\Maps\Fractal.lua"
                );
            }
        }
        public static Map Frontier 
		{
			get
			{
                return new Map
                (
                    name: "Frontier",
                    saveName: @"Assets\DLC\Expansion\Maps\Frontier.lua",
                    requirement: Expansion.GodsAndKings,
                    mapProperties: MapPropertyLib.StandardSetPlus
                    (
                        new Tuple<int, GameProperty> (3, MapPropertyLib.SeaLevelProp),
                        new Tuple<int, GameProperty> (-1, MapPropertyLib.BasicLandmassProp)
                    )
                );
            }
        }
        public static Map GreatPlains 
		{
			get
			{
				return new Map
                (
                    name: "Great Plains",
                    saveName: @"Assets\Maps\Great_Plains.lua"
                );
            }
        }
        public static Map GreatPlainsPlus 
		{
			get
			{
				return new Map
                (
                    name: "Great Plains Plus",
                    saveName: @"Assets\DLC\Expansion\Maps\Great_Plains_XP.lua",
                    requirement: Expansion.GodsAndKings
                );
            }
        }
        public static Map Hemispheres 
		{
			get
			{
				return new Map
                (
                    name: "Hemispheres",
                    saveName: @"Assets\DLC\Expansion\Maps\Hemispheres.lua",
                    requirement: Expansion.GodsAndKings,
                    mapProperties: new GameProperty[]
                    {
                        MapPropertyLib.WorldAgeProp,
                        MapPropertyLib.TemperatureProp,
                        MapPropertyLib.RainfallProp,
                        MapPropertyLib.ResourcesProp,
                        new GameProperty("Tiny Islands", Maps.TinyIslands.Various, EnumDefinitions.TinyIslandsAsDict),
                        MapPropertyLib.TeamSettingProp,
                    }
                );
            }
        }
        public static Map Highlands 
		{
			get
			{
				return new Map
                (
                    name: "Highlands",
                    saveName: @"Assets\Maps\Highlands.lua",
                    mapProperties: new GameProperty[]
                    {
                        MapPropertyLib.TemperatureProp,
                        MapPropertyLib.RainfallProp,
                        MapPropertyLib.ResourcesProp,
                        new GameProperty("Mountain Pattern", MountainPattern.Random, EnumDefinitions.MountainPatternAsDict),
                        new GameProperty("Mountain Density", MountainDensity.Random, EnumDefinitions.MountainDensityAsDict),
                        MapPropertyLib.BodiesOfWaterProp
                    }
                );
            }
        }
        public static Map IceAge 
		{
			get
			{
                return new Map
                (
                    name: "Ice Age",
                    saveName: @"Assets\Maps\Ice_Age.lua",
                    mapProperties: MapPropertyLib.StandardSetPlus
                    (
                        new Tuple<int, GameProperty> (3, MapPropertyLib.SeaLevelProp), 
                        new Tuple<int, GameProperty> (-1, new GameProperty("Landmass Type", LandmassAlt.Random, EnumDefinitions.LandmassAltAsDict)
                    ))
                );
            }
        }
        public static Map InlandSea 
		{
			get
			{
				return new Map
                (
                    name: "Inland Sea",
                    saveName: @"Assets\Maps\InlandSea.lua",
                    mapProperties: MapPropertyLib.StandardSet
                );
            }
        }
        public static Map Italy
        { 
            get
            {
                return new Map
                (
                    name: "Italy Scrambled",
                    requirement: Expansion.ScrambledNations,
                    mapSize: MapPropertyLib.NonStandardMapSizeProp(MapSize.Small, MapSize.Standard),
                    sizedMaps: new Dictionary<MapSize, SaveString>()
                    {
                        { MapSize.Small, @"Assets\DLC\DLC_SP_Maps_3\Maps\Random_Italy_Small.Civ5Map" },
                        { MapSize.Standard, @"Assets\DLC\DLC_SP_Maps_3\Maps\Random_Italy_Standard.Civ5Map" }
                    }
                );
            }
        }
        public static Map Japan
        {
            get
            {
                return new Map
                (
                    name: "Japan Scrambled",
                    requirement: Expansion.ScrambledNations,
                    mapSize: MapPropertyLib.NonStandardMapSizeProp(MapSize.Duel, MapSize.Small),
                    sizedMaps: new Dictionary<MapSize, SaveString>()
                    {
                        { MapSize.Duel, @"Assets\DLC\DLC_SP_Maps_3\Maps\Random_Japan_Duel.Civ5Map" },
                        { MapSize.Small, @"Assets\DLC\DLC_SP_Maps_3\Maps\Random_Japan_Small.Civ5Map" }
                    }
                );
            }
        }
        public static Map JapaneseMainland 
		{
			get
			{
				return new Map
                (
                    name: "Japanese Mainland",
                    saveName: @"Assets\DLC\DLC_SP_Maps\Maps\JapaneseMainland.Civ5Map",
                    requirement: Expansion.ExplorersMapPack,
                    mapSize: MapPropertyLib.NonStandardMapSizeProp(MapSize.Tiny)
                );
            }
        }
        public static Map Lakes 
		{
			get
			{
				return new Map
                (
                    name: "Lakes",
                    saveName: @"Assets\Maps\Lakes.lua",
                    mapProperties: new GameProperty[]
                    {
                        MapPropertyLib.WorldAgeProp,
                        MapPropertyLib.TemperatureProp,
                        MapPropertyLib.RainfallProp,
                        MapPropertyLib.ResourcesProp,
                        MapPropertyLib.BodiesOfWaterProp
                    }
                );
            }
        }
        public static Map LargeIslands 
		{
			get
			{
				return new Map
                (
                    name: "Large Islands",
                    saveName: @"Assets\DLC\Expansion\Maps\Large_Islands.lua",
                    requirement: Expansion.GodsAndKings,
                    mapProperties: MapPropertyLib.StandardSet
                );
            }
        }
        public static Map Mediterranean 
		{
			get
			{
				return new Map
                (
                    name: "Mediterranean",
                    saveName: @"Assets\Maps\Mediterranean.Civ5Map"
                );
            }
        }
        public static Map Mesopotamia 
		{
			get
			{
				return new Map
                (
                    name: "Mesopotamia",
                    saveName: @"Assets\Maps\Mesopotamia.Civ5Map"
                );
            }
        }
        public static Map MiddleEast
        {
            get
            {
                return new Map
                (
                    name: "Middle East Scrambled",
                    requirement: Expansion.ScrambledContinents,
                    mapSize: MapPropertyLib.NonStandardMapSizeProp(MapSize.Duel, MapSize.Tiny, MapSize.Small, MapSize.Standard, MapSize.Large),
                    sizedMaps: new Dictionary<MapSize, SaveString>()
                    {
                        { MapSize.Duel, @"Assets\DLC\DLC_SP_Maps_2\Maps\Random_Middle_East_Duel.Civ5Map" },
                        { MapSize.Tiny, @"Assets\DLC\DLC_SP_Maps_2\Maps\Random_Middle_East_Tiny.Civ5Map" },
                        { MapSize.Small, @"Assets\DLC\DLC_SP_Maps_2\Maps\Random_Middle_East_Small.Civ5Map" },
                        { MapSize.Standard, @"Assets\DLC\DLC_SP_Maps_2\Maps\Random_Middle_East_Standard.Civ5Map" },
                        { MapSize.Large, @"Assets\DLC\DLC_SP_Maps_2\Maps\Random_Middle_East_Large.Civ5Map" }
                    }
                );
            }
        }
        public static Map NorthAmerica
        {
            get
            {
                return new Map
                (
                    name: "North America Scrambled",
                    requirement: Expansion.ScrambledContinents,
                    sizedMaps: new Dictionary<MapSize, SaveString>()
                    {
                        { MapSize.Duel, @"Assets\DLC\DLC_SP_Maps_2\Maps\Random_North_America_Duel.Civ5Map" },
                        { MapSize.Tiny, @"Assets\DLC\DLC_SP_Maps_2\Maps\Random_North_America_Tiny.Civ5Map" },
                        { MapSize.Small, @"Assets\DLC\DLC_SP_Maps_2\Maps\Random_North_America_Small.Civ5Map" },
                        { MapSize.Standard, @"Assets\DLC\DLC_SP_Maps_2\Maps\Random_North_America_Standard.Civ5Map" },
                        { MapSize.Large, @"Assets\DLC\DLC_SP_Maps_2\Maps\Random_North_America_Large.Civ5Map" },
                        { MapSize.Huge, @"Assets\DLC\DLC_SP_Maps_2\Maps\Random_North_America_Huge.Civ5Map" }
                    }
                );
            }
        }
        public static Map NorthVsSouth 
		{
			get
			{
                return new Map
                (
                    name: "North vs South",
                    saveName: @"Assets\Maps\North_vs_South.lua",
                    mapProperties: MapPropertyLib.VersusSet
                );
            }
        }
        public static Map Oceania
        {
            get
            {
                return new Map
                (
                    name: "Oceania",
                    requirement: Expansion.ScrambledContinents,
                    saveName: @"Assets\DLC\DLC_SP_Maps_2\Maps\Script_Oceania.lua",
                    mapProperties: new GameProperty[] 
                    {
                        MapPropertyLib.RainfallProp,
                        MapPropertyLib.ResourcesProp,
                        new GameProperty("Ocean", Ocean.Large, EnumDefinitions.OceanAsDict)
                    }
                );
            }
        }
        public static Map Oval 
		{
			get
			{
				return new Map
                (
                    name: "Oval",
                    saveName: @"Assets\Maps\Oval.lua",
                    mapProperties: MapPropertyLib.StandardSetWithSeaLevel
                );
            }
        }
        public static Map Pangaea 
		{
			get
			{
				return new Map
                (
                    name: "Pangaea",
                    saveName: @"Assets\Maps\Pangaea.lua",
                    mapProperties: MapPropertyLib.StandardSetWithSeaLevel
                );
            }
        }
        public static Map PangaeaPlus 
		{
			get
			{
				return new Map
                (
                    name: "Pangaea Plus",
                    saveName: @"Assets\DLC\DLC_SP_Maps\Maps\PangaeaPlus.lua",
                    requirement: Expansion.ExplorersMapPack,
                    mapProperties: MapPropertyLib.StandardSetWithSeaLevel
                );
            }
        }
        public static Map Rainforest 
		{
			get
			{
				return new Map
                (
                    name: "Rainforest",
                    saveName: @"Assets\DLC\Expansion\Maps\Rainforest.lua",
                    requirement: Expansion.GodsAndKings,
                    mapProperties: MapPropertyLib.StandardSetPlus
                    (
                        new Tuple<int, GameProperty> (3, MapPropertyLib.SeaLevelProp), 
                        new Tuple<int, GameProperty> (-1, MapPropertyLib.FullLandmassProp)
                    )
                );
            }
        }
        public static Map Ring 
		{
			get
			{
				return new Map
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
                        MapPropertyLib.ResourcesProp
                    }
                );
            }
        }
        public static Map Russia
        {
            get
            {
                return new Map
                (
                    name: "Russia",
                    mapSize: MapPropertyLib.MapSizeProp,
                    sizedMaps: new Dictionary<MapSize, SaveString>()
                    {
                        { MapSize.Duel, @"Assets\DLC\DLC_SP_Maps_3\Maps\Random_Russia_Duel.Civ5Map" },
                        { MapSize.Tiny, @"Assets\DLC\DLC_SP_Maps_3\Maps\Random_Russia_Tiny.Civ5Map" },
                        { MapSize.Small, @"Assets\DLC\DLC_SP_Maps_3\Maps\Random_Russia_Small.Civ5Map" },
                        { MapSize.Standard, @"Assets\DLC\DLC_SP_Maps_3\Maps\Random_Russia_Standard.Civ5Map" },
                        { MapSize.Large, @"Assets\DLC\DLC_SP_Maps_3\Maps\Random_Russia_Large.Civ5Map" },
                        { MapSize.Huge, @"Assets\DLC\DLC_SP_Maps_3\Maps\Random_Russia_Huge.Civ5Map" }
                    }
                );
            }
        }
        public static Map Sandstorm 
		{
			get
			{
				return new Map
                (
                    name: "Sandstorm",
                    saveName: @"Assets\DLC\DLC_SP_Maps\Maps\Sandstorm.lua",
                    requirement: Expansion.ExplorersMapPack,
                    mapProperties: new GameProperty[]
                    {
                        MapPropertyLib.WorldAgeProp,
                        MapPropertyLib.SeaLevelProp,
                        MapPropertyLib.ResourcesProp,
                        MapPropertyLib.BasicLandmassProp
                    }
                );
            }
        }
        public static Map Scandinavia
        {
            get
            {
                return new Map
                (
                    name: "Scandinavia Scrambled",
                    requirement: Expansion.ScrambledNations,
                    mapSize: MapPropertyLib.NonStandardMapSizeProp(MapSize.Small, MapSize.Standard, MapSize.Large),
                    sizedMaps: new Dictionary<MapSize, SaveString>()
                    {
                        { MapSize.Small, @"Assets\DLC\DLC_SP_Maps_3\Maps\Random_Scandinavia_Small.Civ5Map" },
                        { MapSize.Standard, @"Assets\DLC\DLC_SP_Maps_3\Maps\Random_Scandinavia_Standard.Civ5Map" },
                        { MapSize.Large, @"Assets\DLC\DLC_SP_Maps_3\Maps\Random_Scandinavia_Large.Civ5Map" }
                    }
                );
            }
        }
        public static Map Shuffle 
		{
			get
			{
				return new Map
                (
                    name: "Shuffle",
                    saveName: @"Assets\DLC\Expansion\Maps\Shuffle.lua",
                    requirement: Expansion.GodsAndKings
                );
            }
        }
        public static Map Skirmish 
		{
			get
			{
				return new Map
                (
                    name: "Skirmish",
                    saveName: @"Assets\Maps\Skirmish.lua",
                    mapProperties: new GameProperty[] 
                    {
                        new GameProperty("Dominant Terrain", Terrain.Random, EnumDefinitions.TerrainAsDict),
                        new GameProperty("Water Setting", WaterSetting.Rivers, EnumDefinitions.WaterSettingAsDict),
                        MapPropertyLib.ResourcesProp
                    }
                );
            }
        }
        public static Map SmallContinents 
		{
			get
			{
				return new Map
                (
                    name: "Small Continents",
                    saveName: @"Assets\Maps\SmallContinents.lua",
                    mapProperties: MapPropertyLib.StandardSetWithSeaLevel
                );
            }
        }
        public static Map SmallContinentsPlus
        {
            get
            {
                return new Map
                (
                    name: "Small Continents Plus",
                    saveName: @"Assets\DLC\DLC_SP_Maps_2\Maps\Script_Small_Continents_Plus.lua",
                    requirement: Expansion.ScrambledContinents,
                    mapProperties: MapPropertyLib.StandardSetWithSeaLevel
                );
            }
        }
        public static Map Terra 
		{
			get
			{
				return new Map
                (
                    name: "Terra",
                    saveName: @"Assets\Maps\Terra.lua",
                    mapProperties: MapPropertyLib.StandardSet
                );
            }
        }
        public static Map TiltedAxis 
		{
			get
			{
				return new Map
                (
                    name: "Tilted Axis",
                    saveName: @"Assets\DLC\Expansion\Maps\Tilted_Axis.lua",
                    requirement: Expansion.GodsAndKings,
                    mapProperties: new GameProperty[] 
                    {
                        MapPropertyLib.WorldAgeProp,
                        MapPropertyLib.RainfallProp,
                        MapPropertyLib.SeaLevelProp,
                        MapPropertyLib.ResourcesProp,
                        MapPropertyLib.FullLandmassProp
                    }
                );
            }
        }
        public static Map TinyIslands
        {
            get
            {
                return new Map
                (
                    name: "Tiny Islands",
                    saveName: @"Assets\Maps\TinyIslands.lua",
                    mapProperties: new GameProperty[]
                    {
                        MapPropertyLib.WorldAgeProp,
                        MapPropertyLib.TemperatureProp,
                        MapPropertyLib.RainfallProp,
                        MapPropertyLib.SeaLevelProp
                    }
                );
            }
        }
        public static Map Turkey
        {
            get
            {
                return new Map
                (
                    name: "Turkey Scrambled",
                    requirement: Expansion.ScrambledNations,
                    mapSize: MapPropertyLib.NonStandardMapSizeProp(MapSize.Small, MapSize.Standard, MapSize.Large),
                    sizedMaps: new Dictionary<MapSize, SaveString>()
                    {
                        { MapSize.Small, @"Assets\DLC\DLC_SP_Maps_3\Maps\Random_Turkey_Small.Civ5Map" },
                        { MapSize.Standard, @"Assets\DLC\DLC_SP_Maps_3\Maps\Random_Turkey_Standard.Civ5Map" },
                        { MapSize.Large, @"Assets\DLC\DLC_SP_Maps_3\Maps\Random_Turkey_Large.Civ5Map" }
                    }
                );
            }
        }
        public static Map UnitedKingdom
        {
            get
            {
                return new Map
                (
                    name: "United Kingdom Scrambled",
                    requirement: Expansion.ScrambledNations,
                    mapSize: MapPropertyLib.NonStandardMapSizeProp(MapSize.Tiny, MapSize.Standard),
                    sizedMaps: new Dictionary<MapSize, SaveString>()
                    {
                        { MapSize.Tiny, @"Assets\DLC\DLC_SP_Maps_3\Maps\Random_UK_Tiny.Civ5Map" },
                        { MapSize.Standard, @"Assets\DLC\DLC_SP_Maps_3\Maps\Random_UK_Standard.Civ5Map" }
                    }
                );
            }
        }
        public static Map WestVsEast 
		{
			get
			{
				return new Map
                (
                    name: "West vs East",
                    saveName: @"Assets\Maps\West_vs_East.lua",
                    mapProperties: MapPropertyLib.VersusSet
                );
            }
        }
        public static Map WesternEurope
        {
            get
            {
                return new Map
                (
                    name: "Western Europe Scrambled",
                    requirement: Expansion.ScrambledNations,
                    mapSize: MapPropertyLib.NonStandardMapSizeProp(MapSize.Small, MapSize.Standard),
                    sizedMaps: new Dictionary<MapSize, SaveString>()
                    {
                        { MapSize.Small, @"Assets\DLC\DLC_SP_Maps_3\Maps\Random_Western_Europe_Small.Civ5Map" },
                        { MapSize.Standard, @"Assets\DLC\DLC_SP_Maps_3\Maps\Random_Western_Europe_Standard.Civ5Map" }
                    }
                );
            }
        }

    }
}
