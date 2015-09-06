using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MRobot.CivilizationV
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
            if (exp != null)
                return this.Equals(exp);
            else return false;
        }

        public bool Equals(Mod other)
        {
            return this.SaveName == other.SaveName
                && this.SaveId == other.SaveId;
        }
    }
}
