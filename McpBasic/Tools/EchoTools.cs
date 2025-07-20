using System.ComponentModel;
using ModelContextProtocol.Server;

/// <summary>
/// Provides echo utilities that return the provided input.
/// </summary>
/// <remarks>
/// This class contains methods to echo different types of data back to the caller.
/// </remarks>
[McpServerToolType]
public class EchoTools
{
    /// <summary>
    /// Echoes the input string back to the caller.
    /// </summary>
    /// <param name="input">The string to be echoed.</param>
    /// <returns>The original input string.</returns>
    [McpServerTool]
    [Description("Echoes the input string back to the caller.")]
    public static string Echo([Description("The string to echo back")] string input)
    {
        return input;
    }

    /// Echoes in reverse the input string back to the caller.
    /// </summary>
    /// <param name="input">The string to be reversed.</param>
    /// <returns>The input string reversed; if the reverse conversion is null, returns an empty string.</returns>
    [McpServerTool]
    [Description("Echoes in reverse the input string back to the caller.")]
    public static string ReverseEcho([Description("The reverse string to echo back")]string input)
    {
        return input.Reverse().ToString() ?? string.Empty;
    }

    /// <summary>
    /// Echoes the input integer back to the caller.
    /// </summary>
    /// <param name="input">The integer to be echoed.</param>
    /// <returns>The original input integer.</returns>
    [McpServerTool]
    [Description("Echoes the input integer back to the caller.")]
    public static int EchoInt([Description("The integer to echo back")] int input)
    {
        return input;
    }
}