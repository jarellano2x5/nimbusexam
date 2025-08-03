using exanim.core.Enums;

namespace exanim.core.DTOs;

public record class CFSignedDTO
{
    public Guid UsuarioId { get; set; }
    public string Usuario { get; set; } = string.Empty;
    public bool Activo { get; set; }
    public Guid PerfilId { get; set; }
    public CFGrupoEnum Grupo { get; set; }
    public Guid? AgenciaId { get; set; }
}
