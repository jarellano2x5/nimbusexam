using System.ComponentModel.DataAnnotations;

namespace exanim.core.DTOs;

public record CFParametroDTO
{
    public Guid ParametroId { get; set; }
    [Required]
    [Length(2, 10)]
    public string Clave { get; set; } = string.Empty;
    [Required]
    [Length(3, 100)]
    public string Nombre { get; set; } = string.Empty;
    [Required]
    public Option Tipo { get; set; } = null!;
    [Required]
    public bool Activo { get; set; }
}
