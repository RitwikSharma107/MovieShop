using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace ApplicationCore.Entity;

[Keyless]
public class UserRoles
{
    [Required]
    public int RoleId { get; set; }
    [Required]
    public int UserId { get; set; }
    public Roles? Role { get; set; }
    public Users? User { get; set; }
}
