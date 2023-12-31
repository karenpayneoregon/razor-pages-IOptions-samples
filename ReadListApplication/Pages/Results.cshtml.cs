using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ReadListApplication.Pages;

public class ResultsModel : PageModel
{
    [BindProperty]
    public string CategoryName { get; set; } = string.Empty;
    public void OnGet(string sender)
    {
        CategoryName = sender;
    }
}