
using exanim.core.Enums;

namespace exanim.core.Entities;

public class CFPerfil
{
    public Guid PerfilId { get; set; }
    public string Nombre { get; set; } = string.Empty;
    public CFGrupoEnum Grupo { get; set; }
}
