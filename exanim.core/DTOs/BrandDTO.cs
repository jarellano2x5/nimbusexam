using System.ComponentModel.DataAnnotations;

namespace exanim.core.DTOs;

public record BrandDTO
{
    public Guid BrandId { get; set; }
    [Required]
    [Length(3, 30)]
    public string Name { get; set; } = string.Empty;
    [Required]
    public bool Activo { get; set; }
}
