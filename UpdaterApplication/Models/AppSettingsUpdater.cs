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
        // Empty keys "" are allowed in json by the way
        if (key == null)
        {
            throw new ArgumentException("Json property key cannot be null", nameof(key));
        }

        const string settingsFileName = "appsettings.json";

        // We will create a new file if appsettings.json doesn't exist or was deleted
        if (!File.Exists(settingsFileName))
        {
            File.WriteAllText(settingsFileName, EmptyJson);
        }

        var config = File.ReadAllText(settingsFileName);

        var updatedConfigDict = UpdateJson(key, value, config);
        // After receiving the dictionary with updated key value pair, we serialize it back into json.
        var updatedJson = JsonSerializer.Serialize(updatedConfigDict, new JsonSerializerOptions
        {
            WriteIndented = true
        });

        File.WriteAllText(settingsFileName, updatedJson);
    }

    // This method will recursively read json segments separated by semicolon (firstObject:nestedObject:someProperty)
    // until it reaches the desired property that needs to be updated,
    // it will update the property and return json document represented by dictionary of dictionaries of dictionaries and so on.
    // This dictionary structure can be easily serialized back into json
    private Dictionary<string, object> UpdateJson(string key, object value, string jsonSegment)
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

            config[firstKeyPart] = UpdateJson(remainingKey, value, newJsonSegment);

        }
        else
        {
            config[key] = value;
        }

        return config;
    }
}