using Microsoft.AspNetCore.Mvc.RazorPages;
using Serilog;

namespace ValidateOnStartWithClasses.Pages;

public class IndexModel : PageModel
{

    public IndexModel()
    {
    }

    public void OnGet()
    {
        Log.Information("We are validated!!!");
    }
}
