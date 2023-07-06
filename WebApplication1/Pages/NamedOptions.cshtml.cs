using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Options;
using Serilog;
using WebApplication1.Models;

namespace WebApplication1.Pages;

public class NamedOptionsModel : PageModel
{
    [ViewData]
    public string Title { get; set; }

    private readonly TopItemSettings _monthTopItem;
    private readonly TopItemSettings _yearTopItem;

    private readonly PageTitles _title;

    public NamedOptionsModel(IOptionsSnapshot<TopItemSettings> topItemSettings, IOptionsSnapshot<PageTitles> pageTitle)
    {
        _monthTopItem = topItemSettings.Get(TopItemSettings.Month);
        _yearTopItem = topItemSettings.Get(TopItemSettings.Year);
        _title = pageTitle.Get(PageTitles.NamedOptions);

        Title = _title.Title;

    }
    public void OnGet()
    {
        Log.Information("For {P1}", nameof(TopItemSettings));
        Log.Information("Month Name: {P1} Model {P2}", _monthTopItem.Name, _monthTopItem.Model);
        Log.Information("Year Name: {P1} Model {P2} \n", _yearTopItem.Name, _yearTopItem.Model);
    }
}