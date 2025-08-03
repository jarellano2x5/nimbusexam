namespace exanim.core.Entities;

public class OPAvance : Entity
{
    public Guid AvanceId { get; set; }
    public DateTime Fecha { get; set; }
    public string Anotacion { get; set; } = string.Empty;
    public string Comentario { get; set; } = string.Empty;
    public Guid OrdenId { get; set; }
    public Guid UsuarioId { get; set; }
    public Guid EstatusId { get; set; }
}
