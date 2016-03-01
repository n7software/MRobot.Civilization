using MRobot.Civilization.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MRobot.Civilization
{
    public interface ICivSaveService
    {
        IEnumerable<ICivilization> AllCivilizations { get; }

        IEnumerable<Expansion> AllExpansions { get; }

        IEnumerable<Map> AllMaps { get; }        
    }
}
