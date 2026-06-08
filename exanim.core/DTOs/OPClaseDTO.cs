using System.ComponentModel.DataAnnotations;

namespace exanim.core.DTOs;

public record OPClaseDTO
{
    public Guid ClaseId { get; set; }
    [Length(3, 45)]
    public string Nombre { get; set; } = string.Empty;
    [Required]
    public bool Activo { get; set; }
    [Required]
    public Item Agencia { get; set; } = null!;
}
