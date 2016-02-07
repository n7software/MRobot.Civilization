using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MRobot.Civilization.Base
{
    public class Civilization : ICivilization
    {
        const string Prefix = "CIVILIZATION";

        internal Civilization(int id, string name = null, PlayerColor color = null, Leader leader = null, Expansion requirement = null)
        {
            Id = id;
            Color = color;
            Requirement = requirement;
            Leader = leader;

            SaveName = new SaveString(Prefix, name, allCaps: true);
        }
        public string Name
        {
            get
            {
                if (string.IsNullOrEmpty(SaveName.Value))
                    return "Unknown or Empty";
                return SaveName.Value; 
            }
            set { SaveName.Value = value; }
        }
        public SaveString SaveName { get; set; }
        public int Id { get; private set; }
        public Leader Leader { get; set; }
        public PlayerColor Color { get; set; }
        public Expansion Requirement { get; private set; }
    }
}
