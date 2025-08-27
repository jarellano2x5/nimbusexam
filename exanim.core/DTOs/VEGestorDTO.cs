using System.ComponentModel.DataAnnotations;

namespace exanim.core.DTOs;

public record VEGestorDTO
{
    public Guid GestorId { get; set; }
    [Required]
    public bool Activo { get; set; }
    [Required]
    public Guid UsuarioId { get; set; }
    [Required]
    public Item Compania { get; set; } = null!;
}
