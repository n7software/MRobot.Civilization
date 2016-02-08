using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MRobot.Civilization.Base;
using MRobot.Civilization.Civ5.Data;
using GameConfig = MRobot.Civilization.Civ5.GameConfig;

namespace MRobot.Civilization
{
    internal static class SaveHelpers
    {
        internal const int StandardSectionBlockCount = 64;

        internal const int MaxPlayers = 22;

        internal const int CityStateBlocks = StandardSectionBlockCount - MaxPlayers - 1;

        internal static int SectionDelimiter = 0x40;

        internal static readonly byte[] FileStart = new byte[] { 0x43, 0x49, 0x56, 0x35 }; //CIV5

        internal static readonly byte[] FullBlock = new byte[] { 0xFF, 0xFF, 0xFF, 0xFF };

        internal static readonly byte[] OneBlock = new byte[] { 0x01, 0x01, 0x01, 0x01 };

        internal const string TextKeyPrefix = "TXT_KEY_";
    }
}
