using System.Collections.Generic;

namespace MRobot.Civilization.Game
{
    public enum GameEra
    {
        Ancient = 0,
        Classical = 1,
        Medieval = 2,
        Renaissance = 3,
        Industrial = 4,
        Modern = 5,
        Future = 6,
        Postmodern = 7,
    }

    static class GameEraProps
    {
        public static IGameProperty<GameEra> Vanilla
        {
            get
            {
                return new GameProperty<GameEra>("Starting Era", GameEra.Ancient, VanillaDict);
            }
        }

        private static IDictionary<GameEra, string> VanillaDict
        {
            get
            {
                return new Dictionary<GameEra, string>()
                {
                    { GameEra.Ancient,     "Ancient Era" },
                    { GameEra.Classical,   "Classical Era" },
                    { GameEra.Medieval,    "Medieval Era" },
                    { GameEra.Renaissance, "Renaissance Era" },
                    { GameEra.Industrial,  "Industrial Era" },
                    { GameEra.Modern,      "Modern Era" },
                    { GameEra.Future,      "Future Era" }
                };
            }
        }

        public static IGameProperty<GameEra> Expansions
        {
            get
            {
                return new GameProperty<GameEra>("Starting Era", GameEra.Ancient, ExpansionsDict);
            }
        }

        private static IDictionary<GameEra, string> ExpansionsDict
        {
            get
            {
                return new Dictionary<GameEra, string>()
                {
                    { GameEra.Ancient,     "Ancient Era" },
                    { GameEra.Classical,   "Classical Era" },
                    { GameEra.Medieval,    "Medieval Era" },
                    { GameEra.Renaissance, "Renaissance Era" },
                    { GameEra.Industrial,  "Industrial Era" },
                    { GameEra.Modern,      "Modern Era" },
                    { GameEra.Postmodern,  "Atomic Era" },
                    { GameEra.Future,      "Information Era" }
                };
            }
        }
    }
}
