using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MRobot.CivilizationV
{
    public partial class Expansion : IEquatable<Expansion>, ISaveItem
    {

        internal Expansion(string name, string saveName, string steamId, byte[] prefixBytes, int id = 0, bool isFullExpansion = false)
        {
            Id = id;
            Name = name;
            SaveName = saveName;
            SteamId = steamId;
            IsFullExpansion = isFullExpansion;
            SaveId = (byte[])prefixBytes.Clone();
        }

        public int Id { get; private set; }

        public string Name { get; private set; }

        public string SteamId { get; private set; }

        public bool IsFullExpansion { get; private set; }

        public SaveString SaveName { get; private set; }

        public byte[] SaveId { get; private set; }

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
