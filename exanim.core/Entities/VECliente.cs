using exanim.core.DTOs;

namespace exanim.core.Entities;

public class VECliente : Entity
{
    public bool Activo { get; set; }
    public Guid UsuarioId { get; set; }
    public DateTime Fecha { get; set; }
    public Guid? CompaniaId { get; set; }

    public virtual CFUsuario Usuario { get; set; } = null!;
    public virtual VECompania? Compania { get; set; }
}

public static class ClienteExtensions
{
    extension(VECliente m)
    {
        public VEClienteDTO ToDto() => new()
        {
            Id = m.Id,
            Activo = m.Activo,
            Usuario = new(m.UsuarioId, m.Usuario.Nombre),
            Compania = m.CompaniaId is null ? null
                : new(m.Compania!.Id, m.Compania.Nombre)
        };

        public VECliente ToExists(VEClienteDTO d)
        {
            m.Activo = true;
            m.UsuarioId = d.Usuario.Id;
            m.CompaniaId = d.Compania?.Id;
            return m;
        }

        public Item ToItem() => new(m.Id, m.Usuario.Nombre, m.Compania?.Nombre ?? "");
    }

    extension(VEClienteDTO d)
    {
        public VECliente ToModel() => new()
        {
            Id = Guid.NewGuid(),
            Activo = true,
            UsuarioId = d.Usuario.Id,
            Fecha = DateTime.Now,
            CompaniaId = d.Compania?.Id
        };
    }
}