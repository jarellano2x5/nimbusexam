namespace exanim.core.DTOs;

public record OPOrdenMinDTO
{
    public Guid Id { get; set; }
    public DateTime Fecha { get; set; }
    public string? Correo { get; set; }
    public DateOnly? FechaEntrega { get; set; }
    public Item Unidad { get; set; } = null!;
    public Item Estado { get; set; } = null!;
}
