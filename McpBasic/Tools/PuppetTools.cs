using System.ComponentModel;
using McpBasic.Helpers;
using ModelContextProtocol.Server;

namespace McpBasic.Tools;

/// <summary>
/// Provides tools for interacting with Puppet objects.
/// </summary>
[McpServerToolType]
public class PuppetTools
{

    private readonly PuppetHelper _puppetHelper;

    public PuppetTools(PuppetHelper puppetHelper)
    {
        _puppetHelper = puppetHelper;
    }

    /// <summary>
    /// Gets a collection of all registered Puppet objects currently managed by the PuppetHelper.
    /// </summary>
    /// <returns>A json string containing all Puppet objects that are currently registered in the PuppetHelper system.</returns>
    /// <remarks>
    /// This method provides direct access to the puppet collection maintained by the PuppetHelper.
    /// The returned list represents the current state of all managed puppets.
    /// </remarks>
    [McpServerResource(Name = "GetAllPuppets", UriTemplate = "puppets://all")]
    [Description("Collection of Puppet objects managed by the PuppetHelper.")]
    public string GetAllPuppets()
    {
        var puppets = _puppetHelper.GetPuppets();
        var options = new System.Text.Json.JsonSerializerOptions
        {
            Converters = { new System.Text.Json.Serialization.JsonStringEnumConverter() }
        };
        return System.Text.Json.JsonSerializer.Serialize(puppets, options);
    }

    /// <summary>
    /// Retrieves a specific Puppet by its ID.
    /// </summary>
    /// <param name="id">The ID of the Puppet to retrieve.</param>
    /// <returns>The Puppet with the specified ID, or null if not found.</returns>
    [McpServerTool]
    [Description("Retrieves a specific Puppet by its ID.")]
    public string GetPuppetById([Description("The ID of the Puppet to retrieve.")] int id)
    {
        var puppet = _puppetHelper.GetPuppetById(id);
        var options = new System.Text.Json.JsonSerializerOptions
        {
            Converters = { new System.Text.Json.Serialization.JsonStringEnumConverter() }
        };
        return System.Text.Json.JsonSerializer.Serialize(puppet, options);
    }

    /// <summary>
    /// Selects a random Puppet from the collection.
    /// </summary>
    /// <returns>A randomly selected Puppet, or null if the collection is empty.</returns>
    [McpServerTool]
    [Description("Selects a random Puppet from the collection.")]
    public string GetRandomPuppet()
    {
        var puppet = _puppetHelper.GetRandomPuppet();
        var options = new System.Text.Json.JsonSerializerOptions
        {
            Converters = { new System.Text.Json.Serialization.JsonStringEnumConverter() }
        };
        return System.Text.Json.JsonSerializer.Serialize(puppet, options);
    }

    /// <summary>
    /// Returns the Puppet that has been most frequently selected by the random selection process.
    /// </summary>
    /// <returns>The most frequently randomly selected Puppet.</returns>
    [McpServerTool]
    [Description("Returns the Puppet that has been most frequently selected.")]
    public string GetMostSelectedRandomPuppet()
    {
        var puppet = _puppetHelper.GetMostSelectedRandomPuppet();
        var options = new System.Text.Json.JsonSerializerOptions
        {
            Converters = { new System.Text.Json.Serialization.JsonStringEnumConverter() }
        };
        return System.Text.Json.JsonSerializer.Serialize(puppet, options);
    }
}
