using MRobot.CivilizationV.Game;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace MRobot.CivilizationV
{
    public class SaveWriter : BinaryWriter
    {
        private GameConfig Save;

        public SaveWriter(Stream output, GameConfig save)
            : base(output)
        {
            Save = save;
        }

        public void WriteEmptyBlocks(int count)
        {
            for (int i = 0; i < count; i++)
                this.Write(0x00);
        }

        public void WriteFullBlocks(int count)
        {
            for (int i = 0; i < count; i++)
                this.Write(SaveHelpers.FullBlock);
        }

        public void WriteEmptySection()
        {
            this.Write(SaveHelpers.SectionDelimiter);
            this.WriteEmptyBlocks(SaveHelpers.StandardSectionBlockCount);
        }

        public void WriteFullSection()
        {
            this.Write(SaveHelpers.SectionDelimiter);
            this.WriteFullBlocks(SaveHelpers.StandardSectionBlockCount);
        }

        public void WriteGamePreference(string preference, bool value)
        {
            var pref = new SaveString("GAMEOPTION", preference, true);
            this.Write(pref.Bytes);
            this.Write(value ? 1 : 0);
        }

        public void WritePlayerCivs()
        {
            for (int i = 0; i < SaveHelpers.MaxPlayers; i++)
            {
                if (Save.Players[i].Civilization != null)
                    this.Write(Save.Players[i].Civilization.SaveName.Bytes);
                else this.Write(0x00);
            }
        }

        public void WritePlayerTeamsSection()
        {
            this.Write(SaveHelpers.SectionDelimiter);
            for (int i = 0; i < SaveHelpers.StandardSectionBlockCount; i++)
            {
                if (i < Save.Players.Length && Save.Players[i].Team.HasValue)
                    this.Write(Save.Players[i].Team.Value);
                else this.Write(i);
            }
        }

        public void WritePlayerTypeSection()
        {
            this.Write(SaveHelpers.SectionDelimiter);
            for (int i = 0; i < Save.Players.Length; i++)
                this.Write((int)Save.Players[i].Type);
        }

        public void WritePlayerSlotsSection()
        {
            this.Write(SaveHelpers.SectionDelimiter);
            int maxPlayers = (int)Save.Map.Size.Value;
            for (int i = 0; i < SaveHelpers.StandardSectionBlockCount; i++)
            {
                if (i < maxPlayers && (Save.Players[i].Type == PlayerType.Human || Save.Players[i].Type == PlayerType.AI))
                    this.Write(0x02);
                else this.Write(0x00);
            }
        }

        public void WritePlayerNamesSection()
        {
            this.Write(SaveHelpers.SectionDelimiter);
            for (int i = 0; i < Save.Players.Length; i++)
                this.Write(Save.Players[i].Name.Bytes);
        }

        public void WritePlayerPasswords()
        {
            for (int i = 0; i < Save.Players.Length; i++)
                this.Write(Save.Players[i].Password.Bytes);
        }

        public void WritePlayerDifficultiesSection(bool bnw)
        {
            this.Write(SaveHelpers.SectionDelimiter);
            for (int i = 0; i < Save.Players.Length - 1; i++)
            {
                var difficulty = Save.Players[i].Difficulty;
                if (!bnw && difficulty == PlayerDifficulty.AI)
                    difficulty = PlayerDifficulty.Chieftain;
                this.Write((int)difficulty);
            }
            //Player 64 (barbarians) is a special case
            this.Write((int)PlayerDifficulty.Chieftain);
        }

        public void WriteTextKey(string prefix, string value, bool worldSize = false)
        {
            SaveString noPrefix = value;
            SaveString withPrefix = new SaveString(prefix, value, true);
            noPrefix.AllCaps = false;
            this.Write(noPrefix.Bytes);

            if (worldSize)
            {
                SaveString helpStr = new SaveString(SaveHelpers.TextKeyPrefix + "WORLD", value + "_HELP", true);
                this.Write(helpStr.Bytes);
            }
            else this.Write(0x00);

            this.WriteEmptyBlocks(2);

            this.Write(withPrefix.Bytes);
            withPrefix.Prefix = SaveHelpers.TextKeyPrefix + withPrefix.Prefix;
            if (worldSize)
                withPrefix.Prefix = withPrefix.Prefix.Remove(withPrefix.Prefix.IndexOf("SIZE"), 4);
            this.Write(withPrefix.Bytes);
            this.Write(noPrefix.Bytes);
        }

    }
}
