using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApplicationCore.Entity;

public class Roles
{
    public int Id { get; set; }
    [Required]
    [Column(TypeName = "nvarchar(20)")]
    public string? Name { get; set; }
}