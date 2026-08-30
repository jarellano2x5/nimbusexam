using System.ComponentModel.DataAnnotations;

namespace exanim.core.DTOs;

public record CFSocioDTO
{
    public Guid? Id { get; set; }
    [Required]
    [MaxLength(150)]
    public string Nombre { get; set; } = string.Empty;
    [Required]
    [Length(4, 15)]
    public string Usuario { get; set; } = string.Empty;
    [Required]
    [Length(10, 150)]
    public string Correo { get; set; } = string.Empty;
    public Item Perfil { get; set; } = null!;
}