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
