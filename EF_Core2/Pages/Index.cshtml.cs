using System.Data;
using ConnectionStringApplication.Data;
using ConnectionStringApplication.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;
using Serilog;

namespace ConnectionStringApplication.Pages;
public class IndexModel : PageModel
{
    private readonly IConfiguration _configuration;
    private readonly Context _context;

    [BindProperty]
    public int EntityCount { get; set; }
    [BindProperty]
    public int ProviderCount { get; set; }

    [BindProperty]
    public string SettingFile { get; set; }
    public IndexModel(IConfiguration configuration, Context context)
    {
        _configuration = configuration;

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
        UsingDataProvider();
        UsingEntityFrameworkCore();
    }

    private void UsingEntityFrameworkCore()
    {
        int value = 5;

        var customers = _context
            .Customers
            .Where(customer => customer.CustomerIdentifier > value)
            .ToList();

        Log.Information("Customer count {P1}", customers.Count);
        EntityCount = customers.Count;
    }

    /// <summary>
    /// Example to get connection string from appsettings.json for
    /// Microsoft.Data.SqlClient data provider
    /// </summary>
    private void UsingDataProvider()
    {
        List<Customers> customers = new();
        var statement = """
            SELECT CustomerIdentifier
                  ,CompanyName
                  ,ContactId
                  ,Street
                  ,City
            	  ,COALESCE(Region, 'Unknown') AS Region
                  ,COALESCE(PostalCode, 'Unknown') AS PostalCode
                  ,CountryIdentifier
                  ,Phone
                  ,COALESCE(Fax, 'Unknown') AS Fax
                  ,ContactTypeIdentifier
                  ,ModifiedDate
              FROM dbo.Customers WHERE CustomerIdentifier > @CustomerIdentifier
            """;

        int value = 5;

        // get connection string from appsettings.json
        var connectionString = _configuration.GetValue<string>("ConnectionStrings:NorthWindConnection");

        using var cn = new SqlConnection(connectionString);
        using var cmd = new SqlCommand(statement, cn);
        cmd.Parameters.Add("@CustomerIdentifier", SqlDbType.Int).Value = value;
        cn.Open();

        var reader = cmd.ExecuteReader();
        while (reader.Read())
        {
            customers.Add(new Customers()
            {
                CustomerIdentifier = reader.GetInt32(0),
                CompanyName = reader.GetString(1),
                ContactId = reader.GetInt32(2),
                Street = reader.GetString(3),
                City = reader.GetString(4),
                CountryIdentifier = reader.GetInt32(7),
                Phone = reader.GetString(8),
                ContactTypeIdentifier = reader.GetInt32(10),
                ModifiedDate = reader.GetDateTime(11),
            });
        }

        ProviderCount = customers.Count;
    }
}
