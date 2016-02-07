using System;

namespace MRobot.Civilization.Base
{
    public class Mod : IEquatable<Mod>, ISaveItem
    {
        internal Mod(string name, string id)
        {
            SaveName = name;
            SaveId = id;
        }

        public SaveString SaveName { get; private set; }

        public SaveString SaveId { get; private set; }

        public override int GetHashCode()
        {
            return SaveId.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            Mod exp = obj as Mod;

            return exp != null && Equals(exp);
        }

        public bool Equals(Mod other)
        {
            return SaveName == other.SaveName
                && SaveId == other.SaveId;
        }
    }
}
