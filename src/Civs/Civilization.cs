using System;
using MRobot.Civilization.Color;
using MRobot.Civilization.Expansion;

namespace MRobot.Civilization.Civs
{
    public partial class Civilization : ISaveItem, IExpandable, ICivilization
    {
        const string Prefix = "CIVILIZATION";

        internal Civilization(int id, string name = null, PlayerColor color = null, Leader leader = null, Expansion.Expansion requirement = null)
        {
            Id = id;
            Color = color;
            Requirement = requirement;
            Leader = leader;

            SaveName = new SaveString(Prefix, name, true);
        }
        public string Name
        {
            get 
            {
                if (String.IsNullOrEmpty(SaveName.Value))
                    return "Unknown or Empty";
                return SaveName.Value; 
            }
            set { SaveName.Value = value; }
        }
        public SaveString SaveName { get; set; }
        public int Id { get; private set; }
        public Leader Leader { get; set; }
        public PlayerColor Color { get; set; }
        public Expansion.Expansion Requirement { get; private set; }
    }
}
