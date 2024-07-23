using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace ApplicationCore.Entity;

[Keyless]
public class Purchases
{
    [Required]
    public int MovieId { get; set; }
    [Required]
    public int UserId { get; set; }
    [Required]
    public DateTime PurchaseDateTime { get; set; }
    [Required]
    public Guid PurchaseNumber { get; set; }
    [Required]
    public decimal TotalPrice { get; set; }
    public Movies? Movie { get; set; }
    public Users? User { get; set; }
}

