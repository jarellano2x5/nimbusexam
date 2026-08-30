using System.ComponentModel.DataAnnotations;
using exanim.core.Entities;

namespace exanim.core.DTOs;

public record CFTallerDTO
{
    public Guid? Id { get; set; }
    [Required]
    [Length(3, 15)]
    public string Codigo { get; set; } = string.Empty;
    [Required]
    [Length(5, 50)]
    public string Nombre { get; set; } = string.Empty;
    [Required]
    [MaxLength(150)]
    public string Direccion { get; set; } = string.Empty;
    [Required]
    public Location Lugar { get; set; } = null!;
    [Required]
    public bool Activo { get; set; }
    public Item Usuario { get; set; } = null!;
}
