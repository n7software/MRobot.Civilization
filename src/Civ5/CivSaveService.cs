using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MRobot.Civilization.Base;
using MRobot.Civilization.Civ5.Data;
using System.IO;

namespace MRobot.Civilization.Civ5
{
    internal class CivSaveService : ICivSaveService
    {
        public IEnumerable<ICivilization> AllCivilizations => Civilizations.GetAll();

        public IEnumerable<PlayerDifficulty> AllDifficulties => PlayerDifficulties.All;

        public PlayerDifficulty DefaultPlayerDifficulty => PlayerDifficulties.Prince;

        public IEnumerable<Expansion> AllExpansions => Expansions.All;

        public IEnumerable<Base.Map> AllMaps => Maps.GetAllDefaultMaps();

        public ICivilization UknownCiv => Civilizations.Unknown;

        public ICivilization FindCivById(int id)
        {
            return Civilizations.FindById(id);
        }

        public Base.GameConfig LoadGameConfig(Stream saveStream)
        {
            return Save.GameLoader.Load(saveStream);
        }

        public IDictionary<string, string> DefaultGameWorldOptions
        {
            get
            {
                return new Dictionary<string, string>
                {
                    [typeof(GamePace).Name] = GamePace.Quick.ToString(),
                    [typeof(Map).Name] = Maps.Continents.ToString(),
                    [typeof(MapSize).Name] = MapSizes.Standard.ToString(),
                    ["CityStates"] = Maps.Continents.NumberOfCityStates.ToString()
                };
            }
        }

        public Base.GameConfig CreateNewGame()
        {
            return new GameSave();
        }
    }
}
