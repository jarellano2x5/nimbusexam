namespace exanim.core.Entities;

public class OPClase : Entity
{
    public Guid ClaseId { get; set; }
    public string Nombre { get; set; } = string.Empty;
    public bool Activo { get; set; }
    public Guid AgenciaId { get; set; }
}
