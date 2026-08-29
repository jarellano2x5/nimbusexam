using exanim.core.Enums;

namespace exanim.core.Entities;

public class CFRol : Entity
{
    public RolEnum Rol { get; set; }
    public Guid PerfilId { get; set; }
}