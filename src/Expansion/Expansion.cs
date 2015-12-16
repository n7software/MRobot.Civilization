using System;
using System.Linq;

namespace MRobot.Civilization.Expansion
{
    public partial class Expansion : IEquatable<Expansion>, ISaveItem
    {

        internal Expansion(string name, string saveName, string steamId, int gameSteamId, byte[] prefixBytes, int id = 0, bool isFullExpansion = false)
        {
            Id = id;
            Name = name;
            SaveName = saveName;
            SteamId = steamId;
            GameSteamId = gameSteamId;
            IsFullExpansion = isFullExpansion;
            SaveId = (byte[])prefixBytes.Clone();
        }

        public int Id { get; }

        public string Name { get; }

        public string SteamId { get; }

        public int GameSteamId { get; }

        public bool IsFullExpansion { get; }

        public SaveString SaveName { get; }

        public byte[] SaveId { get; }

        public override int GetHashCode()
        {
            return BitConverter.ToInt16(SaveId, 0);
        }

        public override bool Equals(object obj)
        {
            Expansion exp = obj as Expansion;
            if (exp != null)
                return this.Equals(exp);
            else return false;
        }

        public bool Equals(Expansion other)
        {
            if (other == null)
                return false;
            else return this.Name == other.Name
                && Enumerable.SequenceEqual(this.SaveId, other.SaveId);
        }

        public static bool operator ==(Expansion x, Expansion y)
        {
            if ((object)x == null)
            {
                return (object)y == null;
            }

            return x.Equals(y);
        }

        public static bool operator !=(Expansion x, Expansion y)
        {
            if ((object)x == null)
            {
                return (object)y != null;
            }

            return !x.Equals(y);
        }
    }
}
