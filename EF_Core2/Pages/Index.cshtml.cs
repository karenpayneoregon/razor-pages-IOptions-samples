using EF_Core2.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Serilog;

namespace ConnectionStringApplication.Pages;
public class IndexModel : PageModel
{
    private readonly Context _context;
    [BindProperty]
    public int Count { get; set; }

    [BindProperty]
    public string SettingFile { get; set; }
    public IndexModel(Context context)
    {
        _context = context;

        SettingFile = """
            {
              "Logging": {
                "LogLevel": {
                  "Default": "Information",
                  "Microsoft.AspNetCore": "Warning",
                  "Microsoft.EntityFrameworkCore.Database.Command": "Information"
                }
              },
              "AllowedHosts": "*",
              "ConnectionStrings": {
                <span class = 'fw-bold text-danger'>"NorthWindConnection": "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=NorthWind2022;Integrated Security=True"</span>
              }
            }
            """;


    }

    public void OnGet()
    {
        int value = 5;
        var customers = _context
            .Customers
            .Where(customer => customer.CustomerIdentifier > value)
            .ToList();

        Log.Information("Customer count {P1}", customers.Count);
        Count = customers.Count;    
    }
}
