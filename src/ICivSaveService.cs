using MRobot.Civilization.Base;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MRobot.Civilization
{
    public interface ICivSaveService
    {
        IEnumerable<ICivilization> AllCivilizations { get; }

        ICivilization UknownCiv { get; }

        ICivilization FindCivById(int id);
        
        IEnumerable<Expansion> AllExpansions { get; }

        IEnumerable<Map> AllMaps { get; }

        IEnumerable<PlayerDifficulty> AllDifficulties { get; }

        PlayerDifficulty DefaultPlayerDifficulty { get; }

        GameConfig LoadGameConfig(Stream saveStream);

        IDictionary<string, string> DefaultGameWorldOptions { get; }

        GameConfig CreateNewGame();
    }
}
