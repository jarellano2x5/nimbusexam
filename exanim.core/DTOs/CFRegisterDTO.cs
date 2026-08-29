using System.ComponentModel.DataAnnotations;

namespace exanim.core.DTOs;

public record CFRegisterDTO
{
    [Length(4, 15)]
    public string Usuario { get; set; } = string.Empty;
    [Length(8, 25)]
    public string Password { get; set; } = string.Empty;
    [Length(10, 150)]
    public string Correo { get; set; } = string.Empty;
}