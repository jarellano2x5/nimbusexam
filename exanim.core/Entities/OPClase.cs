using exanim.core.DTOs;

namespace exanim.core.Entities;

public class OPClase : Entity
{
    public string Nombre { get; set; } = string.Empty;
    public bool Activo { get; set; }
    public Guid AgenciaId { get; set; }
}

public static class ClaseExtensions
{
    extension(OPClase m)
    {
        public OPClase ToExists(OPClaseDTO d)
        {
            m.Nombre = d.Nombre;
            m.Activo = d.Activo;
            return m;
        }
        
        public Item ToItem() => new(m.Id, m.Nombre);
    }

    extension(OPClaseDTO d)
    {
        public OPClase ToModel(Guid idAgencia) => new()
        {
            Id = Guid.NewGuid(),
            Nombre = d.Nombre,
            Activo = true,
            AgenciaId = idAgencia
        };
    }
}