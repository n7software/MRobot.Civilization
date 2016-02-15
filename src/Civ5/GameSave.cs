using System;
using System.IO;
using System.Linq;
using MRobot.Civilization.Civ5.Data;
using MRobot.Civilization.Civ5.Save;

namespace MRobot.Civilization.Civ5
{
    public class GameSave : GameConfig
    {
        private int _rawGameDataIndex;

        private byte[] _originalBytes;

        internal GameSave()
            : base()
        {
            HeaderCurrentEra = GameEraProps.Vanilla;
        }

        public static GameSave FromBytes(byte[] saveData)
        {
            using (var stream = new MemoryStream(saveData))
            {
                return GameSave.Load(stream);
            }
        }

        public byte[] OriginalBytes => _originalBytes.ToArray();

        private byte[] RawGameData => _originalBytes.Skip(_rawGameDataIndex).ToArray();

        public IGameProperty<GameEra> HeaderCurrentEra { get; private set; }

        public int TurnNumber { get; set; }

        public int CurrentPlayerIndex { get; set; }

        #region Overridden Methods

        protected override void SetPropertiesForExpansions()
        {
            HeaderCurrentEra = GameEraProps.Expansions;
            base.SetPropertiesForExpansions();
        }

        protected override void SetPropertiesForVanilla()
        {
            HeaderCurrentEra = GameEraProps.Vanilla;
            base.SetPropertiesForVanilla();
        }

        internal override int GetCurrentTurnNumber()
        {
            return TurnNumber;
        }

        internal override byte[] GetCurrentEra()
        {
            return GameSaver.ConvertOptionEnumToSaveStr(HeaderCurrentEra.Value).Bytes;
        }

        internal override byte[] GetPlayerColor()
        {
            return Players[0].Civilization.Color.SaveName.Bytes;
        }

        static readonly SaveString CityStateCivName = new SaveString("CIVILIZATION", "MINOR");

        internal override void WriteCityStates(SaveWriter output)
        {
            for (int i = SaveHelpers.MaxPlayers; i < Players.Length - 1; i++)
            {
                if (Players[i].Civilization != null)
                    output.Write(CityStateCivName.Bytes);
                else output.Write(0x00);
            }
        }

        internal override void WriteMinorCivs(SaveWriter output)
        {
            for (int i = SaveHelpers.MaxPlayers; i < Players.Length - 1; i++)
            {
                if (Players[i].Civilization != null)
                    output.Write(Players[i].Civilization.SaveName.Bytes);
                else output.Write(0x00);
            }
        }

        internal override void WriteLeaders(SaveWriter output)
        {
            for (int i = 0; i < Players.Length; i++)
            {
                if (Players[i].Civilization != null)
                    output.Write(Players[i].Civilization.Leader.SaveName.Bytes);
                else output.Write(0x00);
            }
        }

        internal override int GetCurrentPlayerIndex()
        {
            return CurrentPlayerIndex;
        }

        internal override void WritePlayerColors(SaveWriter output)
        {
            for(int i = 0; i < Players.Length; i++)
            {
                if (Players[i].Civilization != null)
                    output.Write(Players[i].Civilization.Color.SaveName.Bytes);
                else output.Write(0x00);
            }
        }

        internal override byte[] GetRawGameData()
        {
            return RawGameData;
        }
        #endregion
    }
}
