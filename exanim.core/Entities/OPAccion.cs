namespace exanim.core.Entities;

public class OPAccion : Entity
{
    public Guid AccionId { get; set; }
    public bool EsPrevio { get; set; }
    public bool Autoriza { get; set; }
    public bool Notifica { get; set; }
    public Guid PasoId { get; set; }
    public Guid PerfilId { get; set; }
}
