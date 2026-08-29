
using exanim.core.Enums;

namespace exanim.core.Entities;

public class CFPerfil : Entity
{
    public string Nombre { get; set; } = string.Empty;
    public Guid AgenciaId { get; set; }
    public bool Activo { get; set; }

    public virtual ICollection<CFRol> Roles { get; set; } = [];
}
