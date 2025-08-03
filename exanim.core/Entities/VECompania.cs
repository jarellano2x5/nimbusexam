namespace exanim.core.Entities;

public class VECompania : Entity
{
    public Guid CompaniaId { get; set; }
    public string RFC { get; set; } = string.Empty;
    public string RazonSocial { get; set; } = string.Empty;
    public string Nombre { get; set; } = string.Empty;
    public bool Activo { get; set; }
    public Guid UsuarioId { get; set; }
}
