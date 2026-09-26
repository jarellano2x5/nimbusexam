namespace exanim.core.DTOs;

public record VECotizacionMinDTO
{
    public Guid Id { get; set; }
    public DateTime Fecha { get; set; }
    public string Clave { get; set; } = string.Empty;
    public string Vehiculo { get; set; } = string.Empty;
    public double Monto { get; set; }
    public DateOnly Vigencia { get; set; }
    public bool Aceptada { get; set; }
    public Guid UsuarioId { get; set; }
    public Guid? OrdenId { get; set; }
    public Item? Unidad { get; set; }
}