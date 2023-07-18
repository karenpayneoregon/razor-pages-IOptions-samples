# About

Uses a NuGet [package](https://www.nuget.org/packages/ConfigurationLibrary/) to obtain the connection string in the case a developer does not want to uses services as in the other console projects in this repository.

Given

```json
{
  "ConnectionsConfiguration": {
    "ActiveEnvironment": "Development",
    "Development": "Server=(localdb)\\mssqllocaldb;Database=master;Trusted_Connection=True",
    "Stage": "Stage connection string goes here",
    "Production": "Prod connection string goes here"
  }
}
```

- Get `ActiveEnvironment`
- Get connection string for `ActiveEnvironment`

Note: The above can be used for a single environment

```json
{
  "ConnectionsConfiguration": {
    "ActiveEnvironment": "Development",
    "Development": "Server=(localdb)\\mssqllocaldb;Database=master;Trusted_Connection=True"
  }
}
```


## Code

Add the following using statement

```csharp
using static ConfigurationLibrary.Classes.ConfigurationHelper;
```

Create a connection **ConnectionString()** is from **ConfigurationHelper**

```csharp
using var cn = new SqlConnection(ConnectionString());
```

