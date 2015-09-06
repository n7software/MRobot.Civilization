namespace MRobot.Civilization.Civs
{
    public partial class Leader : ISaveItem
    {
        internal Leader(string name, string saveName = null)
        {
            Name = name;
            SaveName = new SaveString("LEADER", saveName != null ? saveName : name, true);
        }

        public string Name { get; private set; }

        public SaveString SaveName { get; private set; }
    }
}
