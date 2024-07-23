using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApplicationCore.Model.Request;

public class GenreRequestModel
{
    [Required]
    [Column(TypeName = "nvarchar(24)")]
    public string? Name { get; set; }
}