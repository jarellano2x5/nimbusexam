using System.ComponentModel.DataAnnotations;

namespace exanim.core.DTOs;

public record OPOrdenDTO
{
    public Guid? Id { get; set; }
    public DateTime? Fecha { get; set; }
    [Required]
    [MaxLength(500)]
    public string Problema { get; set; } = string.Empty;
    [MaxLength(500)]
    public string Condicion { get; set; } = string.Empty;
    [MaxLength(150)]
    public string? Correo { get; set; }
    public DateOnly? FechaEntrega { get; set; }
    public Item Unidad { get; set; } = null!;
    public Item Cliente { get; set; } = null!;
    public Item Taller { get; set; } = null!;
    public Item Estado { get; set; } = null!;
    public VEUnidadDTO? Nueva { get; set; }
}
