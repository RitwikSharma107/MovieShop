using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ApplicationCore.Entity;

[Keyless]
public class Reviews
{
    [Required]
    public int MovieId { get; set; }
    [Required]
    public int UserId { get; set; }
    [Required]
    public DateTime CreatedDate { get; set; }
    [Required]
    [Column(TypeName = "decimal(3,2)")]
    public decimal Rating { get; set; }
    [Required]
    [Column(TypeName = "nvarchar(MAX)")]
    public string? ReviewText { get; set; }
    public Movies? Movie { get; set; }
    public Users? User { get; set; }
}