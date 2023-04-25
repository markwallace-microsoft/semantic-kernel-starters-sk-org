﻿// Copyright (c) Microsoft. All rights reserved.

using System.Text.Json;
using System.Text.Json.Serialization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

internal class KernelSettings
{
    public const string DefaultConfigFile = "config/settings.json";
    public const string OpenAI = "OPENAI";
    public const string AzureOpenAI = "AZUREOPENAI";

    [JsonPropertyName("serviceType")]
    public string ServiceType { get; set; } = string.Empty;

    [JsonPropertyName("serviceId")]
    public string ServiceId { get; set; } = string.Empty;

    [JsonPropertyName("deploymentOrModelId")]
    public string DeploymentOrModelId { get; set; } = string.Empty;

    [JsonPropertyName("endpoint")]
    public string Endpoint { get; set; } = string.Empty;

    [JsonPropertyName("apiKey")]
    public string ApiKey { get; set; } = string.Empty;

    [JsonPropertyName("orgId")]
    public string OrgId { get; set; } = string.Empty;

    [JsonPropertyName("logLevel")]
    public LogLevel? LogLevel { get; set; }

    /// <summary>
    /// Load the kernel settings from settings.json if the file exists and if not attempt to use user secrets.
    /// </summary>
    internal static KernelSettings LoadSettings()
    {
        if (File.Exists(DefaultConfigFile))
        {
            return FromFile(DefaultConfigFile);
        }

        return FromUserSecrets();
    }

    /// <summary>
    /// Load the kernel settings from the specified configuration file if it exists.
    /// </summary>
    internal static KernelSettings FromFile(string configFile = DefaultConfigFile)
    {
        if (!File.Exists(configFile))
        {
            throw new FileNotFoundException($"Configuration not found: {configFile}");
        }

        var configJson = File.ReadAllText(configFile);

        return JsonSerializer.Deserialize<KernelSettings>(configJson)
               ?? throw new InvalidDataException("Invalid semantic kernel settings");
    }

    /// <summary>
    /// Load the kernel settings from user secrets.
    /// </summary>
    internal static KernelSettings FromUserSecrets()
    {
        var configuration = new ConfigurationBuilder()
            .AddUserSecrets<KernelSettings>()
            .Build();

        return configuration.Get<KernelSettings>()
               ?? throw new InvalidDataException("Invalid semantic kernel user secret settings");
    }
}
