using exanim.core.DTOs;

namespace exanim.core.Entities;

public partial class CFConfigura : Entity
{
    public Guid AgenciaId { get; set; }
    public Guid ParametroId { get; set; }
    public int Valor { get; set; }
    public string Cadena { get; set; } = string.Empty;
    public bool Activo { get; set; }
    public DateTime Fecha { get; set; }
}

public static class ConfiguraExtensions
{
    extension(CFConfigura m)
    {
        public Item ToItem() => new(m.Id, m.Cadena);
        
        public CFConfigura ToExists(CFConfiguraDTO d)
        {
            m.ParametroId = d.ParametroId;
            m.ParametroId = d.ParametroId;
            m.Valor = d.Valor;
            m.Cadena = d.Cadena;
            return m;
        }
    }

    extension(CFConfiguraDTO d)
    {
        public CFConfigura ToModel() => new()
        {
            Id = Guid.NewGuid(),
            AgenciaId = d.AgenciaId,
            ParametroId = d.ParametroId,
            Valor = d.Valor,
            Cadena = d.Cadena,
            Activo = true,
            Fecha = DateTime.Now
        };
    }
}