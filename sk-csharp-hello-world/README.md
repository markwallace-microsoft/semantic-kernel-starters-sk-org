# Semantic Kernel C# Hello World Starter

The `sk-csharp-hello-world` console application demonstrates how to execute a semantic function.

## Prerequisites

- [.NET 6](https://dotnet.microsoft.com/download/dotnet/6.0) is required to run this starter.
- Install the recommended extensions
  - [C#](https://marketplace.visualstudio.com/items?itemName=ms-dotnettools.csharp)
  - [Semantic Kernel Tools](https://marketplace.visualstudio.com/items?itemName=ms-semantic-kernel.semantic-kernel)

## Building the starter

To build the console application use the following command:

```powershell
dotnet build
```

## Configuring the starter

The starter can be configured in two ways:

1. Using .NET Secret Manager
1. Using settings.json

For Debugging the console application alone, we suggest using .NET [Secret Manager](https://learn.microsoft.com/en-us/aspnet/core/security/app-secrets) to avoid the risk of leaking secrets into the repository, branches and pull requests.

### Using .NET [Secret Manager](https://learn.microsoft.com/en-us/aspnet/core/security/app-secrets)

Configure an OpenAI endpoint

```powershell
cd sk-csharp-hello-world
dotnet user-secrets set "serviceType" "OpenAI"
dotnet user-secrets set "serviceId" "text-davinci-003"
dotnet user-secrets set "deploymentOrModelId" "text-davinci-003"
dotnet user-secrets set "apiKey" "... your OpenAI key ..."
```

Configure an Azure OpenAI endpoint

```powershell
cd sk-csharp-hello-world
dotnet user-secrets set "serviceType" "AzureOpenAI"
dotnet user-secrets set "serviceId" "text-davinci-003"
dotnet user-secrets set "deploymentOrModelId" "text-davinci-003"
dotnet user-secrets set "endpoint" "https:// ... your endpoint ... .openai.azure.com/"
dotnet user-secrets set "apiKey" "... your Azure OpenAI key ..."
```

Configure the Semantic Kernel logging level

```powershell
dotnet user-secrets set "LogLevel" 0
```

Log levels:

- 0 = Trace
- 1 = Debug
- 2 = Information
- 3 = Warning
- 4 = Error
- 5 = Critical
- 6 = None

### Using settings.json

Configure an OpenAI endpoint

1. Copy [settings.json.openai-example](./config/settings.json.openai-example) to `./config/settings.json`
1. Edit the file to add your OpenAI endpoint configuration

Configure an Azure OpenAI endpoint

1. Copy [settings.json.azure-example](./config/settings.json.azure-example) to `./config/settings.json`
1. Edit the file to add your Azure OpenAI endpoint configuration

## Running the starter

To run the console application use the following command:

```powershell
dotnet run
```
