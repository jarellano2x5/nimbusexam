namespace exanim.core.Entities;

public class VEUnidad : Entity
{
    public Guid UnidadId { get; set; }
    public string Placa { get; set; } = string.Empty;
    public string Modelo { get; set; } = string.Empty;
    public string Anio { get; set; } = string.Empty;
    public string Color { get; set; } = string.Empty;
    public DateTime Registrado { get; set; }
    public Guid MarcaId { get; set; }
}
