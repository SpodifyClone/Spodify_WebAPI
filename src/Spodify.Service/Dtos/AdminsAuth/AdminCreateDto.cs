using System.ComponentModel.DataAnnotations;
using Spodify.Domain.Enums;

namespace Spodify.Service.Dtos.Admins;

public class AdminCreateDto
{
    public string Username { get; set; } = string.Empty;
    [MaxLength(20)]
    public string Email { get; set; } = string.Empty;
    public string PasswordHash { get; set; } = string.Empty;
    public UserRole Role { get; set; }
}
