using exanim.core.Enums;

namespace exanim.core.Entities;

public class CFParametro : Entity
{
    public string Clave { get; set; } = string.Empty;
    public string Nombre { get; set; } = string.Empty;
    public KindEnum Tipo { get; set; }
    public bool Activo { get; set; }
}
