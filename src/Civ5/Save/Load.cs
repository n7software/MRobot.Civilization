using MRobot.CivilizationV.Civs;
using MRobot.CivilizationV.Color;
using MRobot.CivilizationV.Game;
using MRobot.CivilizationV.Game.Maps;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MRobot.CivilizationV.Save
{
    public partial class GameSave : GameConfig
    {
        public static GameSave FromBytes(byte[] saveData)
        {
            using (var stream = new MemoryStream(saveData))
            {
                return GameSave.Load(stream);
            }
        }

        public static GameSave Load(Stream save, int expectedLength = -1)
        {
            var gameSave = new GameSave();
            using (var reader = new SaveReader(save))
            {

                #region Basic Game Information (Header, Expansions, Mods)

                #region Header
                var fileStart = new String(reader.ReadChars(4));
                if (fileStart != "CIV5")
                    throw new InvalidSaveException("File did not start with CIV5");
                reader.VerifySectionDelimiter(0x08);
                gameSave.Version = reader.ReadSaveString();
                gameSave.Build = reader.ReadSaveString();
                gameSave.TurnNumber = reader.ReadInt32();
                gameSave.GameMode = (GameMode)reader.ReadByte();

                gameSave.HeaderCiv = reader.ReadCiv();
                gameSave.HeaderDifficulty = reader.ReadDifficulty();

                //Save these for now. We can set them later when we know what the correct GameProperty is based on expansions.
                var headerStartingEra = reader.ReadEra();
                var currentEra = reader.ReadEra();

                gameSave.GamePace.Value = reader.ReadPace();

                var worldSize = reader.ReadMapSize();
                gameSave.Map = reader.ReadMap(worldSize);

                #endregion

                #region Expansions

                int numberOfExpansions = reader.ReadInt32();
                for (int i = 0; i < numberOfExpansions; i++)
                {
                    byte[] expansionId = reader.ReadBytes(16);
                    reader.ReadInt32();
                    var expansionName = reader.ReadSaveString();

                    var expansion = Expansion.AllWithInternal.SingleOrDefault(e => Enumerable.SequenceEqual(e.SaveId, expansionId) && e.SaveName == expansionName);
                    if (expansion == null)
                    {
                        expansion = new Expansion(expansionName, expansionName, String.Empty, expansionId);
                    }
                    gameSave.AddExpansion(expansion);
                }

                gameSave.HeaderStartingEra.Value = headerStartingEra;
                gameSave.HeaderCurrentEra.Value = currentEra;

                #endregion

                #region Mods
                int numberOfMods = reader.ReadInt32();
                for (int i = 0; i < numberOfMods; i++)
                {
                    string modId = reader.ReadSaveString();
                    reader.ReadInt32();
                    string modName = reader.ReadSaveString();
                    gameSave.Mods.Add(new Mod(modName, modId));
                }
                #endregion

                #endregion

                #region Nothing Important
                #region Unknown
                reader.SkipSaveStrings(2);
                reader.ReadPlayerColor();
                reader.ReadBytes(HeaderCrazyBytes.Length);
                reader.SkipInt32s(4);
                reader.ReadSaveString();
                #endregion

                reader.SkipIntSection();
                #endregion

                #region Player Information
                #region Names
                reader.VerifySectionDelimiter();
                for (int i = 0; i < SaveHelpers.StandardSectionBlockCount; i++)
                    gameSave.Players[i].Name = reader.ReadSaveString();
                #endregion

                #region Types
                reader.VerifySectionDelimiter();
                for (int i = 0; i < SaveHelpers.StandardSectionBlockCount; i++)
                    gameSave.Players[i].Type = (PlayerType)reader.ReadInt32();
                #endregion

                #region Slots
                reader.VerifySectionDelimiter();
                int slot;
                int playerSlotCount = -1;
                do
                {
                    playerSlotCount++;
                    slot = reader.ReadInt32();
                } while (slot == 0x02);
                reader.SkipInt32s(SaveHelpers.StandardSectionBlockCount - playerSlotCount - 1);
                #endregion

                #region Teams
                reader.VerifySectionDelimiter();
                for (int i = 0; i < SaveHelpers.StandardSectionBlockCount; i++)
                    gameSave.Players[i].Team = reader.ReadInt32();
                #endregion

                #region Difficulties
                reader.VerifySectionDelimiter();
                for (int i = 0; i < SaveHelpers.StandardSectionBlockCount; i++)
                    gameSave.Players[i].Difficulty = (PlayerDifficulty)reader.ReadInt32();
                #endregion

                #region Civilizations
                reader.VerifySectionDelimiter();
                for (int i = 0; i < SaveHelpers.StandardSectionBlockCount; i++)
                    gameSave.Players[i].Civilization = reader.ReadCiv(i >= SaveHelpers.MaxPlayers && i != SaveHelpers.StandardSectionBlockCount - 1);
                #endregion

                #region Leaders
                reader.VerifySectionDelimiter();
                for (int i = 0; i < SaveHelpers.StandardSectionBlockCount; i++)
                {
                    var leader = reader.ReadLeader();
                    if (gameSave.Players[i].Civilization != null)
                        gameSave.Players[i].Civilization.Leader = leader;
                }
                #endregion

                #region Current Player Index
                reader.ReadInt32();
                gameSave.CurrentPlayerIndex = reader.ReadInt32();
                reader.SkipSaveStrings(3);
                #endregion
                #endregion

                #region Nothing Important
                reader.SkipByteSection(309);
                reader.SkipIntSection();
                reader.SkipStringSection();
                #endregion

                #region Player Passwords
                reader.VerifySectionDelimiter();
                for (int i = 0; i < SaveHelpers.StandardSectionBlockCount; i++)
                    gameSave.Players[i].Password = reader.ReadSaveString();
                #endregion

                #region Starting Era + Temperature Text Key + Unimportant Things

                #region Blank
                reader.VerifySectionDelimiter();
                reader.SkipInt32s(67);
                #endregion

                reader.SkipTextKey();

                #region Actual Starting Era
                reader.SkipInt32s(11);
                var startingEraIndex = reader.ReadInt32();
                var startingEraList = gameSave.StartingEra.PossibleValues.Keys.ToList();
                var startingEra = startingEraList[startingEraIndex];
                gameSave.StartingEra.Value = startingEra;
                #endregion

                #region Blank
                reader.VerifySectionDelimiter();
                reader.SkipInt32s(65);
                #endregion

                #region Blank
                reader.VerifySectionDelimiter();
                reader.SkipSaveStrings(SaveHelpers.StandardSectionBlockCount);
                #endregion

                #region Blank
                reader.VerifySectionDelimiter(0x07);
                reader.ReadBytes(7);
                #endregion

                #endregion

                #region Game Name + Time Offset + Turn Number
                reader.VerifySectionDelimiter(SaveHelpers.FullBlock);
                gameSave.Name = reader.ReadSaveString();
                gameSave.TimeOffset = reader.ReadInt32();
                gameSave.GameStarted = reader.ReadBoolean();
                gameSave.TurnNumber = reader.ReadInt32();
                reader.ReadBytes(9);
                #endregion

                #region Player Difficulties
                reader.VerifySectionDelimiter();
                reader.SkipInt32s(SaveHelpers.StandardSectionBlockCount);
                #endregion

                #region Nothing Important
                reader.SkipByteSection(258);
                reader.SkipIntSection();
                #endregion

                #region City-State Stuff + Random Seed
                #region Random Seed + Map Path + City-State Count
                reader.SkipSaveStrings(2);
                reader.ReadByte();
                gameSave.RandomSeed = reader.ReadInt32();
                reader.ReadBytes(2);

                reader.ReadSaveString();

                reader.SkipInt32s(2);
                gameSave.Map.NumberOfCityStates.Value = reader.ReadInt32();
                #endregion

                #region City-States
                reader.VerifySectionDelimiter();
                reader.SkipSaveStrings(22);
                for (int i = SaveHelpers.MaxPlayers; i < SaveHelpers.StandardSectionBlockCount - 1; i++)
                {
                    var civ = reader.ReadCiv(true);
                    if (gameSave.Players[i].Civilization != null && civ != null)
                        gameSave.Players[i].Civilization.Name = civ.Name;
                }
                reader.ReadCiv(false);
                #endregion

                #region City-State Bits
                reader.VerifySectionDelimiter();
                for (int i = 0; i < SaveHelpers.StandardSectionBlockCount; i++)
                {
                    bool isCityState = reader.ReadBoolean();
                    //This is a safeguard
                    //It will be called if a player we thought was a civ is actually a city-state
                    //So far, I have never found a save file where this happens
                    if (isCityState && !(gameSave.Players[i].Civilization is CivilizationMinor))
                    {
                        var civ = gameSave.Players[i].Civilization;
                        gameSave.Players[i].Civilization = new CivilizationMinor(civ.Name, civ.Color);
                    }
                }
                reader.ReadByte();
                #endregion
                #endregion

                #region Turn Timer Seconds + Unimportant Things

                #region Unknown
                reader.VerifySectionDelimiter(0x04);
                reader.ReadBytes(4);
                #endregion

                reader.SkipIntSection();

                #region Player Names
                reader.SkipStringSection();
                #endregion

                #region Turn Timer Seconds
                reader.VerifySectionDelimiter(0x05);
                gameSave.TurnTimer = reader.ReadInt32();
                #endregion

                reader.SkipByteSection();

                #endregion

                #region Player Colors
                reader.VerifySectionDelimiter();
                for (int i = 0; i < SaveHelpers.StandardSectionBlockCount; i++)
                {
                    var color = reader.ReadPlayerColor();
                    if (gameSave.Players[i].Civilization != null)
                        gameSave.Players[i].Civilization.Color = color;
                }
                #endregion

                #region Repeated Data + Unimportant Things

                reader.ReadBytes(10);

                #region Sea Level Text Key
                reader.VerifySectionDelimiter();
                reader.SkipInt32s(19);
                reader.SkipTextKey();
                reader.ReadBytes(5);
                #endregion

                #region Player Slots
                reader.SkipIntSection();
                #endregion

                #region Player Types
                reader.SkipIntSection();
                #endregion

                #region Random Seed
                reader.SkipInt32s(3);
                #endregion

                #region Player Teams
                reader.SkipIntSection();
                #endregion

                #region Turn Timer Text Key
                reader.ReadBytes(9);
                reader.SkipTextKey();
                reader.SkipInt32s(5);
                reader.ReadByte();
                #endregion

                #endregion

                #region Victory Conditions
                reader.VerifySectionDelimiter(0x05);
                gameSave.TimeVictory = reader.ReadBoolean();
                gameSave.ScienceVictory = reader.ReadBoolean();
                gameSave.DominationVictory = reader.ReadBoolean();
                gameSave.CulturalVictory = reader.ReadBoolean();
                gameSave.DiplomaticVictory = reader.ReadBoolean();
                #endregion

                #region Random Map Stuff
                reader.VerifySectionDelimiter();
                reader.SkipInt32s(18);
                if (gameSave.HasGnkOrBnw)
                    reader.ReadInt32();
                reader.SkipTextKey();
                var expectedCrazyMapBytes = SaveHelpers.GetExpectedCrazyMapSizeBytes(gameSave);
                reader.ReadBytes(expectedCrazyMapBytes.Length);
                #endregion

                #region Options
                #region Game Options
                int numberOfPrefs = reader.ReadInt32();
                for (int i = 0; i < numberOfPrefs; i++)
                    reader.ReadPreference(gameSave);
                #endregion

                #region Map Options
                int numberOfMapProps = reader.ReadInt32();
                for (int i = 0; i < numberOfMapProps; i++)
                    reader.ReadMapPreference(gameSave);
                #endregion
                #endregion

                #region Nothing Important

                #region Build Number
                reader.ReadSaveString();
                #endregion

                reader.SkipByteSection();
                reader.SkipByteSection();

                #region Email Addresses (Ignore)
                reader.SkipStringSection();
                #endregion
                #endregion

                #region Read Raw Data
                if (expectedLength < 0)
                    expectedLength = (int)save.Length;

                gameSave.RawGameDataIndex = reader.Position;
                reader.ReadBytes((int)(expectedLength - save.Position));

                gameSave._OriginalBytes = reader.AllBytesRead;
                #endregion
            }
            return gameSave;
        }

    }
}
