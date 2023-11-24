
using System.Diagnostics.CodeAnalysis;

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
namespace ConnectionStringApplication1.Models;
[SuppressMessage("ReSharper", "InconsistentNaming")]
public class Categories
{
    /// <summary>
    /// Primary key
    /// </summary>
    public int CategoryID { get; set; }

    /// <summary>
    /// Name of a category
    /// </summary>
    public string CategoryName { get; set; }

    /// <summary>
    /// Description of category
    /// </summary>
    public string Description { get; set; }

  
}