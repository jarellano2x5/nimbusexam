namespace exanim.core.DTOs;

public record VELineaDTO
{
    public Guid? Id { get; set; }
    public string Clave { get; set; } = string.Empty;
    public string Unidad { get; set; } = string.Empty;
    public string Concepto { get; set; } = string.Empty;
    public float Cantidad { get; set; }
    public float Precio { get; set; }
    public float Importe { get; set; }
}
