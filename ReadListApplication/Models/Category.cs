using System.ComponentModel.DataAnnotations;

namespace ReadListApplication.Models;
#nullable disable
public class Category
{
    public int Id { get; set; }
    public string Name { get; set; }
    public override string ToString() => Name;

}