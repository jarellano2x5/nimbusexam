using System.ComponentModel.DataAnnotations;

namespace exanim.core.DTOs;

public class CFAgenciaDTO
{
    public Guid AgenciaId { get; set; }
    [Length(12, 13)]
    public string RFC { get; set; } = string.Empty;
    [Length(5, 150)]
    public string RazonSocial { get; set; } = string.Empty;
    [Length(5, 50)]
    public string Nombre { get; set; } = string.Empty;
    public Item Tipo { get; set; } = null!;
    public Item Plan { get; set; } = null!;
    public bool Activo { get; set; }
}
