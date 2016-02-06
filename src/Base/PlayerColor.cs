using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MRobot.Civilization.Base
{
    public partial class PlayerColor : BaseSaveItem
    {
        internal PlayerColor(string name)
            : base("PLAYERCOLOR", name)
        { }
    }
}
