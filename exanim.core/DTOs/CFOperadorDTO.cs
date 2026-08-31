namespace exanim.core.DTOs;

public record CFOperadorDTO
{
    public Guid? Id { get; set; }
    public string Nombre { get; set; } = string.Empty;
    public string Correo { get; set; } = string.Empty;
    public DateTime Desde { get; set; }
}