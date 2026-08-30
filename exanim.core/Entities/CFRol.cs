using exanim.core.DTOs;
using exanim.core.Enums;

namespace exanim.core.Entities;

public class CFRol : Entity
{
    public RolEnum Rol { get; set; }
    public Guid PerfilId { get; set; }
}

public static class RolExtensions
{
    extension(CFRol m)
    {
        public Option ToOption() => new((byte)m.Rol, m.Rol.ToString());
    }
    
    extension(Option d)
    {
        public CFRol ToModel(Guid per) => new()
        {
            Id = Guid.NewGuid(),
            Rol = (RolEnum)d.Id,
            PerfilId = per
        };
    }
}