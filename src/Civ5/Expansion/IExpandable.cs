using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MRobot.CivilizationV
{
    /// <summary>
    /// Means that a certain item is expandable, and thus means that a specific instance's 
    /// availability could depent on the presence of a game expansion
    /// </summary>
    public interface IExpandable
    {
        Expansion Requirement { get; }
    }
}
