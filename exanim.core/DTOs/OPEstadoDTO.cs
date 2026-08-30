using System.ComponentModel.DataAnnotations;

namespace exanim.core.DTOs;

public record class OPEstadoDTO
{
    public Guid? Id { get; set; }
    [Length(3, 30)]
    public string Nombre { get; set; } = string.Empty;
    public Option Fase { get; set; } = null!;
    [MaxLength(15)]
    public string Code { get; set; } = string.Empty;
    public bool Activo { get; set; }
}
