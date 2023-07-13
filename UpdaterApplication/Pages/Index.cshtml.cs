using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Options;
using System.ComponentModel.DataAnnotations;
using UpdaterApplication.Models;

namespace UpdaterApplication.Pages;
[BindProperties]
public class IndexModel : PageModel
{

    [Display(Name = "Job title")]
    public string Title { get; set; }
    [Display(Name = "Job type")]
    public string Type { get; set; }

    private readonly IOptionsSnapshot<JobSettings> _jobSettings;
    public IndexModel(IOptionsSnapshot<JobSettings> jobSettings)
    {

        _jobSettings = jobSettings;

        Title = _jobSettings.Value.Title;
        Type = _jobSettings.Value.Type;

    }

    public void OnPost()
    {
        var settingsUpdater = new AppSettingsUpdater();
        settingsUpdater.UpdateAppSetting("Job:Title", Title);
        settingsUpdater.UpdateAppSetting("Job:Type", Type);
    }
    public void OnGet()
    {

    }
}
