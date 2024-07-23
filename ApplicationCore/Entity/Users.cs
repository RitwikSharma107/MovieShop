using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApplicationCore.Entity;

public class Users
{
    public int Id { get; set; }
    public DateTime DateOfBirth { get; set; }
    [Required]
    [Column(TypeName="nvarchar(256)")]
    public string? Email { get; set; }
    [Required]
    [Column(TypeName="nvarchar(128)")]
    public string? FirstName { get; set; }
    [Required]
    [Column(TypeName="nvarchar(1024)")]
    public string? HashedPassword { get; set; }
    public bool IsLocked { get; set; }
    [Required]
    [Column(TypeName="nvarchar(128)")]
    public string? Lastname { get; set; }
    [Column(TypeName="nvarchar(16)")]
    public string? PhoneNumber { get; set; }
    [Column(TypeName="nvarchar(MAX)")]
    public string? ProfilePictureUrl { get; set; }
    [Required]
    [Column(TypeName="nvarchar(1024)")]
    public string? Salt { get; set; }
}