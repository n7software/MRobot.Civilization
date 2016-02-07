namespace MRobot.Civilization.Base
{
    public abstract class CivilizationMinor : BaseSaveItem, ICivilization
    {
        internal CivilizationMinor(string name = "", PlayerColor color = null)
            : base("MINOR", name)
        {
            Color = color;
        }
        public PlayerColor Color { get; set; }

        public int Id
        {
            get { return -1; }
        }

        public Leader Leader { get; set; }

        public Expansion Requirement
        {
            get { return null; }
        }
    }
}
