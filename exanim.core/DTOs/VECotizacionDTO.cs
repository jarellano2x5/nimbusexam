namespace exanim.core.DTOs;

public class VECotizacionDTO
{
    public Guid? CotizacionId { get; set; }
    public DateTime? Fecha { get; set; }
    public string Clave { get; set; } = string.Empty;
    public double Monto { get; set; }
    public DateTime Vigencia { get; set; }
    public bool Activo { get; set; }
    public bool Aceptada { get; set; }
    public Item Usuario { get; set; } = null!;
    public Item Agencia { get; set; } = null!;
    public Item? Orden { get; set; }
}
