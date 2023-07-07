using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Options;
using Serilog;
using VariousMethodsApplication.Models;

namespace VariousMethodsApplication.Pages;

public class NamedOptionsModel : PageModel
{
    [ViewData]
    public string Title { get; set; }

    public string Subject { get; set; }

    private readonly TopItemSettings _monthTopItem;
    private readonly TopItemSettings _yearTopItem;

    private readonly PageDetails _pageDetails;

    public NamedOptionsModel(IOptionsSnapshot<TopItemSettings> topItemSettings, IOptionsSnapshot<PageDetails> pageTitle)
    {
        _monthTopItem = topItemSettings.Get(TopItemSettings.Month);
        _yearTopItem = topItemSettings.Get(TopItemSettings.Year);
        _pageDetails = pageTitle.Get(PageDetails.NamedOptions);

        Title = _pageDetails.Title;
        Subject = _pageDetails.Subject;

    }
    public void OnGet()
    {
        Log.Information("For {P1}", nameof(TopItemSettings));
        Log.Information("Month Name: {P1} Model {P2}", _monthTopItem.Name, _monthTopItem.Model);
        Log.Information("Year Name: {P1} Model {P2} \n", _yearTopItem.Name, _yearTopItem.Model);
    }
}