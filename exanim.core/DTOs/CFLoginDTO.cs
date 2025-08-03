using System.ComponentModel.DataAnnotations;

namespace exanim.core.DTOs;

public record class CFLoginDTO
{
    [Length(4, 15)]
    [Required]
    public string Usuario { get; set; } = string.Empty;
    [Length(8, 300)]
    [Required]
    public string Password { get; set; } = string.Empty;
}
