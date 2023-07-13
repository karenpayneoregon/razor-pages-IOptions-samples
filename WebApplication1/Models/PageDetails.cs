#pragma warning disable CS8618
namespace VariousMethodsApplication.Models;

public class PageDetails
{
    public const string MainPage = "PageDetails:Index";
    public const string ApplicationFeaturesLoose = "PageDetails:ApplicationFeaturesLoose";
    public const string ApplicationFeaturesStrong = "PageDetails:ApplicationFeaturesStrong";
    public const string NamedOptions = "PageDetails:NamedOptions";
    public const string Monitor = "PageDetails:Monitor";

    public string Title { get; set; }
    public string Subject { get; set; }
}