using exanim.core.DTOs;
using exanim.core.Enums;

namespace exanim.core.Entities;

public class CFParametro : Entity
{
    public string Clave { get; set; } = string.Empty;
    public string Nombre { get; set; } = string.Empty;
    public KindEnum Tipo { get; set; }
    public bool Activo { get; set; }
}

public static class ParametroExtensions
{
    extension(CFParametro m)
    {
        public Item ToItem() => new(m.Id, m.Nombre, m.Clave);
    }

    extension(CFParametroDTO d)
    {
        public CFParametro ToModel() => new()
        {
            Id = Guid.NewGuid(),
            Clave = d.Clave,
            Nombre = d.Nombre,
            Tipo = (KindEnum)d.Tipo.Id,
            Activo = d.Activo
        };
        public CFParametro ToPatch() => new()
        {
            Id = d.Id!.Value,
            Clave = d.Clave,
            Nombre = d.Nombre,
            Tipo = (KindEnum)d.Tipo.Id,
            Activo = d.Activo
        };
    }
}