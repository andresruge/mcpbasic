# Building a basic sample mcp

## Steps

- Install the mcp template

```bash
dotnet new install Microsoft.Extensions.AI.Templates
```

- Create mcp project

```bash
dotnet new mcpserver -n McpBasic
cd McpBasic
dotnet build
```

- If .gitignore is not present, create it with the following content:

```bash
dotnet new gitignore
```

- Add custom tools and configuration (see WeatherTools)

- Configure GitHub Copilot to use your MCP server by creating .vscode/mcp.json

```json
{
  "servers": {
    "McpBasic": {
      "type": "stdio",
      "command": "dotnet",
      "args": [
        "run",
        "--project",
        "C:\\Files\\Study\\agents\\mcpbasic\\McpBasic\\McpBasic.csproj"
      ],
      "env": {
        "WEATHER_CHOICES": "sunny,humid,freezing,perfect"
      }
    }
  },
  "inputs": []
}
```
