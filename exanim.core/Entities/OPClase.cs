namespace exanim.core.Entities;

public class OPClase : Entity
{
    public string Nombre { get; set; } = string.Empty;
    public bool Activo { get; set; }
    public Guid AgenciaId { get; set; }
}
