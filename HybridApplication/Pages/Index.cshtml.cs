using Hybrid.Core.Data;
using Hybrid.Core.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
#pragma warning disable CS8618

namespace HybridApplication.Pages;
public class IndexModel : PageModel
{
    [BindProperty]
    public List<Applications> ApplicationsList { get; set; }
    private readonly Context _context;
    public IndexModel(Context context)
    {
        _context = context;
    }

    public void OnGet()
    {
        ApplicationsList = _context.Applications.ToList();
    }
}
