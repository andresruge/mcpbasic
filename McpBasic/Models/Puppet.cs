/// <summary>
/// Represents a puppet entity with an identifier, name, and associated personality type.
/// </summary>
/// <param name="Id">The unique identifier of the puppet.</param>
/// <param name="Name">The name of the puppet.</param>
/// <param name="Personality">The personality type assigned to the puppet.</param>
public record Puppet(int Id, string Name, PersonalityType Personality);