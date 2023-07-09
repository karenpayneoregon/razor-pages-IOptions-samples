using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Options;
using ReadListApplication.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
#pragma warning disable CS8618

namespace ReadListApplication.Pages;
public class IndexModel : PageModel
{

    public List<SelectListItem> Options { get; set; }
    [BindProperty]
    public int SelectedCategory { get; set; }
    private readonly IOptions<List<Category>> _categories;
    public IndexModel(IOptions<List<Category>> categories)
    {
        _categories = categories;

    }

    public void OnGet()
    {
        Options = _categories.Value.Select(category => new SelectListItem()
        {
            Value = category.Id.ToString(),
            Text = category.Name
        }).ToList();
    }

    public RedirectToPageResult OnPost(int id)
    {

        return RedirectToPage("Results", new
        {
            sender = _categories.Value.FirstOrDefault(x => x.Id == id)!.Name
        });
    }
}
