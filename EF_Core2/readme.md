# About

Shows how to get a connection string from appsettings.json in Program.cs


```csharp
builder.Services.AddDbContextPool<Context>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
        .EnableSensitiveDataLogging()
        .LogTo(new DbContextLogger().Log, (id, _) => id == RelationalEventId.CommandExecuting));
```

Where the following is the key part to get the connection string

```csharp
builder.Configuration.GetConnectionString("DefaultConnection")
```