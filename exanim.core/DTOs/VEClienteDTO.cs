using System.ComponentModel.DataAnnotations;

namespace exanim.core.DTOs;

public record VEClienteDTO
{
    public Guid? Id { get; set; }
    [Required]
    public bool Activo { get; set; }
    [Required]
    public Item Usuario { get; set; } = null!;
    [Required]
    public Item? Compania { get; set; }
}
