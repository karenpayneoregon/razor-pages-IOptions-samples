namespace WebApplication1.Models;

#pragma warning disable CS8618
public class ApplicationFeatures
{
    public const string Settings = "ApplicationFeatures:IndexPage";
    public string Title { get; set; }
    public string ConnectionString { get; set; }
    public bool EnableLogging { get; set; }
}