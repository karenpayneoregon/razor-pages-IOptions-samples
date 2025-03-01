using Microsoft.Extensions.Options;
using VariousMethodsApplication.Models;

namespace VariousMethodsApplication.Classes;

public class MySingletonService
{
    public MySingletonService(IOptionsMonitor<AzureSettings> options)
    {
        var namedOptions = options.Get("TenantName");
        var defaultOptions = options.CurrentValue; 
    }
}
