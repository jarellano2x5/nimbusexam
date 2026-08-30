using exanim.core.DTOs;

namespace exanim.core.Entities;

public class CFUsuario : Entity
{
    public string Nombre { get; set; } = string.Empty;
    public string Usuario { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public string Correo { get; set; } = string.Empty;
    public bool Activo { get; set; }
    public bool EsTitular { get; set; }

    public virtual ICollection<CFSocio> Socios { get; set; } = [];
}

public static class UsuarioExtensions
{
    extension(CFUsuario m)
    {
        
    }

    extension(CFRegisterDTO d)
    {
        public CFUsuario ToModel(string pwd) => new()
        {
            Id = Guid.NewGuid(),
            Usuario = d.Usuario,
            Password = pwd,
            Correo = d.Correo,
            Activo = true,
            EsTitular = true
        };
    }
}