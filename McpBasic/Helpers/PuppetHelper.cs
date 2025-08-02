public class PuppetHelper
{
    private static List<Puppet> _puppets = [];
    private static Dictionary<int, int> _randomSelectionCount = [];
    private static Random _random = new();

    public PuppetHelper(IEnumerable<Puppet> puppets)
    {
        _puppets = puppets.ToList();
        _randomSelectionCount = [];
        _random = new Random();
    }

    public List<Puppet> GetPuppets()
    {
        return _puppets;
    }

    public Puppet? GetPuppetById(int id)
    {
        return _puppets.FirstOrDefault(p => p.Id == id);
    }

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

    public Puppet? GetMostSelectedRandomPuppet()
    {
        if (_randomSelectionCount.Count == 0) return null;
        int maxId = _randomSelectionCount.OrderByDescending(x => x.Value).First().Key;
        return GetPuppetById(maxId);
    }
}
