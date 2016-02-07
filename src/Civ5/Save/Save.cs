using System;
using System.IO;
using MRobot.Civilization.Base;
using MRobot.Civilization.Civ5.Data;

namespace MRobot.Civilization.Civ5.Save
{
    public partial class GameConfig
    {

        protected static readonly byte[] HeaderCrazyBytes = new byte[] { 0xB3, 0xB6, 0xB2, 0xC3, 0x9C, 0x43, 0x0B, 0x48, 0x85, 0x36, 0x1C, 0xF3, 0x9F, 0xCF, 0xC6, 0x82, 0x05, 0x00, 0x00, 0x00, 0x31, 0x2E, 0x30, 0x2E, 0x30, 0x2C, 0x15, 0x41, 0x0D, 0x8E, 0x94, 0x8F, 0x49, 0x8C, 0xDF, 0x69, 0x9D, 0x04, 0xC9, 0x8A, 0x95 };

        public byte[] ToBytes()
        {
            using (var stream = new MemoryStream())
            {
                this.Save(stream);
                return stream.ToArray();
            }
        }

        public virtual void Save(Stream stream)
        {
            var output = new SaveWriter(stream, this);

            #region Basic Game Information (Header, Expansions, Mods)

            #region Header
            output.Write(SaveHelpers.FileStart);
            output.Write(0x08);
            output.Write(this.Version.Bytes);
            output.Write(this.Build.Bytes);
            WriteCurrentTurnNumber(output);
            output.Write((byte)this.GameMode);

            var headerCiv =
                HeaderCiv != null ? HeaderCiv.SaveName.Bytes :
                Players[0].Civilization != null ? Players[0].Civilization.SaveName.Bytes :
                BitConverter.GetBytes(0x00);
            output.Write(headerCiv);
            var headerDifficulty =
                HeaderDifficulty.HasValue ? HeaderDifficulty.Value : Players[0].Difficulty;
            output.Write(SaveHelpers.ConvertOptionEnumToSaveStr(headerDifficulty).Bytes);
            output.Write(SaveHelpers.ConvertOptionEnumToSaveStr(this.HeaderStartingEra.Value).Bytes);
            WriteCurrentEra(output);
            output.Write(SaveHelpers.ConvertOptionEnumToSaveStr(this.GamePace.Value).Bytes);
            output.Write(SaveHelpers.ConvertOptionEnumToSaveStr(this.Map.Size.Value).Bytes);

            output.Write(this.Map.Path.Bytes);
            #endregion

            #region Expansions
            output.Write(this._Expansions.Count);
            foreach (var expansion in this.Expansions)
            {
                output.Write(expansion.SaveId);
                output.Write(0x01);
                output.Write(expansion.SaveName.Bytes);
            }
            #endregion

            #region Mods
            output.Write(Mods.Count);
            foreach (var mod in this.Mods)
            {
                output.Write(mod.SaveId.Bytes);
                output.Write(0x01);
                output.Write(mod.SaveName.Bytes);
            }
            #endregion

            #endregion

            #region Nothing Important

            #region Unknown + Map Path
            output.WriteEmptyBlocks(2);
            WritePlayerColor(output);
            output.Write(HeaderCrazyBytes);
            output.Write(0x00);
            output.Write(0x03);
            output.Write(0x03);
            output.Write(0x02);

            output.Write(this.Map.Path.Bytes);
            #endregion

            output.Write(SaveHelpers.SectionDelimiter);
            output.WriteFullBlocks(SaveHelpers.StandardSectionBlockCount);
            #endregion

            #region Player Information

            output.WritePlayerNamesSection();
            output.WritePlayerTypeSection();
            output.WritePlayerSlotsSection();
            output.WritePlayerTeamsSection();
            output.WritePlayerDifficultiesSection(this.Expansions.Contains(Expansions.BraveNewWorld));

            WriteCivilizationsSection(output);

            WriteLeadersSection(output);

            #region Current Player Index
            output.Write(0x06);
            WriteCurrentPlayerIndex(output);
            output.WriteEmptyBlocks(3);
            #endregion

            #endregion

            #region Nothing Important

            #region Mostly Blank
            output.Write(SaveHelpers.SectionDelimiter);
            output.WriteFullBlocks(SaveHelpers.StandardSectionBlockCount);
            output.WriteEmptyBlocks(2);
            output.Write((byte)0x00);
            output.Write(0x02);
            output.Write(0x00);
            output.Write(SaveHelpers.FullBlock);
            output.WriteEmptyBlocks(8);
            #endregion

            output.WriteEmptySection();
            output.WriteEmptySection();

            #endregion

            WritePlayerPasswordsSection(output);

            #region Starting Era + Temperature Text Key + Unimportant Things

            #region Blank
            output.Write(SaveHelpers.SectionDelimiter);
            output.WriteEmptyBlocks(67);
            #endregion

            output.WriteTextKey("CLIMATE", "Temperate");

            #region Actual Starting Era
            output.Write(0x00);
            output.Write(0x05);
            output.Write(0x05);
            output.Write(0x19);
            output.WriteEmptyBlocks(5);
            output.Write(new byte[] { 0x33, 0x33, 0x73, 0x3F, 0x00, 0x00, 0x80, 0x3E });

            var startingEra = this.StartingEra.Value;
            var startingEraList = this.StartingEra.PossibleValues.Keys.ToList();
            int startingEraIndex = startingEraList.IndexOf(startingEra);
            output.Write(startingEraIndex);
            #endregion

            #region Blank
            output.Write(SaveHelpers.SectionDelimiter);
            output.WriteEmptyBlocks(65);
            #endregion

            #region Blank
            output.Write(SaveHelpers.SectionDelimiter);
            output.WriteEmptyBlocks(64);
            #endregion

            #region Blank
            output.Write(0x07);
            output.Write(new byte[] { 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 });
            #endregion

            #endregion

            #region Game Name + Time Offset + Turn Number
            output.WriteFullBlocks(1);
            output.Write(Name.Bytes);
            output.Write(TimeOffset);
            output.Write(GameStarted);
            WriteCurrentTurnNumber(output);
            output.Write((byte)0x02);
            output.WriteEmptyBlocks(2);
            #endregion

            output.WritePlayerDifficultiesSection(this.Expansions.Contains(Expansions.BraveNewWorld));

            #region Nothing Important

            #region Mostly Blank
            output.Write(SaveHelpers.SectionDelimiter);
            output.Write(0x03);
            output.WriteFullBlocks(SaveHelpers.StandardSectionBlockCount - 1);
            output.Write((byte)0x00);
            output.Write((byte)0x00);
            #endregion

            output.WriteEmptySection();

            #endregion

            #region City-State Stuff + Random Seed

            #region Random Seed + Map Path + City-State Count
            output.WriteEmptyBlocks(2);
            output.Write((byte)0x00);

            output.Write(this.RandomSeed);
            output.Write((byte)0x00);
            output.Write((byte)0x00);

            output.Write(this.Map.Path.Bytes);

            output.WriteEmptyBlocks(2);
            output.Write(this.Map.NumberOfCityStates);
            #endregion

            #region City-States
            output.Write(SaveHelpers.SectionDelimiter);
            output.WriteEmptyBlocks(SaveHelpers.MaxPlayers);
            WriteMinorCivs(output);
            output.Write(0x00);
            #endregion

            #region City-State Bits
            output.Write(SaveHelpers.SectionDelimiter);
            for (int i = 0; i < Players.Length; i++)
            {
                if (Players[i].Civilization != null && Players[i].Civilization is CivilizationMinor)
                    output.Write(true);
                else output.Write(false);
            }
            output.Write((byte)0x00);
            #endregion

            #endregion

            #region Turn Timer Seconds + Unimportant Things

            #region Unknown
            output.Write(0x04);
            output.Write(0x00);
            #endregion

            output.WriteFullSection();
            output.WritePlayerNamesSection();

            #region Turn Timer Seconds
            output.Write(0x05);
            output.Write(this.TurnTimer);
            #endregion

            #region A Bunch of Bools
            //Maybe IsPlayer? The only false is the Barbarians
            output.Write(SaveHelpers.SectionDelimiter);
            for (int i = 0; i < SaveHelpers.SectionDelimiter - 1; i++)
                output.Write(true);
            output.Write(false);
            #endregion

            #endregion

            #region Player Colors
            WritePlayerColorsSection(output);
            #endregion

            #region Repeated Data + Unimportant Things

            output.Write(new byte[] { 0x00, 0x00, 0x00, 0xFF, 0xFF, 0xFF, 0xFF, 0x00, 0x00, 0x00 });

            #region Sea Level Text Key
            output.Write(SaveHelpers.SectionDelimiter);
            output.WriteEmptyBlocks(16);
            output.Write(0x01);
            output.Write(0x01);
            output.Write(0x00);

            output.WriteTextKey("SEALEVEL", "Medium");

            output.Write(0x00);
            output.Write((byte)0x00);
            #endregion

            output.WritePlayerSlotsSection();

            output.WritePlayerTypeSection();

            #region Random Seed
            output.Write(0x00);
            output.Write(this.RandomSeed);
            output.Write(0x00);
            #endregion

            output.WritePlayerTeamsSection();

            #region Turn Timer Text Key
            output.Write((byte)0x00);
            output.Write(0x04);
            output.Write(0x00);
            output.WriteTextKey("TURNTIMER", "Fast");

            output.Write(0x19);
            output.Write(0x09);
            output.Write(0x03);
            output.Write(0x03);
            output.Write(0x04);
            output.Write((byte)0x00);
            #endregion

            #endregion

            #region Victory Conditions
            output.Write(0x05);

            output.Write(BitConverter.GetBytes(this.TimeVictory));
            output.Write(BitConverter.GetBytes(this.ScienceVictory));
            output.Write(BitConverter.GetBytes(this.DominationVictory));
            output.Write(BitConverter.GetBytes(this.CulturalVictory));
            output.Write(BitConverter.GetBytes(this.DiplomaticVictory));
            #endregion

            #region Random Map Stuff
            output.Write(SaveHelpers.SectionDelimiter);
            output.WriteEmptyBlocks(16);
            if (this.HasGnkOrBnw)
                output.Write(0x02);
            int mapSizeId = (((int)this.Map.Size.Value) / 2) - 1;
            output.Write(mapSizeId);
            output.Write(0x00);

            var worldSize = SaveHelpers.ConvertOptionEnumToSaveStr(this.Map.Size.Value);
            output.WriteTextKey(worldSize.Prefix, worldSize.Value, true);

            output.Write(SaveHelpers.GetExpectedCrazyMapSizeBytes(this));
            #endregion

            #region Options

            #region Game Options
            //Number of options
            output.Write(GetNumberOfSettings() + CustomSettings.Count);

            output.WriteGamePreference("DYNAMIC_TURNS", DynamicTurns);
            output.WriteGamePreference("SIMULTANEOUS_TURNS", SimultaneousTurns);
            output.WriteGamePreference("PITBOSS", Pitboss);
            
            output.WriteGamePreference("QUICK_COMBAT", QuickCombat);
            output.WriteGamePreference("QUICK_MOVEMENT", QuickMovement);
            
            output.WriteGamePreference("END_TURN_TIMER_ENABLED", EnableTurnTimer);
            output.WriteGamePreference("POLICY_SAVING", AllowPolicySaving);
            output.WriteGamePreference("PROMOTION_SAVING", AllowPromotionSaving);
            output.WriteGamePreference("COMPLETE_KILLS", CompleteKills);
            output.WriteGamePreference("DISABLE_START_BIAS", DisableStartBias);
            output.WriteGamePreference("NEW_RANDOM_SEED", NewRandomSeed);
            output.WriteGamePreference("NO_GOODY_HUTS", NoAncientRuins);
            output.WriteGamePreference("NO_BARBARIANS", NoBarbarians);
            output.WriteGamePreference("NO_CITY_RAZING", NoCityRazing);
            output.WriteGamePreference("ONE_CITY_CHALLENGE", OneCityChallenge);
            output.WriteGamePreference("RAGING_BARBARIANS", RagingBarbarians);
            output.WriteGamePreference("RANDOM_PERSONALITIES", RandomPersonalities);
            
            output.WriteGamePreference("ALWAYS_WAR", AlwaysWar);
            output.WriteGamePreference("ALWAYS_PEACE", AlwaysPeace);
            output.WriteGamePreference("NO_CHANGING_WAR_PEACE", NoChangingWarPeace);
            output.WriteGamePreference("LOCK_MODS", LockMods);
            output.WriteGamePreference("NO_SCIENCE", NoScience);
            output.WriteGamePreference("NO_POLICIES", NoPolicies);
            output.WriteGamePreference("NO_HAPPINESS", NoHappiness);

            if (HasGnkOrBnw)
            {
                output.WriteGamePreference("NO_ESPIONAGE", NoEspionage);
                output.WriteGamePreference("NO_RELIGION", NoReligion);
            }

            if (_Expansions.Contains(Expansion.BraveNewWorld))
            {
                output.WriteGamePreference("NO_LEAGUES", NoLeagues);
                output.WriteGamePreference("NO_CULTURE_OVERVIEW_UI", NoCultureOverviewUI);
            }

            foreach(var setting in CustomSettings)
                output.WriteGamePreference(setting.Key, setting.Value);
            #endregion

            #region Map Options
            var mapProperties = this.Map.MapProperties;
            output.Write(mapProperties.Count);
            int index = 1;
            foreach (var prop in mapProperties)
            {
                object value = prop.Value;
                var possibleValues = prop.PossibleValues.Keys.ToList();
                var propIndex = possibleValues.IndexOf(value) + 1;
                var strProp = new SaveString(index.ToString());
                output.Write(strProp.Bytes);
                output.Write(propIndex);
                index++;
            }
            #endregion

            #endregion

            #region Nothing Important
            #region Build Number
            var buildStr = new SaveString(this.Build + " FINAL RELEASE");
            output.Write(buildStr.Bytes);
            #endregion

            output.Write(SaveHelpers.SectionDelimiter);
            output.WriteEmptyBlocks(16);

            output.Write(SaveHelpers.SectionDelimiter);
            output.WriteEmptyBlocks(16);

            #region Email Addresses (Ignore)
            output.Write(SaveHelpers.SectionDelimiter);
            output.WriteEmptyBlocks(64);
            #endregion
            #endregion

            WriteRawGameData(output);
        }

        private void WritePlayerColorsSection(SaveWriter output)
        {
            output.Write(SaveHelpers.SectionDelimiter);
            WritePlayerColors(output);
        }

        private void WritePlayerPasswordsSection(SaveWriter output)
        {
            output.Write(SaveHelpers.SectionDelimiter);
            output.WritePlayerPasswords();
        }

        private void WriteLeadersSection(SaveWriter output)
        {
            output.Write(SaveHelpers.SectionDelimiter);
            WriteLeaders(output);
        }

        private void WriteCivilizationsSection(SaveWriter output)
        {
            output.Write(SaveHelpers.SectionDelimiter);
            output.WritePlayerCivs();
            WriteCityStates(output);
            output.Write(this.Players[Players.Length - 1].Civilization.SaveName.Bytes);
        }

        private int GetNumberOfSettings()
        {
            int settingCount = 24;
            if (HasGnkOrBnw)
                settingCount += 2; //Religion and Espionage settings
            if (_Expansions.Contains(Expansion.BraveNewWorld))
                settingCount += 2; //Culture overview UI and World Congress settings
            return settingCount;
        }

        #region Overridable Methods
        protected virtual void WriteCurrentTurnNumber(SaveWriter output)
        {
            output.Write(0x00);
        }

        protected virtual void WriteCurrentEra(SaveWriter output)
        {
            output.Write(SaveHelpers.ConvertOptionEnumToSaveStr(this.HeaderStartingEra.Value).Bytes);
        }

        protected virtual void WritePlayerColor(SaveWriter output)
        {
            output.Write(0x00);
        }

        protected virtual void WriteLeaders(SaveWriter output)
        {
            output.WriteEmptyBlocks(SaveHelpers.StandardSectionBlockCount);
        }

        protected virtual void WriteMinorCivs(SaveWriter output)
        {
            output.WriteEmptyBlocks(SaveHelpers.CityStateBlocks);
        }

        protected virtual void WriteCurrentPlayerIndex(SaveWriter output)
        {
            output.Write(0x00);
        }

        protected virtual void WriteCityStates(SaveWriter output)
        {
            output.WriteEmptyBlocks(SaveHelpers.CityStateBlocks);
        }

        protected virtual void WritePlayerColors(SaveWriter output)
        {
            output.WriteEmptyBlocks(SaveHelpers.StandardSectionBlockCount);
        }

        protected virtual void WriteRawGameData(SaveWriter output)
        { }
        #endregion
    }
}
