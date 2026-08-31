using System.ComponentModel.DataAnnotations;

namespace exanim.core.DTOs;

public record VECotizacionDTO
{
    public Guid? Id { get; set; }
    public DateTime? Fecha { get; set; }
    [MaxLength(20)]
    public string Clave { get; set; } = string.Empty;
    [MaxLength(50)]
    public string Vehiculo { get; set; } = string.Empty;
    public double Monto { get; set; }
    [Required]
    public DateOnly Vigencia { get; set; }
    public bool Activo { get; set; }
    public bool Aceptada { get; set; }
    public Item Usuario { get; set; } = null!;
    public Item? Cliente { get; set; }
    public Item? Orden { get; set; }

    public IEnumerable<VELineaDTO> Lineas { get; set; } = [];
}
