using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Options;
using ReadListApplication.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Configuration;
#pragma warning disable CS8618

namespace ReadListApplication.Pages;
public class IndexModel : PageModel
{
    private readonly IConfiguration _configuration;
    public List<SelectListItem> Options { get; set; }
    [BindProperty]
    public int SelectedCategory { get; set; }

    private readonly IOptions<List<Category>> _categories;
    private readonly IOptions<DistributionWhitelist> _distributionWhitelist;
    
    public IndexModel(IOptions<List<Category>> categories, IOptions<DistributionWhitelist> distributionWhitelist)
    {
        _categories = categories;
        _distributionWhitelist = distributionWhitelist;
    }

    public void OnGet()
    {
        Options = _categories.Value.Select(category => new SelectListItem()
        {
            Value = category.Id.ToString(),
            Text = category.Name
        }).ToList();

        foreach (var email in _distributionWhitelist.Value.Emails)
        {
            Console.WriteLine(email);
        }

    }

    public RedirectToPageResult OnPost(int id)
    {

        return RedirectToPage("Results", new
        {
            sender = _categories.Value.FirstOrDefault(x => x.Id == id)!.Name
        });
    }

}
