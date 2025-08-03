using System.ComponentModel.DataAnnotations;

namespace exanim.core.DTOs;

public record CFPerfilDTO
{
    public Guid PerfilId { get; set; }
    [Length(3, 15)]
    public string Nombre { get; set; } = string.Empty;
    public Option Grupo { get; set; } = null!;
}
