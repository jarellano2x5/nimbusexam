namespace exanim.core.Entities;

public class OPPieza : Entity
{
    public Guid PiezaId { get; set; }
    public string Nombre { get; set; } = string.Empty;
    public bool Activo { get; set; }
    public Guid UsuarioId { get; set; }
    public Guid AgenciaId { get; set; }
    public Guid ClaseId { get; set; }
}
