using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace ApplicationCore.Entity;

[Keyless]
public class MovieGenres
{
    [Required]
    public int GenreId { get; set; }
    [Required]
    public int MovieId { get; set; }
    public Genres? Genre { get; set; }
    public Movies? Movie { get; set; }
}