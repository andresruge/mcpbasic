using System.ComponentModel;
using McpBasic.Helpers;
using McpBasic.Models;
using ModelContextProtocol.Server;

namespace McpBasic.Tools;

/// <summary>
/// Provides tools for interacting with Puppet objects.
/// </summary>
[McpServerToolType]
public class PuppetTools
{
    /// <summary>
    /// Gets a collection of all registered Puppet objects currently managed by the PuppetHelper.
    /// </summary>
    /// <returns>A List containing all Puppet objects that are currently registered in the PuppetHelper system.</returns>
    /// <remarks>
    /// This method provides direct access to the puppet collection maintained by the PuppetHelper.
    /// The returned list represents the current state of all managed puppets.
    /// </remarks>
    [McpServerResource]
    [Description("Collection of Puppet objects managed by the PuppetHelper.")]
    public static List<Puppet> GetAllPuppets()
    {
        return PuppetHelper.GetPuppets();
    }

    /// <summary>
    /// Retrieves a specific Puppet by its ID.
    /// </summary>
    /// <param name="id">The ID of the Puppet to retrieve.</param>
    /// <returns>The Puppet with the specified ID, or null if not found.</returns>
    [McpServerTool]
    [Description("Retrieves a specific Puppet by its ID.")]
    public static Puppet? GetPuppetById([Description("The ID of the Puppet to retrieve.")] int id)
    {
        return PuppetHelper.GetPuppetById(id);
    }

    /// <summary>
    /// Selects a random Puppet from the collection.
    /// </summary>
    /// <returns>A randomly selected Puppet, or null if the collection is empty.</returns>
    [McpServerTool]
    [Description("Selects a random Puppet from the collection.")]
    public static Puppet? GetRandomPuppet()
    {
        return PuppetHelper.GetRandomPuppet();
    }

    /// <summary>
    /// Returns the Puppet that has been most frequently selected by the random selection process.
    /// </summary>
    /// <returns>The most frequently randomly selected Puppet.</returns>
    [McpServerTool]
    [Description("Returns the Puppet that has been most frequently selected.")]
    public static Puppet? GetMostSelectedRandomPuppet()
    {
        return PuppetHelper.GetMostSelectedRandomPuppet();
    }
}
