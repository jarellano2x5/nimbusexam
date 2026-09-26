using exanim.core.DTOs;

namespace exanim.core.Entities;

public class VEUnidad : Entity
{
    public string Placa { get; set; } = string.Empty;
    public string Modelo { get; set; } = string.Empty;
    public string Anio { get; set; } = string.Empty;
    public string Color { get; set; } = string.Empty;
    public DateTime Registrado { get; set; }
    public Guid MarcaId { get; set; }
    public bool Activo { get; set; }

    public virtual OPBrand Marca { get; set; } = null!;
}

public static class UnidadExtensions
{
    extension(VEUnidad m)
    {
        public VEUnidad ToExists(VEUnidadDTO d)
        {
            m.Placa = d.Placa;
            m.Modelo = d.Modelo;
            m.Anio = d.Anio;
            m.Color = d.Color;
            m.MarcaId = d.Marca.Id;
            return m;
        }

        public VEUnidadDTO ToDto() => new()
        {
            Id = m.Id,
            Placa = m.Placa,
            Modelo = m.Modelo,
            Anio = m.Anio,
            Color = m.Color,
            Registrado = m.Registrado,
            Marca = new(m.MarcaId, m.Marca.Name)
        };

        public Item ToItem() =>
            new(m.Id, m.Placa, $"{m.Modelo} {m.Anio}", m.Activo);
    }

    extension(VEUnidadDTO d)
    {
        public VEUnidad ToModel() => new()
        {
            Id = Guid.NewGuid(),
            Placa = d.Placa,
            Modelo = d.Modelo,
            Anio = d.Anio,
            Color = d.Color,
            Registrado = DateTime.Now,
            MarcaId = d.Marca.Id,
            Activo = true
        };
    }
}