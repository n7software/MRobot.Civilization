using MRobot.Civilization.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MRobot.Civilization.Civ5
{
    public abstract class CivilizationMinor : BaseSaveItem, ICivilization
    {
        internal CivilizationMinor(string name = "", PlayerColor color = null)
            : base("MINOR", name)
        {
            Color = color;
        }
        public PlayerColor Color { get; set; }

        public int Id
        {
            get { return -1; }
        }

        public Leader Leader { get; set; }

        public Expansion Requirement
        {
            get { return null; }
        }
    }
}
