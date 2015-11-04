using System;

namespace MRobot.CivilizationV.Civ5
{
    public interface ICivilization : IExpandable, ISaveItem
    {
        int Id { get; }

        string Name { get; set; }

        PlayerColor Color { get; set; }

        Leader Leader { get; set; }
    }
}
