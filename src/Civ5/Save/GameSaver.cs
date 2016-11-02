using System;
using System.IO;
using System.Linq;
using MRobot.Civilization.Base;
using MRobot.Civilization.Civ5.Data;

namespace MRobot.Civilization.Civ5.Save
{
    public class GameSaver
    {
        private readonly GameConfig _gameConfig;

        public GameSaver(GameConfig gameConfig)
        {
            _gameConfig = gameConfig;
        }
        
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
            var output = new SaveWriter(stream, _gameConfig);

            #region Basic Game Information (Header, Expansions, Mods)

            #region Header
            output.Write(SaveHelpers.Civ5FileStart);
            output.Write(0x08);
            output.Write(_gameConfig.Version.Bytes);
            output.Write(_gameConfig.Build.Bytes);
            output.Write(_gameConfig.GetCurrentTurnNumber());
            output.Write((byte)_gameConfig.GameMode);

            var headerCiv = _gameConfig.HeaderCiv.SaveName.Bytes ?? 
                (_gameConfig.Players[0].Civilization.SaveName.Bytes ?? BitConverter.GetBytes(0x00));
            output.Write(headerCiv);
            var headerDifficulty = _gameConfig.HeaderDifficulty ?? _gameConfig.Players[0].Difficulty.Value;
            output.Write(headerDifficulty.SaveString.Bytes);
            output.Write(ConvertOptionEnumToSaveStr(_gameConfig.HeaderStartingEra.Value).Bytes);
            output.Write(_gameConfig.GetCurrentEra());
            output.Write(ConvertOptionEnumToSaveStr((GamePace)_gameConfig.GamePace.Value).Bytes);
            output.Write(_gameConfig.Map.Size.Value.GetSaveString().Bytes);

            output.Write(_gameConfig.Map.Path.Bytes);
            #endregion

            #region Expansions
            var expansions = _gameConfig.Expansions.ToList();
            output.Write(expansions.Count);
            foreach (var expansion in expansions)
            {
                output.Write(expansion.SaveId);
                output.Write(0x01);
                output.Write(expansion.SaveName.Bytes);
            }
            #endregion

            #region Mods
            output.Write(_gameConfig.Mods.Count);
            foreach (var mod in _gameConfig.Mods)
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
            output.Write(_gameConfig.GetPlayerColor());
            output.Write(GameConfig.HeaderCrazyBytes);
            output.Write(0x00);
            output.Write(0x03);
            output.Write(0x03);
            output.Write(0x02);

            output.Write(_gameConfig.Map.Path.Bytes);
            #endregion

            output.Write(SaveHelpers.SectionDelimiter);
            output.WriteFullBlocks(SaveHelpers.StandardSectionBlockCount);
            #endregion

            #region Player Information

            output.WritePlayerNamesSection();
            output.WritePlayerTypeSection();
            output.WritePlayerSlotsSection();
            output.WritePlayerTeamsSection();
            WritePlayerDifficultiesSection(output);

            WriteCivilizationsSection(output);

            WriteLeadersSection(output);

            #region Current Player Index
            output.Write(0x06);
            output.Write(_gameConfig.GetCurrentPlayerIndex());
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

            var startingEra = _gameConfig.StartingEra.Value;
            var startingEraList = _gameConfig.StartingEra.PossibleValues.Keys.ToList();
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
            output.WriteEmptyBlocks(7);
            #endregion

            #endregion

            #region Game Name + Time Offset + Turn Number
            output.WriteFullBlocks(1);
            output.Write(_gameConfig.Name.Bytes);
            output.Write(_gameConfig.TimeOffset);
            output.Write(_gameConfig.GameStarted);
            output.Write(_gameConfig.GetCurrentTurnNumber());
            output.Write((byte)0x02);
            output.WriteEmptyBlocks(2);
            #endregion

            WritePlayerDifficultiesSection(output);

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

            output.Write(_gameConfig.RandomSeed);
            output.Write((byte)0x00);
            output.Write((byte)0x00);

            output.Write(_gameConfig.Map.Path.Bytes);

            output.WriteEmptyBlocks(2);
            output.Write(((Civ5.Map)_gameConfig.Map).NumberOfCityStates);
            #endregion

            #region City-States
            output.Write(SaveHelpers.SectionDelimiter);
            output.WriteEmptyBlocks(SaveHelpers.MaxPlayers);
            _gameConfig.WriteMinorCivs(output);
            output.Write(0x00);
            #endregion

            #region City-State Bits
            output.Write(SaveHelpers.SectionDelimiter);
            foreach (Player player in _gameConfig.Players)
            {
                output.Write(player.Civilization is CivilizationMinor);
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
            output.Write(_gameConfig.TurnTimer);
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
            output.Write(_gameConfig.RandomSeed);
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

            output.Write(BitConverter.GetBytes(_gameConfig.TimeVictory));
            output.Write(BitConverter.GetBytes(_gameConfig.ScienceVictory));
            output.Write(BitConverter.GetBytes(_gameConfig.DominationVictory));
            output.Write(BitConverter.GetBytes(_gameConfig.CulturalVictory));
            output.Write(BitConverter.GetBytes(_gameConfig.DiplomaticVictory));
            #endregion

            #region Random Map Stuff
            output.Write(SaveHelpers.SectionDelimiter);
            output.WriteEmptyBlocks(16);
            if (_gameConfig.HasGnkOrBnw)
                output.Write(0x02);
            // !!! I'm not sure if my change here was correct, could cause problems !!!
            int mapSizeId = ((_gameConfig.Map.Size.Value.Players) / 2) - 1; // (((int)_gameConfig.Map.Size.Value) / 2) - 1;
            output.Write(mapSizeId);
            output.Write(0x00);

            var worldSize = _gameConfig.Map.Size.Value.GetSaveString();
            output.WriteTextKey(worldSize.Prefix, worldSize.Value, true);

            output.Write(GameConfig.GetExpectedCrazyMapSizeBytes(_gameConfig));
            #endregion

            #region Options

            #region Game Options
            //Number of options
            output.Write(GetNumberOfSettings() + _gameConfig.CustomSettings.Count);

            output.WriteGamePreference("DYNAMIC_TURNS", _gameConfig.DynamicTurns);
            output.WriteGamePreference("SIMULTANEOUS_TURNS", _gameConfig.SimultaneousTurns);
            output.WriteGamePreference("PITBOSS", _gameConfig.Pitboss);
            
            output.WriteGamePreference("QUICK_COMBAT", _gameConfig.QuickCombat);
            output.WriteGamePreference("QUICK_MOVEMENT", _gameConfig.QuickMovement);
            
            output.WriteGamePreference("END_TURN_TIMER_ENABLED", _gameConfig.EnableTurnTimer);
            output.WriteGamePreference("POLICY_SAVING", _gameConfig.AllowPolicySaving);
            output.WriteGamePreference("PROMOTION_SAVING", _gameConfig.AllowPromotionSaving);
            output.WriteGamePreference("COMPLETE_KILLS", _gameConfig.CompleteKills);
            output.WriteGamePreference("DISABLE_START_BIAS", _gameConfig.DisableStartBias);
            output.WriteGamePreference("NEW_RANDOM_SEED", _gameConfig.NewRandomSeed);
            output.WriteGamePreference("NO_GOODY_HUTS", _gameConfig.NoAncientRuins);
            output.WriteGamePreference("NO_BARBARIANS", _gameConfig.NoBarbarians);
            output.WriteGamePreference("NO_CITY_RAZING", _gameConfig.NoCityRazing);
            output.WriteGamePreference("ONE_CITY_CHALLENGE", _gameConfig.OneCityChallenge);
            output.WriteGamePreference("RAGING_BARBARIANS", _gameConfig.RagingBarbarians);
            output.WriteGamePreference("RANDOM_PERSONALITIES", _gameConfig.RandomPersonalities);
            
            output.WriteGamePreference("ALWAYS_WAR", _gameConfig.AlwaysWar);
            output.WriteGamePreference("ALWAYS_PEACE", _gameConfig.AlwaysPeace);
            output.WriteGamePreference("NO_CHANGING_WAR_PEACE", _gameConfig.NoChangingWarPeace);
            output.WriteGamePreference("LOCK_MODS", _gameConfig.LockMods);
            output.WriteGamePreference("NO_SCIENCE", _gameConfig.NoScience);
            output.WriteGamePreference("NO_POLICIES", _gameConfig.NoPolicies);
            output.WriteGamePreference("NO_HAPPINESS", _gameConfig.NoHappiness);

            if (_gameConfig.HasGnkOrBnw)
            {
                output.WriteGamePreference("NO_ESPIONAGE", _gameConfig.NoEspionage);
                output.WriteGamePreference("NO_RELIGION", _gameConfig.NoReligion);
            }

            if (_gameConfig.HasBnw)
            {
                output.WriteGamePreference("NO_LEAGUES", _gameConfig.NoLeagues);
                output.WriteGamePreference("NO_CULTURE_OVERVIEW_UI", _gameConfig.NoCultureOverviewUI);
            }

            foreach(var setting in _gameConfig.CustomSettings)
                output.WriteGamePreference(setting.Key, setting.Value);
            #endregion

            #region Map Options
            var mapProperties = _gameConfig.Map.MapProperties;
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
            var buildStr = new SaveString(_gameConfig.Build + " FINAL RELEASE");
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

            output.Write(_gameConfig.GetRawGameData());
        }

        private void WritePlayerDifficultiesSection(SaveWriter output)
        {
            bool hasBnw = _gameConfig.HasBnw;
            output.Write(SaveHelpers.SectionDelimiter);
            for (int i = 0; i < _gameConfig.Players.Length - 1; i++)
            {
                var difficulty = _gameConfig.Players[i].Difficulty.Value;
                if (!hasBnw && difficulty == PlayerDifficulties.AI)
                    difficulty = PlayerDifficulties.Chieftain;
                output.Write(difficulty.Value);
            }

            //Player 64 (barbarians) is a special case
            output.Write(PlayerDifficulties.Chieftain.Value);
        }

        private void WritePlayerColorsSection(SaveWriter output)
        {
            output.Write(SaveHelpers.SectionDelimiter);
            _gameConfig.WritePlayerColors(output);
        }

        private void WritePlayerPasswordsSection(SaveWriter output)
        {
            output.Write(SaveHelpers.SectionDelimiter);
            output.WritePlayerPasswords();
        }

        private void WriteLeadersSection(SaveWriter output)
        {
            output.Write(SaveHelpers.SectionDelimiter);
            _gameConfig.WriteLeaders(output);
        }

        private void WriteCivilizationsSection(SaveWriter output)
        {
            output.Write(SaveHelpers.SectionDelimiter);
            output.WritePlayerCivs();
            _gameConfig.WriteCityStates(output);
            output.Write(_gameConfig.Players.Last().Civilization.SaveName.Bytes);
        }

        private int GetNumberOfSettings()
        {
            int settingCount = 24;
            if (_gameConfig.HasGnkOrBnw)
                settingCount += 2; //Religion and Espionage settings
            if (_gameConfig.HasBnw)
                settingCount += 2; //Culture overview UI and World Congress settings
            return settingCount;
        }


        internal static SaveString ConvertOptionEnumToSaveStr(Enum optionEnum)
        {
            SaveString str = new SaveString(optionEnum.ToString(), allCaps: true);

            if (optionEnum is GameEra)
                str.Prefix = "ERA";
            else if (optionEnum is GamePace)
                str.Prefix = "GAMESPEED";
            return str;
        }
    }
}
