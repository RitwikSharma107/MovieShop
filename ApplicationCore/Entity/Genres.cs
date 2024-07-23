using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApplicationCore.Entity;

public class Genres
{
    public int Id { get; set; }
    [Required]
    [Column(TypeName = "nvarchar(24)")]
    public string? Name { get; set; }
    
    // Property added to link Movies and Genres Tables
    public ICollection<MovieGenres>?  MovieGenres{ get; set; }
}