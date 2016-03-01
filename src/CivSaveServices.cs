using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MRobot.Civilization
{
    public static class CivSaveServices
    {
        public static ICivSaveService Civ5 => new Civ5.CivSaveService();

        public static ICivSaveService CivBe => new CivBE.CivSaveService();
    }
}
