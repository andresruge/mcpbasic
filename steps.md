# Building a basic sample mcp

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