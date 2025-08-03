using System.ComponentModel.DataAnnotations;

namespace exanim.core.DTOs;

public class CFUsuarioDTO
{
    public Guid UsuarioId { get; set; }
    [Length(4, 15)]
    public string Usuario { get; set; } = string.Empty;
    [Length(5, 150)]
    public string Nombre { get; set; } = string.Empty;
    [Length(8, 300)]
    public string Password { get; set; } = string.Empty;
    [Length(10, 150)]
    public string Correo { get; set; } = string.Empty;
    public bool Activo { get; set; }
    public Item Perfil { get; set; } = null!;
}
