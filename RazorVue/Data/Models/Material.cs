using System.ComponentModel.DataAnnotations;

namespace RazorVue.Data.Models;

public class Material
{
    public int Id { get; set; }

    [Required] public string Description { get; set; }

    public string ExternalReference { get; set; }
    public string OriginatingSystem { get; set; }
}