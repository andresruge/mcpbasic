using System.ComponentModel;
using ModelContextProtocol.Server;

/// <summary>
/// Provides tools related to weather functionalities within the application.
/// </summary>
/// <remarks>
/// The WeatherTools class offers utility methods for generating randomized weather descriptions.
/// It leverages environment variables to determine the set of possible weather conditions,
/// defaulting to "balmy", "rainy", and "stormy" when not explicitly provided.
/// </remarks>
[McpServerToolType]
public class WeatherTools
{
    /// <summary>
    /// Describes random weather in the provided city.
    /// </summary>
    /// <param name="city">The name of the city for which the weather description is generated.</param>
    /// <returns>A string containing the city name and a randomly selected weather description.</returns>
    /// <remarks>
    /// This method retrieves the weather choices from the WEATHER_CHOICES environment variable. If not set,
    /// it uses default values. It then randomly selects one of these weather conditions to build the resulting message.
    /// </remarks>
    [McpServerTool]
    [Description("Describes random weather in the provided city.")]
    public static string GetCityWeather([Description("Name of the city to return weather for")] string city)
    {
        // Read the environment variable during tool execution.
        // Alternatively, this could be read during startup and passed via IOptions dependency injection
        var weather = Environment.GetEnvironmentVariable("WEATHER_CHOICES");
        if (string.IsNullOrWhiteSpace(weather))
        {
            weather = "balmy,rainy,stormy";
        }

        var weatherChoices = weather.Split(",");
        var selectedWeatherIndex = Random.Shared.Next(0, weatherChoices.Length);

        return $"The weather in {city} is {weatherChoices[selectedWeatherIndex]}.";
    }
}
