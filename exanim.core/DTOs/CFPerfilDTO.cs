using System.ComponentModel.DataAnnotations;

namespace exanim.core.DTOs;

public record CFPerfilDTO
{
    public Guid? Id { get; set; }
    [Length(3, 15)]
    public string Nombre { get; set; } = string.Empty;
    public Guid AgenciaId { get; set; }
    public bool Activo { get; set; }
    public IEnumerable<Option> Rols { get; set; } = [];
}
