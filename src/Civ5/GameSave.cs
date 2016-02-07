using System;
using MRobot.Civilization.Civ5.Data;

namespace MRobot.Civilization.Civ5.Save
{
    public partial class GameSave : Save.GameConfig
    {
        private GameSave()
            : base()
        {
            HeaderCurrentEra = GameEraProps.Vanilla;
        }

        private long RawGameDataIndex;

        private byte[] _OriginalBytes;

        public byte[] OriginalBytes
        { 
            get { return (byte[])_OriginalBytes.Clone(); }
        }

        private byte[] RawGameData
        {
            get
            {
                byte[] buffer = new byte[_OriginalBytes.Length - RawGameDataIndex];
                Array.Copy(_OriginalBytes, RawGameDataIndex, buffer, 0, buffer.Length);
                return buffer;
            }
        }

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

        protected override void WriteCurrentTurnNumber(SaveWriter output)
        {
            output.Write(TurnNumber);
        }

        protected override void WriteCurrentEra(SaveWriter output)
        {
            output.Write(SaveHelpers.ConvertOptionEnumToSaveStr(HeaderCurrentEra.Value).Bytes);
        }

        protected override void WritePlayerColor(SaveWriter output)
        {
            output.Write(Players[0].Civilization.Color.SaveName.Bytes);
        }

        static readonly SaveString CityStateCivName = new SaveString("CIVILIZATION", "MINOR");

        protected override void WriteCityStates(SaveWriter output)
        {
            for (int i = SaveHelpers.MaxPlayers; i < Players.Length - 1; i++)
            {
                if (Players[i].Civilization != null)
                    output.Write(CityStateCivName.Bytes);
                else output.Write(0x00);
            }
        }

        protected override void WriteMinorCivs(SaveWriter output)
        {
            for (int i = SaveHelpers.MaxPlayers; i < Players.Length - 1; i++)
            {
                if (Players[i].Civilization != null)
                    output.Write(Players[i].Civilization.SaveName.Bytes);
                else output.Write(0x00);
            }
        }

        protected override void WriteLeaders(SaveWriter output)
        {
            for (int i = 0; i < Players.Length; i++)
            {
                if (Players[i].Civilization != null)
                    output.Write(Players[i].Civilization.Leader.SaveName.Bytes);
                else output.Write(0x00);
            }
        }

        protected override void WriteCurrentPlayerIndex(SaveWriter output)
        {
            output.Write(CurrentPlayerIndex);
        }

        protected override void WritePlayerColors(SaveWriter output)
        {
            for(int i = 0; i < Players.Length; i++)
            {
                if (Players[i].Civilization != null)
                    output.Write(Players[i].Civilization.Color.SaveName.Bytes);
                else output.Write(0x00);
            }
        }

        protected override void WriteRawGameData(SaveWriter output)
        {
            output.Write(RawGameData);
        }
        #endregion
    }
}
