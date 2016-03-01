using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MRobot.Civilization.Base;
using MRobot.Civilization.Civ5.Data;

namespace MRobot.Civilization.Civ5
{
    internal class CivSaveService : ICivSaveService
    {
        public IEnumerable<ICivilization> AllCivilizations => Civilizations.GetAll();

        public IEnumerable<Expansion> AllExpansions => Expansions.All;

        public IEnumerable<Base.Map> AllMaps => Maps.GetAllDefaultMaps();
    }
}
