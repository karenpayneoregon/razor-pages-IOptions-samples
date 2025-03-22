using KeyPerFileProviderSample.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Options;

#nullable disable

namespace KeyPerFileProviderSample.Pages;

/// <summary>
/// Represents the model for the Index page, providing data for display and handling page logic.
/// </summary>
/// <remarks>
/// This class retrieves configuration data for the HelpDesk and Connections settings using dependency injection.
/// </remarks>
/// <param name="helpDeskOptions">
/// An instance of <see cref="IOptions{TOptions}"/> for accessing HelpDesk configuration values.
/// </param>
/// <param name="connections">
/// An instance of <see cref="IOptions{TOptions}"/> for accessing Connections configuration values.
/// </param>
public class IndexModel(IOptions<HelpDesk> helpDeskOptions, IOptions<Connections> connections) : PageModel
{
    private readonly HelpDesk _helpDesk = helpDeskOptions.Value;
    private readonly Connections _connections = connections.Value;
    public string Phone { get; private set; }
    public string Email { get; private set; }
    public string ConnectionString { get; private set; }

    public void OnGet()
    {

        Phone = _helpDesk.Phone;
        Email = _helpDesk.Email;
        
        ConnectionString = _connections.ConnectionString;

    }
}