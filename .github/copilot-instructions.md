# Copilot Instructions for MCPBasic

## Project Overview
- **McpBasic** is a C# Model Context Protocol (MCP) server, created from the Microsoft MCP server template.
- The main entry point is `McpBasic/Program.cs`.
- Custom tools are implemented in `McpBasic/Tools/` (e.g., `WeatherTools.cs`, `RandomNumberTools.cs`, `EchoTools.cs`, `PuppetTools.cs`).
- Data models are in `McpBasic/Models/` (e.g., `Puppet.cs`, `PersonalityType.cs`).
- Data files (e.g., `puppets.json`) are in `McpBasic/Data/`.

## Architecture & Patterns
- The server uses the ModelContextProtocol SDK for tool registration and communication.
- Tools are registered via `.WithTools<ToolClass>()` in `Program.cs`. Each tool class should be instantiable (not static).
- Data flows from tool methods to the MCP protocol, exposing them as callable functions for AI agents.
- Project structure follows standard .NET conventions, with clear separation of tools, models, and helpers.

## Developer Workflows
- **Build:**
  - `dotnet build McpBasic/McpBasic.csproj`
- **Run Locally:**
  - `dotnet run --project McpBasic/McpBasic.csproj`
- **Test in Copilot Chat:**
  - Configure `.vscode/mcp.json` as shown in `steps.md` or `README.md`.
  - Example: ask "Give me a random number" to trigger the `get_random_number` tool.
- **Publish:**
  - `dotnet pack -c Release`
  - `dotnet nuget push bin/Release/*.nupkg --api-key <your-api-key> --source https://api.nuget.org/v3/index.json`

## Project-Specific Conventions
- Tool classes must be non-static to be registered with `.WithTools<T>()`.
- Use the `Data/` directory for static data files consumed by tools.
- Use the `Helpers/` directory for utility classes (e.g., `PuppetHelper.cs`).
- Configuration for local development is in `.vscode/mcp.json`.

## Integration Points
- Relies on the `ModelContextProtocol` NuGet package.
- Can be used as a local server or published to NuGet for broader consumption.
- Integrates with GitHub Copilot and other AI agents via MCP protocol.

## Key Files & Directories
- `McpBasic/Program.cs`: Main entry, tool registration
- `McpBasic/Tools/`: Custom tool implementations
- `McpBasic/Models/`: Data models
- `McpBasic/Data/`: Static data
- `McpBasic/Helpers/`: Utility classes
- `McpBasic/README.md`, `steps.md`: Developer setup and workflow guidance

## Example: Registering a Tool
```csharp
// In Program.cs
builder.WithTools<WeatherTools>();
```

## References
- [ModelContextProtocol Documentation](https://modelcontextprotocol.io/)
- [MCP Server Template Guide](https://aka.ms/nuget/mcp/guide)
- [VS Code MCP Servers](https://code.visualstudio.com/docs/copilot/chat/mcp-servers)
