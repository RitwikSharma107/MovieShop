using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace ApplicationCore.Entity;

[Keyless]
public class Favorites
{
    [Required]
    public int MovieId { get; set; }
    [Required]
    public int UserId { get; set; }
    public Movies? Movie { get; set; }
    public Users? User { get; set; }
}