# About

An example for displaying property values from appsettings.json in _Layout.cshtml


## Model

```csharp
public class HelpDesk
{
    public string Phone { get; set; }
    public string Email { get; set; }
}
```

## Program.cs

```csharp
public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddRazorPages();

        builder.Services.Configure<HelpDesk>(
            builder.Configuration.GetSection(nameof(HelpDesk)));
```

## _Layout.cshtml

Required using statements

```html
@using GetSettingInLayoutApplication.Models
@using Microsoft.AspNetCore.Mvc.TagHelpers
@using Microsoft.Extensions.Options
@inject IOptions<HelpDesk> HelpDeskOptions
```

**Footer**

```html
<footer class="border-top footer text-muted">
    <div class="container">
        <span class="fw-bold">Help desk Phone:</span> @HelpDeskOptions.Value.Phone <span class="fw-bold">Email:</span>  @HelpDeskOptions.Value.Email
    </div>
</footer>
```
