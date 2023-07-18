# About

Example for connection time out, in this case because the server does not exists.

Usually the default timeout is 30 seconds, here it's 4 seconds.

```json
{
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "AllowedHosts": "*",
  "ConnectionOptions": {
    "NorthWindConnection": "Data Source=.\\sqlexpressISSUE;Initial Catalog=NorthWind2020;Integrated Security=True",
    "TimeoutSeconds": 4
  }
}
```

## Program.cs

```csharp
public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddRazorPages();

        builder.Services.Configure<ConnectionOptions>(
            builder.Configuration.GetSection(nameof(ConnectionOptions)));
```

## Model

```csharp
public class ConnectionOptions
{
    public string NorthWindConnection { get; set; }
    public int TimeoutSeconds { get; set; }
}
```

## Index.cshtml.cs

```csharp
public class IndexModel : PageModel
{
    private CancellationTokenSource _cancellationTokenSource;
    public string Message { get; set; }
    public IOptions<ConnectionOptions> Options { get; }


    public IndexModel(IOptions<ConnectionOptions> options)
    {
        Options = options;
        Message = "Response goes here";
    }
    
    public void OnGet()
    {
        Log.Information("Connection {P1}", Options.Value.NorthWindConnection);
        Log.Information("Timeout {P1}", Options.Value.TimeoutSeconds);
    }
```

## See also

Microsoft TechNet [SQL-Server freezes when connecting (C#)](https://social.technet.microsoft.com/wiki/contents/articles/54260.sql-server-freezes-when-connecting-c.aspx)