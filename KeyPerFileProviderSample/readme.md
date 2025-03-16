# About

A sample project that demonstrates how to use the `KeyPerFileProvider` to load keys from files.

## Expectations

- `DirectoryPath` path points to a valid directory.
- The files in the project assets folder reside in the directory set in `DirectoryPath`

If the directory does not exist, the application will throw an exception in Program.cs using 

```csharp
builder.Services.AddSingleton<IValidateOptions<DirectoryOptions>, DirectoryOptionsValidator>();
```

### In appsettings,json

```json
{
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "AllowedHosts": "*",
  "DirectorySettings": {
    "DirectoryPath": "C:\\OED\\Secrets"
  }
}
```