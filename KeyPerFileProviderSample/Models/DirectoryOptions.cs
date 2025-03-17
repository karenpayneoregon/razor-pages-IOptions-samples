namespace KeyPerFileProviderSample.Models;

/// <summary>
/// Represents configuration options for a directory used in the application read from appsettings.json.
/// </summary>
/// <remarks>
/// This class is used to specify the path to a directory, which is validated 
/// and utilized by various components of the application.
/// </remarks>
public class DirectoryOptions
{
    /// <summary>
    /// Specifies the section in appsettings.json containing this configuration.
    /// </summary>
    public const string Key = "DirectorySettings";
    /// <summary>
    /// Location of the directory containing configuration files for Key-per-file configuration.
    /// </summary>
    public string DirectoryPath { get; set; } = string.Empty;
}

