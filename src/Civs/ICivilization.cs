using MRobot.Civilization.Color;
using MRobot.Civilization.Expansion;

namespace MRobot.Civilization.Civs
{
    public interface ICivilization : IExpandable, ISaveItem
    {
        int Id { get; }

        string Name { get; set; }

        PlayerColor Color { get; set; }

        Leader Leader { get; set; }
    }
}
