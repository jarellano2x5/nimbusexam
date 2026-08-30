using exanim.core.DTOs;

namespace exanim.core.Entities;

public class CFPerfil : Entity
{
    public string Nombre { get; set; } = string.Empty;
    public Guid AgenciaId { get; set; }
    public bool Activo { get; set; }

    public virtual ICollection<CFRol> Roles { get; set; } = [];
}

public static class PerfilExtensions
{
    extension(CFPerfil m)
    {
        public CFPerfil ToExists(CFPerfilDTO d)
        {
            m.Nombre = d.Nombre;
            m.Activo = d.Activo;
            return m;
        }

        public Item ToItem() => new(m.Id, m.Nombre);

        public CFPerfilDTO ToDto() => new()
        {
            Id = m.Id,
            Nombre = m.Nombre,
            AgenciaId = m.AgenciaId,
            Activo = m.Activo,
            Rols = m.Roles.Select(r => r.ToOption())
        };
    }

    extension(CFPerfilDTO d)
    {
        public CFPerfil ToModel() => new()
        {
            Id = Guid.NewGuid(),
            Nombre = d.Nombre,
            Activo = true
        };
    }
}