using System.ComponentModel.DataAnnotations;

namespace exanim.core.DTOs;

public record VEUnidadDTO
{
    public Guid? Id { get; set; }
    [Required]
    [Length(3, 15)]
    public string Placa { get; set; } = string.Empty;
    [Required]
    [Length(3, 30)]
    public string Modelo { get; set; } = string.Empty;
    [Required]
    [Length(2, 4)]
    public string Anio { get; set; } = string.Empty;
    [Required]
    [Length(2, 15)]
    public string Color { get; set; } = string.Empty;
    public DateTime? Registrado { get; set; }
    [Required]
    public Item Marca { get; set; } = null!;
}
