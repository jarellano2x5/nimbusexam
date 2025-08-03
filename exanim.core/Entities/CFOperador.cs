namespace exanim.core.Entities;

public class CFOperador
{
    public Guid OperadorId { get; set; }
    public DateTime Fecha { get; set; }
    public bool Activo { get; set; }
    public Guid UsuarioId { get; set; }
    public Guid AgenciaId { get; set; }
}
