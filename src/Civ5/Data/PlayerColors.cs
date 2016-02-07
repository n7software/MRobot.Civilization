using System.Collections.Generic;
using MRobot.Civilization.Base;

namespace MRobot.Civilization.Civ5.Data
{
    public class PlayerColors
    {
        private static IList<PlayerColor> _all;
        public static IList<PlayerColor> All => _all ?? (_all = Utils.GetStaticFieldsOfType<PlayerColor>());

        public static readonly PlayerColor America = new PlayerColor("America");
        public static readonly PlayerColor Arabia = new PlayerColor("Arabia");
        public static readonly PlayerColor Assyria = new PlayerColor("Assyria");
        public static readonly PlayerColor Austria = new PlayerColor("Austria");
        public static readonly PlayerColor Aztecs = new PlayerColor("Aztecs");
        public static readonly PlayerColor Babylon = new PlayerColor("Babylon");
        public static readonly PlayerColor Brazil = new PlayerColor("Brazil");
        public static readonly PlayerColor Byzantium = new PlayerColor("Byzantium");
        public static readonly PlayerColor Carthage = new PlayerColor("Carthage");
        public static readonly PlayerColor Celts = new PlayerColor("Celts");
        public static readonly PlayerColor China = new PlayerColor("China");
        public static readonly PlayerColor Denmark = new PlayerColor("Denmark");
        public static readonly PlayerColor Egypt = new PlayerColor("Egypt");
        public static readonly PlayerColor England = new PlayerColor("England");
        public static readonly PlayerColor Ethiopia = new PlayerColor("Ethiopia");
        public static readonly PlayerColor France = new PlayerColor("France");
        public static readonly PlayerColor Germany = new PlayerColor("Germany");
        public static readonly PlayerColor Greece = new PlayerColor("Greece");
        public static readonly PlayerColor Huns = new PlayerColor("Huns");
        public static readonly PlayerColor Inca = new PlayerColor("Inca");
        public static readonly PlayerColor India = new PlayerColor("India");
        public static readonly PlayerColor Indonesia = new PlayerColor("Indonesia");
        public static readonly PlayerColor Iroquois = new PlayerColor("Iroquois");
        public static readonly PlayerColor Japan = new PlayerColor("Japan");
        public static readonly PlayerColor Korea = new PlayerColor("Korea");
        public static readonly PlayerColor Maya = new PlayerColor("Maya");
        public static readonly PlayerColor Mongolia = new PlayerColor("Mongolia");
        public static readonly PlayerColor Morocco = new PlayerColor("Morocco");
        public static readonly PlayerColor Netherlands = new PlayerColor("Netherlands");
        public static readonly PlayerColor Ottomans = new PlayerColor("Ottomans");
        public static readonly PlayerColor Persia = new PlayerColor("Persia");
        public static readonly PlayerColor Poland = new PlayerColor("Poland");
        public static readonly PlayerColor Polynesia = new PlayerColor("Polynesia");
        public static readonly PlayerColor Portugal = new PlayerColor("Portugal");
        public static readonly PlayerColor Rome = new PlayerColor("Rome");
        public static readonly PlayerColor Russia = new PlayerColor("Russia");
        public static readonly PlayerColor Shoshone = new PlayerColor("Shoshone");
        public static readonly PlayerColor Siam = new PlayerColor("Siam");
        public static readonly PlayerColor Songhai = new PlayerColor("Songhai");
        public static readonly PlayerColor Spain = new PlayerColor("Spain");
        public static readonly PlayerColor Sweden = new PlayerColor("Sweden");
        public static readonly PlayerColor Venice = new PlayerColor("Venice");
        public static readonly PlayerColor Zulus = new PlayerColor("Zulus");
    }
}
