namespace exanim.core.Entities;

public class CFTaller : Entity
{
    public Guid TallerId { get; set; }
    public string Codigo { get; set; } = string.Empty;
    public string Nombre { get; set; } = string.Empty;
    public string Direccion { get; set; } = string.Empty;
    public Location Lugar { get; set; } = null!;
    public bool Activo { get; set; }
    public Guid AgenciaId { get; set; }
    public Guid UsuarioId { get; set; }
}
