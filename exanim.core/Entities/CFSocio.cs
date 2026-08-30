using exanim.core.DTOs;

namespace exanim.core.Entities;

public class CFSocio : Entity
{
    public Guid AgenciaId { get; set; }
    public Guid UsuarioId { get; set; }
    public Guid PerfilId { get; set; }

    public virtual CFUsuario Usuario { get; set; } = null!;
    public virtual CFPerfil Perfil { get; set; } = null!;
}

public static class SocioExtensions
{
    extension(CFSocio m)
    {
        public CFSocioDTO ToDto() => new()
        {
            Id = m.Id,
            Nombre = m.Usuario.Nombre,
            Usuario = m.Usuario.Usuario,
            Correo = m.Usuario.Correo,
            Perfil = new Item(m.PerfilId, m.Perfil.Nombre)
        };
    }
    
    extension(CFSocioDTO d)
    {
        public CFUsuario ToUser() => new()
        {
            Id = Guid.NewGuid(),
            Nombre = d.Nombre,
            Usuario = d.Usuario,
            Correo = d.Correo,
            Activo = true,
            EsTitular = false
        };

        public CFSocio ToModel(Guid idUsu, Guid idAgencia) => new()
        {
            Id = Guid.NewGuid(),
            AgenciaId = idAgencia,
            UsuarioId = idUsu,
            PerfilId = d.Perfil.Id
        };
    }
}