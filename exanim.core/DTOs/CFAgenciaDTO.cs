using System.ComponentModel.DataAnnotations;

namespace exanim.core.DTOs;

public record CFAgenciaDTO
{
    public Guid AgenciaId { get; set; }
    [Required]
    [Length(12, 13)]
    public string RFC { get; set; } = string.Empty;
    [Required]
    [Length(5, 150)]
    public string RazonSocial { get; set; } = string.Empty;
    [Required]
    [Length(5, 50)]
    public string Nombre { get; set; } = string.Empty;
    [Required]
    public Option Tipo { get; set; } = null!;
    [Required]
    public Option Plan { get; set; } = null!;
    [Required]
    public bool Activo { get; set; }
    public Guid UsuarioId { get; set; }
}
