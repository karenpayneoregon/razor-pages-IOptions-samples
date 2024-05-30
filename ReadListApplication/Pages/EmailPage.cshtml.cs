using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Options;
using ReadListApplication.Models;

namespace ReadListApplication.Pages
{
    public class EmailPageModel(IOptions<DistributionWhitelist> distributionWhitelist) : PageModel
    {
        [BindProperty]
        public string[]? DistributionWhitelists { get; set; }

        public void OnGet()
        {
            DistributionWhitelists = distributionWhitelist.Value.Emails;
        }
    }
}
