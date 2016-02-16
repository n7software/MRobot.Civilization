using MRobot.Civilization.Base;
using MRobot.Civilization.Civ5.Data;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MRobot.Civilization.Civ5.Save
{
    internal class SaveReader : Base.SaveReader
    {
        public SaveReader(Stream input)
            :base (input)
        {
        }

        public SaveReader(Stream input, int length)
            :base (input, length)
        {
        }

        public GameEra ReadEra() 
            => (GameEra)(ReadEnum(typeof(GameEra)) ?? GameEra.Ancient);

        public GamePace ReadPace() 
            => (GamePace)(ReadEnum(typeof(GamePace)) ?? GamePace.Quick);

        protected override IEnumerable<PlayerDifficulty> AllDifficulties() 
            => PlayerDifficulties.All;

        protected override IEnumerable<Leader> AllLeaders() 
            => Leaders.All;

        protected override IEnumerable<MapSize> AllMapSizes() 
            => MapSizes.All;

        protected override IEnumerable<PlayerColor> AllPlayerColors() 
            => PlayerColors.All;

        protected override PlayerDifficulty DefaultDifficulty() 
            => PlayerDifficulties.Chieftain;

        protected override Leader DefaultLeader() 
            => Leaders.Barbarian;

        protected override MapSize DefaultMapSize() 
            => MapSizes.Standard;

        protected override ICivilization FindCivBySaveName(SaveString civStr) 
            => Civilizations.FindBySaveName(civStr);

        protected override Base.Map FindMapByPath(SaveString saveString) 
            => Maps.FindByPath(saveString);

        protected override GameProperty<MapSize> GetNonStandardMapSize(MapSize size) 
            => Data.MapProperties.NonStandardMapSizeProp(new[] { size });
    }
}
