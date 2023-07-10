#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace UpdaterApplication.Models;

public class JobSettings
{
    
    public string Title { get; set; }
    
    public string Type { get; set; }
}