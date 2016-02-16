namespace MRobot.Civilization.Base
{
    internal static class SaveHelpers
    {
        internal const int StandardSectionBlockCount = 64;

        internal const int MaxPlayers = 22;

        internal const int CityStateBlocks = StandardSectionBlockCount - MaxPlayers - 1;

        internal static int SectionDelimiter = 0x40;

        internal static readonly byte[] Civ5FileStart = new byte[] { 0x43, 0x49, 0x56, 0x35 }; //CIV5

        internal static readonly byte[] FullBlock = new byte[] { 0xFF, 0xFF, 0xFF, 0xFF };

        internal static readonly byte[] OneBlock = new byte[] { 0x01, 0x01, 0x01, 0x01 };

        internal const string TextKeyPrefix = "TXT_KEY_";
    }
}
