namespace exanim.core.Entities;

public class CFOperador : Entity
{
    public Guid OperadorId { get; set; }
    public DateTime Fecha { get; set; }
    public bool Activo { get; set; }
    public Guid UsuarioId { get; set; }
    public Guid AgenciaId { get; set; }
}
