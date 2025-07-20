# Building a sample mcp

## Steps

- Install the mcp template
```cmd
dotnet new install Microsoft.Extensions.AI.Templates
```

- Create mcp project
```cmd
dotnet new mcpserver -n McpBasic
cd McpBasic
dotnet build
```

- Add custom tools and configuration (WeatherTools)

- Configure GitHub Copilot to use your MCP server by creating .vscode/mcp.json