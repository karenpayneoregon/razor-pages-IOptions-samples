using System.Text.Json;
#pragma warning disable CS8604
#pragma warning disable CS8602

namespace UpdaterApplication.Models;

/// <summary>
/// Used to update properties
/// https://stackoverflow.com/questions/40970944/how-to-update-values-into-appsetting-json
/// </summary>
public class AppSettingsUpdater
{
    private const string EmptyJson = "{}";
    public void UpdateAppSetting(string key, object value)
    {
        if (key == null)
        {
            throw new ArgumentException("Json property key cannot be null", nameof(key));
        }

        const string settingsFileName = "appsettings.json";

        if (!File.Exists(settingsFileName))
        {
            File.WriteAllText(settingsFileName, EmptyJson);
        }

        var config = File.ReadAllText(settingsFileName);

        var updatedConfigDict = UpdateProperty(key, value, config);
        // After receiving the dictionary with updated key value pair, we serialize it back into json.
        var updatedJson = JsonSerializer.Serialize(updatedConfigDict, Options);

        File.WriteAllText(settingsFileName, updatedJson);
    }

    /// <summary>
    /// Updates a JSON configuration segment by modifying or adding a key-value pair.
    /// </summary>
    /// <param name="key">
    /// The key to be updated or added in the JSON structure. Nested keys can be specified using a colon (:) as a separator.
    /// </param>
    /// <param name="value">
    /// The value to associate with the specified key. This can be any object that is serializable to JSON.
    /// </param>
    /// <param name="jsonSegment">
    /// The JSON string representing the segment of the configuration to be updated.
    /// </param>
    /// <returns>
    /// A dictionary representing the updated JSON structure.
    /// </returns>
    /// <exception cref="JsonException">
    /// Thrown if the provided JSON segment is invalid or cannot be deserialized.
    /// </exception>
    private static Dictionary<string, object> UpdateProperty(string key, object value, string jsonSegment)
    {
        const char keySeparator = ':';

        var config = JsonSerializer.Deserialize<Dictionary<string, object>>(jsonSegment);
        var keyParts = key.Split(keySeparator);
        var isKeyNested = keyParts.Length > 1;

        if (isKeyNested)
        {
            var firstKeyPart = keyParts[0];
            var remainingKey = string.Join(keySeparator, keyParts.Skip(1));

            // If the key does not exist already, we will create a new key and append it to the json
            var newJsonSegment = config.ContainsKey(firstKeyPart) && config[firstKeyPart] != null
                ? config[firstKeyPart].ToString()
                : EmptyJson;

            config[firstKeyPart] = UpdateProperty(remainingKey, value, newJsonSegment);

        }
        else
        {
            config[key] = value;
        }

        return config;
    }

    public static JsonSerializerOptions Options => new() { WriteIndented = true };
}