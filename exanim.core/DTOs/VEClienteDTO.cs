using System.ComponentModel.DataAnnotations;

namespace exanim.core.DTOs;

public record VEClienteDTO
{
    public Guid Id { get; set; }
    [Required]
    public bool Activo { get; set; }
    [Required]
    public Guid UsuarioId { get; set; }
    [Required]
    public Item Compania { get; set; } = null!;
}
