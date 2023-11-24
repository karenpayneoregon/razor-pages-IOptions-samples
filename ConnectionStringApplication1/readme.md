# Connection timeout example

> **Note**
> 11-2023 Has been update to .NET Core 8

Example for connection time out with `SqlConnection`, in this case because the server does not exists.

All code is in the index page while not correct, should be in a service for data operations.

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
    public string NorthWindConnectionBad { get; set; }
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

    [BindProperty]
    public bool UseBadConnection { get; set; }

    public IndexModel(IOptions<ConnectionOptions> options)
    {
        Options = options;
        Message = "Response goes here";
        UseBadConnection = true;
    }
    
    public void OnGet()
    {
        Log.Information("Connection {P1}", Options.Value.NorthWindConnection);
        Log.Information("Connection {P1}", Options.Value.NorthWindConnectionBad);
        Log.Information("Timeout {P1}", Options.Value.TimeoutSeconds);
    }
    public async Task OnPostTestConnection()
    {
        _cancellationTokenSource = new CancellationTokenSource(
            TimeSpan.FromSeconds(Options.Value.TimeoutSeconds));


        (bool result, Exception exception) = await OpenConnection(_cancellationTokenSource.Token);

        Message = result ? 
            $"<span class=\"text-success fw-bold\">Connected successfully</span>" : 
            $"Failed with: <strong>{exception.Message}</strong>";
        
    }

    public async Task<(bool, Exception exception)> OpenConnection(CancellationToken ct)
    {
        string connectionString = UseBadConnection ? 
            Options.Value.NorthWindConnectionBad : 
            Options.Value.NorthWindConnection;

        try
        {
            await using var cn = new SqlConnection(connectionString);
            await cn.OpenAsync(ct);
            return (true,null)!;
        }
        catch (TaskCanceledException tce)
        {
            return (false, tce);
        }
        catch (Exception ex)
        {
            return (false, ex);
        }
    }
}
```

## See also

Microsoft TechNet [SQL-Server freezes when connecting (C#)](https://social.technet.microsoft.com/wiki/contents/articles/54260.sql-server-freezes-when-connecting-c.aspx)