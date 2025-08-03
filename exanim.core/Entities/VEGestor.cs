namespace exanim.core.Entities;

public class VEGestor : Entity
{
    public Guid GestorId { get; set; }
    public bool Activo { get; set; }
    public Guid UsuarioId { get; set; }
    public Guid CompaniaId { get; set; }
}
