using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MRobot.CivilizationV.Game.Maps
{
    public enum WorldAge
    {
        ThreeBillionYears,
        FourBillionYears,
        FiveBillionYears,
        Random
    }

    static partial class EnumDefinitions
    {
        public static IDictionary<object, string> WorldAgeAsDict
        {
            get
            {
                return new Dictionary<object, string>()
                {
                    { WorldAge.ThreeBillionYears,   "3 Billion Years" },
                    { WorldAge.FourBillionYears,    "4 Billion Years" },
                    { WorldAge.FiveBillionYears,    "5 Billion Years" },
                    { WorldAge.Random,              "Random" },
                };
            }
        }
    }
}
