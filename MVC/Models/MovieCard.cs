using System.ComponentModel.DataAnnotations.Schema;

namespace MovieShop.Models;

public class MovieCard
{
    public int Id { get; set; }
    [Column(TypeName = "nvarchar(256)")]
    
    public string? PosterUrl { get; set; }
}