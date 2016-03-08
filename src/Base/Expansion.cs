using System;
using System.Linq;

namespace MRobot.Civilization.Base
{
    public class Expansion : IEquatable<Expansion>, ISaveItem
    {
        internal Expansion(string name, string saveName, string steamId, int steamGameId, byte[] prefixBytes, int id = 0, bool isFullExpansion = false)
        {
            Id = id;
            Name = name;
            SaveName = saveName;
            SteamId = steamId;
            IsFullExpansion = isFullExpansion;
            SaveId = prefixBytes.ToArray();
        }

        public int Id { get; private set; }

        public string Name { get; }

        public string SteamId { get; private set; }

        public int SteamGameId { get; private set; }

        public bool IsFullExpansion { get; private set; }

        public SaveString SaveName { get; }

        public readonly byte[] SaveId;

        public override int GetHashCode()
        {
            return BitConverter.ToInt16(SaveId, 0);
        }

        public override bool Equals(object obj)
        {
            Expansion exp = obj as Expansion;

            return exp != null && Equals(exp);
        }

        public bool Equals(Expansion other)
        {
            if (other == null)
                return false;

            return Name == other.Name && SaveId.SequenceEqual(other.SaveId);
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
