using System.ComponentModel.DataAnnotations;

namespace exanim.core.DTOs;

public record VELineaDTO
{
    public Guid? Id { get; set; }
    [MaxLength(20)]
    public string Clave { get; set; } = string.Empty;
    [MaxLength(15)]
    public string Unidad { get; set; } = string.Empty;
    [MaxLength(500)]
    public string Concepto { get; set; } = string.Empty;
    [Required]
    [Range(0.01, float.MaxValue)]
    public float Cantidad { get; set; }
    [Range(0.01, float.MaxValue)]
    public float Precio { get; set; }
    public float Importe { get; set; }
}
