using exanim.core.DTOs;

namespace exanim.core.Entities;

public class Brand : Entity
{
    public string Name { get; set; } = string.Empty;
    public bool Activo { get; set; }
}

public static class BrandExtensions
{
    extension(Brand m)
    {
        public Item ToItem() => new(m.Id, m.Name);
    }

    extension(BrandDTO d)
    {
        public Brand ToModel() => new()
        {
            Id = Guid.NewGuid(),
            Name = d.Name,
            Activo = d.Activo
        };

        public Brand ToPatch() => new()
        {
            Id = d.Id!.Value,
            Name = d.Name,
            Activo = d.Activo
        };

        public Brand ToExists(Brand m)
        {
            m.Name = d.Name;
            m.Activo = d.Activo;
            return m;
        }
    }
}