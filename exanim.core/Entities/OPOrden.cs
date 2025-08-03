namespace exanim.core.Entities;

public class OPOrden : Entity
{
    public Guid OrdenId { get; set; }
    public DateTime Fecha { get; set; }
    public string Problema { get; set; } = string.Empty;
    public string Condicion { get; set; } = string.Empty;
    public string? Correo { get; set; }
    public DateTime? FechaEntrega { get; set; }
    public Guid UnidadId { get; set; }
    public Guid GestorId { get; set; }
    public Guid UsuarioId { get; set; }
    public Guid TallerId { get; set; }
    public Guid EstatusId { get; set; }
}
