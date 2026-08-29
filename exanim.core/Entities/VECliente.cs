namespace exanim.core.Entities;

public class VECliente : Entity
{
    public bool Activo { get; set; }
    public Guid UsuarioId { get; set; }
    public DateTime Fecha { get; set; }
    public Guid? CompaniaId { get; set; }
}
