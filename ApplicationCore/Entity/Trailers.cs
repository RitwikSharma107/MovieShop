using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApplicationCore.Entity;

public class Trailers
{
    public int Id { get; set; }
    [Required]
    public int MovieId { get; set; }
    [Required]
    [Column(TypeName = "nvarchar(2084)")]
    public string? Name { get; set; }
    [Required]
    [Column(TypeName = "nvarchar(2084)")]
    public string? TrailerUrl { get; set; }
    public Movies? Movie { get; set; }
}
