using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ApplicationCore.Entity;

[Keyless]
public class MovieCasts
{
    [Required]
    public int CastId { get; set; }

    [Required]
    [Column(TypeName = "nvarchar(450)")]
    public string? Character { get; set; }
    [Required]
    public int MovieId { get; set; }

    public Casts? Cast { get; set; }
    public Movies? Movie { get; set; }
}