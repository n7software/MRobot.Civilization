namespace MRobot.Civilization.Base
{
    /// <summary>
    /// Means that a certain item is expandable, and thus means that a specific instance's 
    /// availability could depend on the presence of a game expansion
    /// </summary>
    public interface IExpandable
    {
        Expansion Requirement { get; }
    }
}
