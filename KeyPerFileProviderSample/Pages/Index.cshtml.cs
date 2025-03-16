using KeyPerFileProviderSample.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Options;

#nullable disable

namespace KeyPerFileProviderSample.Pages;

public class IndexModel(IOptions<HelpDesk> helpDeskOptions) : PageModel
{
    private readonly HelpDesk _helpDesk = helpDeskOptions.Value;

    public string Phone { get; private set; }
    public string Email { get; private set; }

    public void OnGet()
    {
        Phone = _helpDesk.Phone;
        Email = _helpDesk.Email;
    }
}