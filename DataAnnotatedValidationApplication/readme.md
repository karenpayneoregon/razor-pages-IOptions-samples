# About

This project shows how to validate values in appsettings.json using Data Annotations validation in Program.cs

Here we validate several properties have values along with one property to be set to false.

```csharp
public static void Main(string[] args)
{
    var builder = WebApplication.CreateBuilder(args);

    builder.Services.AddOptions<AzureSettings>()
        .BindConfiguration(nameof(AzureSettings))
        .ValidateDataAnnotations()
        .Validate(audience 
            => !string.IsNullOrWhiteSpace(audience.Audience), "Audience is required")
        .Validate(audience 
            => audience.UseAdal == false, "UseAdal must be false")
        .ValidateOnStart();
```

In the code above if the rules are violated the validation failure will cause a run time exception at start-up.

Model

```csharp
public class AzureSettings
{
    public const string Settings = "AzureSettings";
    [Required]
    public bool UseAdal { get; set; }
    public string Tenant { get; set; }
    public string TenantName { get; set; }
    public string TenantId { get; set; }
    [Required]
    public string Audience { get; set; }
```