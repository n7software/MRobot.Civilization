using MRobot.Civilization.Base;
using MRobot.Civilization.Civ5.Save;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MRobot.Civilization
{
    public static class CivSaveServices
    {
        public static ICivSaveService Civ5 => new Civ5.CivSaveService();

        public static ICivSaveService CivBe => new CivBE.CivSaveService();

        public static ICivSaveService FromSteamId(int steamGameId)
        {
            switch (steamGameId)
            {
                case GameSteamIds.CivV:
                    return Civ5;

                case GameSteamIds.BeyondEarth:
                    return CivBe;

                default:
                    throw new InvalidOperationException($"Invalid steam game id: {steamGameId}");
            }
        }

        public static GameConfig ReadSaveFile(Stream saveStream, int expectedLength)
        {
            var reader = new BinaryReader(saveStream);
            char[] fileStart = reader.ReadChars(4);

            if (fileStart[3] == 'B')
            {
                // Load as a CivBE save
            }
            else if (fileStart[3] == '5')
            {
                return GameLoader.Load(saveStream, expectedLength, true);
            }

            throw new InvalidSaveException($"Could not determine game type for save file. File start: {new string(fileStart)}");
        }

        public static IEnumerable<Expansion> GetAllExpansions()
        {
            var expansions = Civ5.AllExpansions.ToList();
            expansions.AddRange(CivBe.AllExpansions);
            return expansions;
        }

        public static IEnumerable<Map> GetAllMaps()
        {
            var maps = Civ5.AllMaps.ToList();
            maps.AddRange(CivBe.AllMaps);
            return maps;
        }

        public static int GetDefaultCityStateCount(MapSize mapSize)
        {
            var map = Civilization.Civ5.Data.Maps.Continents;
            map.SetMapSize(mapSize);
            return map.NumberOfCityStates;
        }        
    }
}
