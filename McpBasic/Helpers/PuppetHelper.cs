/// <summary>
/// Helper class for managing and selecting Puppet objects.
/// </summary>
/// <remarks>
/// This class provides functionality to store, retrieve and randomly select Puppet objects.
/// It also tracks the frequency of random selections for each Puppet.
/// </remarks>
public class PuppetHelper
{
    /// <summary>
    /// Static collection of Puppet objects.
    /// </summary>
    private static List<Puppet> _puppets = [];

    /// <summary>
    /// Dictionary tracking the number of times each Puppet has been randomly selected.
    /// Key is the Puppet Id, Value is the selection count.
    /// </summary>
    private static Dictionary<int, int> _randomSelectionCount = [];

    /// <summary>
    /// Random number generator for puppet selection.
    /// </summary>
    private static Random _random = new();

    /// <summary>
    /// Initializes a new instance of the PuppetHelper class.
    /// </summary>
    /// <param name="puppets">Collection of Puppet objects to manage.</param>
    public PuppetHelper(IEnumerable<Puppet> puppets)
    {
        _puppets = puppets.ToList();
        _randomSelectionCount = [];
        _random = new Random();
    }

    /// <summary>
    /// Returns the complete list of managed Puppets.
    /// </summary>
    /// <returns>List of all Puppet objects.</returns>
    public List<Puppet> GetPuppets()
    {
        return _puppets;
    }

    /// <summary>
    /// Retrieves a specific Puppet by its ID.
    /// </summary>
    /// <param name="id">The ID of the Puppet to retrieve.</param>
    /// <returns>The Puppet with the specified ID, or null if not found.</returns>
    public Puppet? GetPuppetById(int id)
    {
        return _puppets.FirstOrDefault(p => p.Id == id);
    }

    /// <summary>
    /// Selects a random Puppet from the collection and tracks the selection.
    /// </summary>
    /// <returns>A randomly selected Puppet, or null if the collection is empty.</returns>
    public Puppet? GetRandomPuppet()
    {
        if (_puppets.Count == 0) return null;
        int index = _random.Next(_puppets.Count);
        var puppet = _puppets[index];
        if (_randomSelectionCount.ContainsKey(puppet.Id))
            _randomSelectionCount[puppet.Id]++;
        else
            _randomSelectionCount[puppet.Id] = 1;
        return puppet;
    }

    /// <summary>
    /// Returns the Puppet that has been most frequently selected by the random selection process.
    /// </summary>
    /// <returns>The most frequently randomly selected Puppet, or null if no selections have been made.</returns>
    public Puppet? GetMostSelectedRandomPuppet()
    {
        if (_randomSelectionCount.Count == 0) return null;
        int maxId = _randomSelectionCount.OrderByDescending(x => x.Value).First().Key;
        return GetPuppetById(maxId);
    }
}
