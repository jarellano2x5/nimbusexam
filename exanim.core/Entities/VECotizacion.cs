namespace exanim.core.Entities;

public class VECotizacion
{
    public Guid CotizacionId { get; set; }
    public DateTime Fecha { get; set; }
    public string Clave { get; set; } = string.Empty;
    public double Monto { get; set; }
    public DateTime Vigencia { get; set; }
    public bool Activo { get; set; }
    public bool Aceptada { get; set; }
    public Guid UsuarioId { get; set; }
    public Guid AgenciaId { get; set; }
    public Guid? OrdenId { get; set; }
}
