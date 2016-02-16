using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        }

        public SaveString Name { get; set; }
        public GameMode GameMode { get; set; }

        public SaveString Version { get; internal set; }
        public SaveString Build { get; internal set; }

        public Map Map { get; set; }

        public int RandomSeed { get; set; }

        public ISet<Mod> Mods { get; private set; }

        public Player[] Players { get; protected set; }

        protected readonly ISet<Expansion> _Expansions;

        protected abstract string CurrentVersion();
        protected abstract string CurrentBuild();
    }
}
