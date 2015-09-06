namespace MRobot.Civilization.Expansion
{
    /// <summary>
    /// Means that a certain item is expandable, and thus means that a specific instance's 
    /// availability could depent on the presence of an expansion to Civilization V.
    /// </summary>
    public interface IExpandable
    {
        Expansion Requirement { get; }
    }
}
