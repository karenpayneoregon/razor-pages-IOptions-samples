using ConnectionStringApplication1.Classes;
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
    public async Task OnPostTestConnection()
    {
        _cancellationTokenSource = new CancellationTokenSource(
            TimeSpan.FromSeconds(Options.Value.TimeoutSeconds));

        (bool result, Exception exception) = await OpenConnection(_cancellationTokenSource.Token);
        if (result)
        {
            Message = $"Done";
        }
        else
        {
            Message = $"Failed with: <strong>{exception.Message}</strong>";
        }
        
    }

    public async Task<(bool, Exception exception)> OpenConnection(CancellationToken ct)
    {
        try
        {
            await using var cn = new SqlConnection(Options.Value.NorthWindConnection);
            await cn.OpenAsync(ct);
            return (true,null);
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