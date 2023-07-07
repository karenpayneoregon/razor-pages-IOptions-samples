namespace ControlLoggingApplication.Models;

#pragma warning disable CS8618
public class ApplicationFeatures
{
    public const string Index = "ApplicationFeatures:IndexPage";
    public const string About = "ApplicationFeatures:AboutPage";
    public string Title { get; set; }
    public bool EnableLogging { get; set; }
}