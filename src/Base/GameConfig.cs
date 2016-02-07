using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MRobot.Civilization.Civ5;
using MRobot.Civilization.Civ5.Data;

namespace MRobot.Civilization.Base
{
    public abstract class GameConfig
    {
        protected GameConfig()
        {
            Version = CurrentVersion();
            Build = CurrentBuild();

            RandomSeed = new Random().Next(int.MinValue, int.MaxValue);

            Name = "My Game";
            GameMode = GameMode.HotSeat;

            _Expansions = new HashSet<Expansion>();

            Mods = new HashSet<Mod>();

            GamePace = CreateGamePaceProperty(Civ5.Data.GamePace.Quick);
        }

        protected static IGameProperty<GamePace> CreateGamePaceProperty(GamePace defaultPace)
        {
            return new GameProperty<GamePace>("Game Pace", defaultPace, GamePaceDict.GamePaceAsDict);
        }

        public SaveString Name { get; set; }
        public GameMode GameMode { get; set; }

        public SaveString Version { get; protected set; }
        public SaveString Build { get; protected set; }

        public int RandomSeed { get; protected set; }

        public IGameProperty<GamePace> GamePace { get; private set; }

        public ISet<Mod> Mods { get; private set; }

        protected readonly ISet<Expansion> _Expansions;

        protected abstract string CurrentVersion();
        protected abstract string CurrentBuild();
    }
}
