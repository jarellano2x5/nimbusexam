namespace exanim.core.Entities;

public class OPInstalacion
{
    public Guid InstalacionId { get; set; }
    public string Marca { get; set; } = string.Empty;
    public float Cantidad { get; set; }
    public string Serie { get; set; } = string.Empty;
    public string Comentario { get; set; } = string.Empty;
    public DateTime Fecha { get; set; }
    public Guid OrdenId { get; set; }
    public Guid OperadorId { get; set; }
    public Guid PiezaId { get; set; }
}
