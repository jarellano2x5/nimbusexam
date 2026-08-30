using exanim.core.DTOs;
using exanim.core.Enums;

namespace exanim.core.Entities;

public class OPEstado : Entity
{
    public string Nombre { get; set; } = string.Empty;
    public OPFaseEnum Fase { get; set; }
    public string Code { get; set; } = string.Empty;
    public bool Activo { get; set; }
    public Guid AgenciaId { get; set; }
}

public static class EstadoExtensions
{
    extension(OPEstado m)
    {
        public OPEstado ToExists(OPEstadoDTO d, Guid idAgencia)
        {
            m.Nombre = d.Nombre;
            m.Fase = (OPFaseEnum)d.Fase.Id;
            m.Code = d.Code;
            m.AgenciaId = idAgencia;
            return m;
        }

        public OPEstadoDTO ToDto() => new()
        {
            Id = m.Id,
            Nombre = m.Nombre,
            Fase = new((byte)m.Fase, m.Fase.ToString()),
            Code = m.Code,
            Activo = m.Activo
        };

        public Item ToItem() => new(m.Id, m.Nombre, m.Code);
    }

    extension(OPEstadoDTO d)
    {
        public OPEstado ToModel(Guid idAgencia) => new()
        {
            Id = Guid.NewGuid(),
            Nombre = d.Nombre,
            Fase = (OPFaseEnum)d.Fase.Id,
            Code = d.Code,
            Activo = true,
            AgenciaId = idAgencia
        };
    }
}