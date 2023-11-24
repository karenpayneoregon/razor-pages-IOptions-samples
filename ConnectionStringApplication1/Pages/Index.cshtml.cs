using ConnectionStringApplication1.Classes;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Options;
using Serilog;
#pragma warning disable CS8618

namespace ConnectionStringApplication1.Pages;
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