using exanim.core.DTOs;

namespace exanim.core.Entities;

public class OPBrand : Entity
{
    public string Name { get; set; } = string.Empty;
    public bool Activo { get; set; }
}

public static class BrandExtensions
{
    extension(OPBrand m)
    {
        public Item ToItem() => new(m.Id, m.Name);
    }

    extension(BrandDTO d)
    {
        public OPBrand ToModel() => new()
        {
            Id = Guid.NewGuid(),
            Name = d.Name,
            Activo = d.Activo
        };

        public OPBrand ToPatch() => new()
        {
            Id = d.Id!.Value,
            Name = d.Name,
            Activo = d.Activo
        };

        public OPBrand ToExists(OPBrand m)
        {
            m.Name = d.Name;
            m.Activo = d.Activo;
            return m;
        }
    }
}