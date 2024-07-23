using System.Collections;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApplicationCore.Model.Response;

public class CastResponseModel
{
    public int Id { get; set; }
    [Required]
    [Column(TypeName = "nvarchar(MAX)")]
    public string? Gender { get; set; }
    [Required]
    [Column(TypeName = "nvarchar(128)")]
    public string? Name { get; set; }
    [Required]
    [Column(TypeName = "nvarchar(2084)")]
    public string? ProfilePath { get; set; }
    [Required]
    [Column(TypeName = "nvarchar(MAX)")]
    public string? TmdbUrl { get; set; }
    
    // Property from MovieCasts (Conjunction Table)
    [Required]
    [Column(TypeName = "nvarchar(450)")]
    public string? Character { get; set; }
}