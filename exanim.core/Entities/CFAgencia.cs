using exanim.core.DTOs;
using exanim.core.Enums;

namespace exanim.core.Entities;

public class CFAgencia : Entity
{
    public string RFC { get; set; } = string.Empty;
    public string RazonSocial { get; set; } = string.Empty;
    public string Nombre { get; set; } = string.Empty;
    public CFTipoEnum Tipo { get; set; }
    public CFPlanEnum Plan { get; set; }
    public string ZipCode { get; set; } = string.Empty;
    public bool Activo { get; set; }
    public Guid UsuarioId { get; set; }
}

public static class AgenciaExtensions
{
    extension(CFAgencia m)
    {
        public Item ToItem() => new(m.Id, m.Nombre, m.Tipo.ToString());

        public CFAgenciaDTO ToDto() => new()
        {
            Id = m.Id,
            RFC = m.RFC,
            RazonSocial = m.RazonSocial,
            Nombre = m.RazonSocial,
            Tipo = new((byte)m.Tipo, m.Tipo.ToString()),
            Plan = new((byte)m.Plan, m.Plan.ToString()),
            Activo = m.Activo,
            UsuarioId = m.UsuarioId
        };

        public CFAgencia ToExists(CFAgenciaDTO d)
        {
            m.RFC = d.RFC;
            m.RazonSocial = d.RazonSocial;
            m.Nombre = d.Nombre;
            m.Tipo = (CFTipoEnum)d.Tipo.Id;
            m.Plan = (CFPlanEnum)d.Plan.Id;
            m.Activo = d.Activo;
            return m;
        }
    }

    extension(CFAgenciaDTO d)
    {
        public CFAgencia ToModel() => new()
        {
            Id = Guid.NewGuid(),
            RFC = d.RFC,
            RazonSocial = d.RazonSocial,
            Nombre = d.Nombre,
            Tipo = (CFTipoEnum)d.Tipo.Id,
            Plan = (CFPlanEnum)d.Plan.Id,
            Activo = true,
            UsuarioId = d.UsuarioId
        };
    }
}