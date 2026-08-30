using exanim.core.DTOs;

namespace exanim.core.Entities;

public class CFTaller : Entity
{
    public string Codigo { get; set; } = string.Empty;
    public string Nombre { get; set; } = string.Empty;
    public string Direccion { get; set; } = string.Empty;
    public Location Lugar { get; set; } = null!;
    public bool Activo { get; set; }
    public Guid AgenciaId { get; set; }
    public Guid UsuarioId { get; set; }
}

public static class TallerExtensions
{
    extension(CFTaller m)
    {
        public Item ToItem() => new(m.Id, m.Nombre, m.Codigo);
    }

    extension(CFTallerDTO d)
    {
        public CFTaller ToModel(Guid idAgencia) => new()
        {
            Id = Guid.NewGuid(),
            Codigo = d.Codigo,
            Nombre = d.Nombre,
            Direccion = d.Direccion,
            Lugar = d.Lugar,
            Activo = d.Activo,
            AgenciaId = idAgencia,
            UsuarioId = d.Usuario.Id
        };

        public CFTaller ToPatch(Guid idAgencia) => new()
        {
            Id = d.Id!.Value,
            Codigo = d.Codigo,
            Nombre = d.Nombre,
            Direccion = d.Direccion,
            Lugar = d.Lugar,
            Activo = d.Activo,
            AgenciaId = idAgencia,
            UsuarioId = d.Usuario.Id
        };
    }
}